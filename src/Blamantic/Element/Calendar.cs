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
    public class Calendar:BlamanticComponentBase,IHasUIComponent
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

        public Calendar()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

            WeekTitles = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };

            ViewMode = CalendarViewMode.Date;

            MonthMapper = new Dictionary<int, string>(MAX_MONTH);
            for (int i = 1; i <= MAX_MONTH; i++)
            {
                MonthMapper.Add(i, $"{i}月");
            }
        }

        [Parameter]public int Year { get; set; }
        [Parameter] public int Month { get; set; }
        [Parameter] public string[] WeekTitles { get; set; }
        [Parameter] public CalendarViewMode ViewMode { get; set; }

        [Parameter] public string StringFormat { get; set; }

        [Parameter] public EventCallback<DateTime> OnClick { get; set; }

        [Parameter] public Color CurrentColor { get; set; } = Color.Blue;
        [Parameter] public Dictionary<int,string> MonthMapper { get; set; }

        protected int CurrentYear { get; set; }
        protected int CurrentMonth { get; set; }
        protected int CurrentDay { get; set; }
        protected int CurrentHour { get; set; }
        protected int CurrentMinute { get; set; }
        protected int CurrentSecond { get; set; }

        RenderFragment GetCalendarBody => this.BuildBody;

        protected override void OnParametersSet()
        {
            CurrentYear = Year;
            CurrentMonth = Month;
        }


        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("calendar");
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            builder.AddContent(10, calendar =>
            {
                calendar.OpenElement(0, "table");
                calendar.AddAttribute(2, "class", (CssClassCollection)"ui celled center aligned table");
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

        private void BuildWeekTitle(RenderTreeBuilder builder)
        {
            foreach (var item in WeekTitles)
            {
                builder.OpenComponent<Th>(0);
                builder.AddAttribute(10, nameof(Th.ChildContent), (RenderFragment)(th =>
                    {
                        th.AddContent(0, item);
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
                BuildCalendarContent(builder, i, i, new DateTime(i, 1, 1), (today.Year == i));
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
            for (int i = 1; i <= MonthMapper.Count; i++)
            {
                var item = MonthMapper[i];
                var today = DateTime.Today;
                BuildCalendarContent(builder, i, item,new DateTime(CurrentYear,CurrentMonth,1), (today.Year == CurrentYear && today.Month == i));
                if (i % 3 == 0)
                {
                    BuildNewLine(builder, i + 10);
                }
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
                BuildCalendarContent(builder, i, i + 1, disabled:true);
            }

            var daysInMounth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
            for (int i = 1; i <= daysInMounth; i++)
            {
                var day = i;
                var today = DateTime.Today;

                BuildCalendarContent(builder, i, i, focus: new DateTime(CurrentYear, CurrentMonth, day) == today);

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
                BuildCalendarContent(builder, i, day, new DateTime(CurrentYear, CurrentMonth, day), disabled: true);
            }            

            builder.CloseElement();
        }

        private static void BuildNewLine(RenderTreeBuilder builder, int sequence)
        {
            builder.CloseElement();
            builder.OpenElement(sequence, "tr");
        }

        void BuildCalendarContent(RenderTreeBuilder builder, int sequence, object value,DateTime? clickedValue=default, bool focus = false, bool disabled = false)
        {

            builder.OpenComponent<Td>(0);
            builder.AddAttribute(1 + sequence, nameof(Td.AdditionalCssClass), (CssClassCollection)Css.Create.Add(disabled, "adjacent").Add(focus, CurrentColor.GetEnumCssClass()).Add("link"));
            if (clickedValue.HasValue)
            {
                builder.AddAttribute(2 + sequence, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, async (e) =>
                {
                    await OnClick.InvokeAsync(clickedValue.Value);
                }));
            }
            builder.AddAttribute(10 + sequence, nameof(Td.ChildContent), (RenderFragment)(td =>
            {
                td.AddContent(0 + sequence, value);
            }));

            builder.CloseComponent();
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
}
