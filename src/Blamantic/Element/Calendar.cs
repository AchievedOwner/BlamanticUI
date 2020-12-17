namespace BlamanticUI
{
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using Microsoft.AspNetCore.Components.Web;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using YoiBlazor;

    /// <summary>
    /// 表示日期的呈现组件。
    /// </summary>
    public class Calendar:BlamanticComponentBase,IHasUIComponent,IHasInverted
    {
        /// <summary>
        /// 一周几天。
        /// </summary>
        private const int DAYS_IN_WEEK = 7;
        /// <summary>
        /// 最大月份数。
        /// </summary>
        private const int MAX_MONTH = 12;
        /// <summary>
        /// 最小月份数。
        /// </summary>
        private const int MIN_MONTH = 1;
        /// <summary>
        /// 最大年份区间。
        /// </summary>
        private const int MAX_YEAR_RANGE = 10;

        /// <summary>
        /// 初始化 <see cref="Calendar"/> 类的新实例。
        /// </summary>
        public Calendar()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

            WeekMapper = new Dictionary<DayOfWeek, string>
            {
                [DayOfWeek.Sunday] = "周日",
                [DayOfWeek.Monday] = "周一",
                [DayOfWeek.Tuesday] = "周二",
                [DayOfWeek.Wednesday] = "周三",
                [DayOfWeek.Thursday] = "周四",
                [DayOfWeek.Friday] = "周五",
                [DayOfWeek.Saturday] = "周六"
            };

            MonthMapper = new Dictionary<CalendarMonth, string>(MAX_MONTH)
            {
                [CalendarMonth.Janurary] = "一月",
                [CalendarMonth.February] = "二月",
                [CalendarMonth.March] = "三月",
                [CalendarMonth.April] = "四月",
                [CalendarMonth.May] = "五月",
                [CalendarMonth.June] = "六月",
                [CalendarMonth.July] = "七月",
                [CalendarMonth.Augest] = "八月",
                [CalendarMonth.September] = "九月",
                [CalendarMonth.October] = "十月",
                [CalendarMonth.November] = "十一月",
                [CalendarMonth.December] = "十二月",
            };
        }

        /// <summary>
        /// 设置显示的年份。默认是当前年。
        /// </summary>
        [Parameter]public int Year { get; set; }
        /// <summary>
        /// 设置显示的月份。默认是当前月。
        /// </summary>
        [Parameter] public int Month { get; set; }

        /// <summary>
        /// 设置视图模式。
        /// </summary>
        [Parameter] public CalendarViewMode ViewMode { get; set; } = CalendarViewMode.Date;

        /// <summary>
        /// 设置匹配今日的背景颜色。
        /// </summary>
        [Parameter] public Color TodayColor { get; set; } = Color.Blue;

        /// <summary>
        /// 设置一个布尔值，表示是否高亮今日。
        /// </summary>
        [Parameter] public bool HightlightToday { get; set; } = true;

        /// <summary>
        /// 设置对 <see cref="DayOfWeek"/> 对应的文本委托。
        /// </summary>
        [Parameter] public Action<IDictionary<DayOfWeek,string>> WeekMapExpression { get; set; }
        /// <summary>
        /// 设置对指定 <see cref="CalendarMonth"/> 对应的文本委托。
        /// </summary>
        [Parameter] public Action<IDictionary<CalendarMonth, string>> MonthMapExpression { get; set; }
        /// <summary>
        /// 设置一个回调方法，当点击值时触发。
        /// </summary>
        [Parameter] public EventCallback<DateTime?> OnClick { get; set; }

        protected int CurrentYear { get; set; }
        protected int CurrentMonth { get; set; }
        protected int CurrentDay { get; set; }
        protected int CurrentHour { get; set; }
        protected int CurrentMinute { get; set; }
        protected int CurrentSecond { get; set; }
        protected IDictionary<DayOfWeek, string> WeekMapper { get; set; }
        protected IDictionary<CalendarMonth, string> MonthMapper { get; set; }

        [Parameter]public bool Inverted { get; set; }

        protected override void OnParametersSet()
        {
            CurrentYear = Year;
            CurrentMonth = Month;

            WeekMapExpression?.Invoke(WeekMapper);
            MonthMapExpression?.Invoke(MonthMapper);
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css"><see cref="T:YoiBlazor.Css" /> 实例。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("calendar");
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddContent(10, calendar =>
            {
                calendar.OpenElement(0, "table");
                calendar.AddAttribute(2, "class", (CssClassCollection)Css
                    .Create
                    .Add("ui")
                    .Add("celled center aligned")
                    .Add(Inverted,"inverted")
                    .Add("table")
                    );
                calendar.AddContent(5, thead =>
                {
                    thead.OpenElement(0, "thead");
                    thead.AddContent(1, BuildHead);
                    thead.CloseElement();
                });
                calendar.AddContent(10, tbody =>
                {
                    tbody.OpenElement(0, "tbody");
                    tbody.AddContent(1, BuildBody);
                    tbody.CloseElement();
                });
                calendar.CloseElement();
            });
            builder.CloseElement();
        }

        void BuildHead(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Tr>(0);
            builder.AddAttribute(10, nameof(Tr.ChildContent), (RenderFragment)(tr =>
            {
                BuildTitle(tr);
            }));
            builder.CloseComponent();

            if (new[] { CalendarViewMode.Date, CalendarViewMode.DateTime }.Contains(ViewMode))
            {
                builder.OpenComponent<Tr>(11);
                builder.AddAttribute(20, nameof(Tr.ChildContent), (RenderFragment)(tr =>
                {
                    BuildWeekTitle(tr);
                }));
                builder.CloseComponent();
            }

        }

        private void BuildTitle(RenderTreeBuilder tr)
        {
            tr.OpenComponent<Th>(0);
            tr.AddAttribute(1, nameof(Th.ColSpan), DAYS_IN_WEEK);
            tr.AddAttribute(10, nameof(Th.ChildContent), (RenderFragment)(th =>
            {
                th.OpenElement(0, "span");
                th.AddAttribute(1, "class", "link");

                var content = string.Empty;
                switch (ViewMode)
                {
                    case CalendarViewMode.Year:
                        (var min,var max) = GetYearRange();
                        content = $"{min} - {max}";
                        break;
                    case CalendarViewMode.Month:
                        content = CurrentYear.ToString();
                        break;
                    case CalendarViewMode.Date:
                        content = $"{CurrentYear} - {CurrentMonth}";
                        break;
                    case CalendarViewMode.Time:
                        break;
                    case CalendarViewMode.DateTime:
                        break;
                    default:
                        break;
                }

                th.AddContent(10, content);
                th.CloseElement();

                BuildPrevAndNext(th, true);
                BuildPrevAndNext(th, false,25);
            }));
            tr.CloseComponent();
        }

        private (int min, int max) GetYearRange()
        {
            var range = (CurrentYear-1) * 0.1;
            var min = (int)Math.Floor(range) * 10 + 1;
            var max = min + MAX_YEAR_RANGE - 1;
            return (min, max);
        }

        private void BuildPrevAndNext(RenderTreeBuilder th,bool prevOrNext,int sequence=11)
        {
            th.OpenElement(11+sequence, "span");
            th.AddAttribute(12+sequence, "class", $"{(prevOrNext?"prev":"next")} link");
            th.AddAttribute(15+sequence, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, _ =>
               {
                   ClickPreviousOrNext(prevOrNext);
               }));
            th.AddContent(20+sequence, icon =>
            {
                icon.OpenComponent<Icon>(0);
                icon.AddAttribute(1, nameof(Icon.IconClass), $"chevron {(prevOrNext?"left":"right")}");
                icon.CloseComponent();
            });
            th.CloseElement();
        }

        /// <summary>
        /// 构造周的标题。
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildWeekTitle(RenderTreeBuilder builder)
        {
            var weekNames= typeof(DayOfWeek).GetEnumNames();
            foreach (var name in weekNames)
            {
                var week = Enum.Parse<DayOfWeek>(name);
                if(!WeekMapper.TryGetValue(week,out string value))
                {
                    value = name;
                }


                builder.OpenComponent<Th>(0);
                builder.AddAttribute(10, nameof(Th.ChildContent), (RenderFragment)(th =>
                {
                    th.AddContent(0, value);
                }));
                builder.CloseComponent();
            }
        }

        private void BuildBody(RenderTreeBuilder builder)
        {
            switch (ViewMode)
            {
                case CalendarViewMode.Year:
                    BuildYear(builder);
                    break;
                case CalendarViewMode.Month:
                    BuildYearMonth(builder);
                    break;
                case CalendarViewMode.Date:
                    BuildYearMonthDate(builder);
                    break;
                case CalendarViewMode.Time:
                    break;
                default:
                    break;
            }
        }

        private void BuildYear(RenderTreeBuilder builder)
        {
            (var min, var max) = GetYearRange();

            builder.OpenElement(0, "tr");
            for (int i = min; i <= max; i++)
            {
                var today = DateTime.Today;
                BuildCalendarContent(builder, i, i.ToString(), i, (today.Year == i));
                if (i % 5 == 0)
                {
                    BuildNewLine(builder, i + 10);
                }
            }
            builder.CloseElement();
        }

        void ClickPreviousOrNext(bool prevOrNext)
        {
            switch (ViewMode)
            {
                case CalendarViewMode.Year:
                    CurrentYear = prevOrNext ? CurrentYear - MAX_YEAR_RANGE : CurrentYear + MAX_YEAR_RANGE;
                    break;
                case CalendarViewMode.Month:
                    CurrentYear = prevOrNext ? CurrentYear - 1 : CurrentYear + 1;
                    break;
                case CalendarViewMode.Date:
                    CurrentMonth = prevOrNext ? CurrentMonth - 1 : CurrentMonth + 1;
                    break;
                case CalendarViewMode.Time:
                    break;
                case CalendarViewMode.DateTime:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 构造年/月。
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildYearMonth(RenderTreeBuilder builder)
        {
            if (CurrentMonth < MIN_MONTH)
            {
                CurrentYear--;
                CurrentMonth = MAX_MONTH;
            }
            if (CurrentMonth > MAX_MONTH)
            {
                CurrentYear++;
                CurrentMonth = MIN_MONTH;
            }

            builder.OpenElement(0, "tr");

            var monthNames= typeof(CalendarMonth).GetEnumNames();
            var i = 1;
            foreach (var name in monthNames)
            {
                var month = Enum.Parse<CalendarMonth>(name);
                if(!MonthMapper.TryGetValue(month,out string value))
                {
                    value = name;
                }
                var item = (int)month;
                var today = DateTime.Today;
                BuildCalendarContent(builder, i, value, (int)month, (today.Year == CurrentYear && today.Month == item));
                if (i % 3 == 0)
                {
                    BuildNewLine(builder, i + 10);
                }
                i++;
            }
            builder.CloseElement();
        }

        /// <summary>
        /// 构造年/月/日期
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildYearMonthDate(RenderTreeBuilder builder)
        {
            if (CurrentMonth < MIN_MONTH)
            {
                CurrentYear--;
                CurrentMonth = MAX_MONTH;
            }
            if (CurrentMonth > MAX_MONTH)
            {
                CurrentYear++;
                CurrentMonth = MIN_MONTH;
            }

            builder.OpenElement(0, "tr");

            var firstDay = new DateTime(CurrentYear, CurrentMonth, 1);

            var dayOfWeek = (int)firstDay.DayOfWeek;


            var lastMonth = firstDay.AddDays(-1);
            var lastMonthDays = DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month);

            var lastDays = (lastMonthDays - dayOfWeek);
            for (int i = lastDays; i < lastMonthDays; i++)
            {
                var day = i + 1;
                BuildCalendarContent(builder, i,day.ToString(),day, disabled:true);
            }

            var daysInMounth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
            for (int i = 1; i <= daysInMounth; i++)
            {
                var day = i;
                var today = DateTime.Today;

                BuildCalendarContent(builder, i, day.ToString(),day, focus: new DateTime(CurrentYear, CurrentMonth, day) == today);

                if ((i + dayOfWeek) % DAYS_IN_WEEK == 0)
                {
                    BuildNewLine(builder, i + 10);
                }
            }

            var nextMonth = firstDay.AddMonths(1);
            var nextDayWeek = (int)(nextMonth.DayOfWeek);

            for (int i = 0; i < (DAYS_IN_WEEK - nextDayWeek); i++)
            {
                var day = i + 1;
                BuildCalendarContent(builder, i, day.ToString(),day,  disabled: true);
            }            

            builder.CloseElement();
        }

        private static void BuildNewLine(RenderTreeBuilder builder, int sequence)
        {
            builder.CloseElement();
            builder.OpenElement(sequence, "tr");
        }

        void BuildCalendarContent(RenderTreeBuilder builder, int sequence,string text, int value, bool focus = false, bool disabled = false)
        {

            builder.OpenElement(0,"td");
            builder.AddAttribute(100 + sequence, "class", Css.Create.Add(disabled, "adjacent")
                .Add(focus&&HightlightToday,TodayColor.GetEnumCssClass())
                .Add("link"));

            builder.AddAttribute(200 + sequence, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, (e) =>
            {
                DateTime? clickedValue = default ;
                switch (ViewMode)
                {
                    case CalendarViewMode.Year:
                        clickedValue = new DateTime(value, 1, 1);
                        break;
                    case CalendarViewMode.Month:
                        clickedValue = new DateTime(CurrentYear,value, 1);
                        break;
                    case CalendarViewMode.Date:
                        clickedValue = new DateTime(CurrentYear,CurrentMonth , value);
                        break;
                    case CalendarViewMode.Time:
                        break;
                    case CalendarViewMode.DateTime:
                        break;
                    default:
                        break;
                }
                OnClick.InvokeAsync(clickedValue);
            }));
            builder.AddContent(1000 + sequence, text);

            builder.CloseElement();
        }
    }

    /// <summary>
    /// 日历的视图模式。
    /// </summary>
    public enum CalendarViewMode
    {
        /// <summary>
        /// 仅显示年。
        /// </summary>
        Year = 0,
        /// <summary>
        /// 显示月份。
        /// </summary>
        Month = 1,
        /// <summary>
        /// 显示日期。
        /// </summary>
        Date = 2,
        /// <summary>
        /// 仅显示时间。
        /// </summary>
        Time = 3,
        /// <summary>
        /// 显示日期和时间。
        /// </summary>
        DateTime = 4,
    }

    /// <summary>
    /// 日历月份。
    /// </summary>
    public enum CalendarMonth
    {
        /// <summary>
        /// 一月。
        /// </summary>
        Janurary = 1,
        /// <summary>
        /// 二月。
        /// </summary>
        February = 2,
        /// <summary>
        /// 三月
        /// </summary>
        March = 3,
        /// <summary>
        /// 四月。
        /// </summary>
        April = 4,
        /// <summary>
        /// 五月。
        /// </summary>
        May = 5,
        /// <summary>
        /// 六月。
        /// </summary>
        June = 6,
        /// <summary>
        /// 七月。
        /// </summary>
        July = 7,
        /// <summary>
        /// 八月。
        /// </summary>
        Augest = 8,
        /// <summary>
        /// 九月。
        /// </summary>
        September = 9,
        /// <summary>
        /// 十月。
        /// </summary>
        October = 10,
        /// <summary>
        /// 十一月。
        /// </summary>
        November = 11,
        /// <summary>
        /// 十二月。
        /// </summary>
        December = 12
    }
}
