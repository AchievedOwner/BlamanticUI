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
    /// Render a calendar component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    public class Calendar : BlamanticComponentBase, IHasUIComponent, IHasInverted
    {
        /// <summary>
        /// Days in weeks.
        /// </summary>
        private const int DAYS_IN_WEEK = 7;
        /// <summary>
        /// Max month in a year.
        /// </summary>
        private const int MAX_MONTH = 12;
        /// <summary>
        /// Min month in a year.
        /// </summary>
        private const int MIN_MONTH = 1;
        /// <summary>
        /// Max years range when layout.
        /// </summary>
        private const int MAX_YEAR_RANGE = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Calendar"/> class.
        /// </summary>
        public Calendar()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

            WeekMapper = new Dictionary<DayOfWeek, string>
            {
                [DayOfWeek.Sunday] = DayOfWeek.Sunday.ToString(),
                [DayOfWeek.Monday] = DayOfWeek.Monday.ToString(),
                [DayOfWeek.Tuesday] = DayOfWeek.Tuesday.ToString(),
                [DayOfWeek.Wednesday] = DayOfWeek.Wednesday.ToString(),
                [DayOfWeek.Thursday] = DayOfWeek.Thursday.ToString(),
                [DayOfWeek.Friday] = DayOfWeek.Friday.ToString(),
                [DayOfWeek.Saturday] = DayOfWeek.Saturday.ToString()
            };

            MonthMapper = new Dictionary<CalendarMonth, string>(MAX_MONTH)
            {
                [CalendarMonth.Janurary] = CalendarMonth.Janurary.ToString(),
                [CalendarMonth.February] = CalendarMonth.February.ToString(),
                [CalendarMonth.March] = CalendarMonth.March.ToString(),
                [CalendarMonth.April] = CalendarMonth.April.ToString(),
                [CalendarMonth.May] = CalendarMonth.May.ToString(),
                [CalendarMonth.June] = CalendarMonth.June.ToString(),
                [CalendarMonth.July] = CalendarMonth.July.ToString(),
                [CalendarMonth.Augest] = CalendarMonth.Augest.ToString(),
                [CalendarMonth.September] = CalendarMonth.September.ToString(),
                [CalendarMonth.October] = CalendarMonth.October.ToString(),
                [CalendarMonth.November] = CalendarMonth.November.ToString(),
                [CalendarMonth.December] = CalendarMonth.December.ToString(),
            };
        }

        /// <summary>
        /// Gets or sets the year to display. Default is current year.
        /// </summary>
        [Parameter]public int Year { get; set; }
        /// <summary>
        /// Gets or sets the month to display. Default is current month.
        /// </summary>
        [Parameter] public int Month { get; set; }

        /// <summary>
        /// Gets or sets the view mode of calendar. Default is Date.
        /// </summary>
        [Parameter] public CalendarViewMode ViewMode { get; set; } = CalendarViewMode.Date;

        /// <summary>
        /// Gets or sets the highlight color of today. Default is <see cref="Color.Blue"/>.
        /// </summary>
        [Parameter] public Color? TodayColor { get; set; } = Color.Blue;

        /// <summary>
        /// Gets or sets a delegate that can change the text of <see cref="DayOfWeek"/>.
        /// </summary>
        [Parameter] public Action<IDictionary<DayOfWeek,string>> WeekMapExpression { get; set; }
        /// <summary>
        /// Gets or sets a delegate that can change the text of <see cref="CalendarMonth"/>.
        /// </summary>
        [Parameter] public Action<IDictionary<CalendarMonth, string>> MonthMapExpression { get; set; }
        /// <summary>
        /// Gets or sets a callback that updates the bound value.
        /// </summary>
        [Parameter] public EventCallback<DateTimeOffset?> ValueChanged { get; set; }

        /// <summary>
        /// Gets or sets the value of the input. This should be used with two-way binding.
        /// </summary>
        [Parameter] public DateTimeOffset? Value { get; set; }

        protected int CurrentYear { get; set; }
        protected int CurrentMonth { get; set; }
        protected int CurrentDay { get; set; }
        protected int CurrentHour { get; set; }
        protected int CurrentMinute { get; set; }
        protected int CurrentSecond { get; set; }
        protected IDictionary<DayOfWeek, string> WeekMapper { get;private set; }
        protected IDictionary<CalendarMonth, string> MonthMapper { get;private set; }

        /// <summary>
        /// Gets or sets a value indicating whether adapted inverted background by parent component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if adapted; otherwise, <c>false</c>.
        /// </value>
        [Parameter]public bool Inverted { get; set; }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        protected override void OnParametersSet()
        {
            CurrentYear = Year;
            CurrentMonth = Month;

            WeekMapExpression?.Invoke(WeekMapper);
            MonthMapExpression?.Invoke(MonthMapper);
        }

        /// <summary>
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
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
                    .Add("celled center aligned fixed")
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

        /// <summary>
        /// Builds the head.
        /// </summary>
        /// <param name="builder">The builder.</param>
        void BuildHead(RenderTreeBuilder builder)
        {
            builder.OpenComponent<TableRow>(0);
            builder.AddAttribute(10, nameof(TableRow.ChildContent), (RenderFragment)(tr =>
            {
                BuildTitle(tr);
            }));
            builder.CloseComponent();

            if (new[] { CalendarViewMode.Date, CalendarViewMode.DateTime }.Contains(ViewMode))
            {
                builder.OpenComponent<TableRow>(11);
                builder.AddAttribute(20, nameof(TableRow.ChildContent), (RenderFragment)(tr =>
                {
                    BuildWeekTitle(tr);
                }));
                builder.CloseComponent();
            }

        }

        /// <summary>
        /// Builds the title.
        /// </summary>
        /// <param name="tr">The tr.</param>
        private void BuildTitle(RenderTreeBuilder tr)
        {
            tr.OpenComponent<TableCell>(0);
            
            switch (ViewMode)
            {
                case CalendarViewMode.Year:
                    tr.AddAttribute(1, "colspan", 5);
                    break;
                case CalendarViewMode.Month:
                    tr.AddAttribute(1, "colspan", 3);
                    break;
                case CalendarViewMode.Date:
                    tr.AddAttribute(1, "colspan", DAYS_IN_WEEK);
                    break;
                case CalendarViewMode.Time:
                    break;
                case CalendarViewMode.DateTime:
                    break;
                default:
                    break;
            }
            tr.AddAttribute(9, "Header", true);
            tr.AddAttribute(10, nameof(TableCell.ChildContent), (RenderFragment)(th =>
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

        /// <summary>
        /// Gets the year range.
        /// </summary>
        /// <returns></returns>
        private (int min, int max) GetYearRange()
        {
            var range = (CurrentYear-1) * 0.1;
            var min = (int)Math.Floor(range) * 10 + 1;
            var max = min + MAX_YEAR_RANGE - 1;
            return (min, max);
        }

        /// <summary>
        /// Builds the previous and next.
        /// </summary>
        /// <param name="th">The th.</param>
        /// <param name="prevOrNext">if set to <c>true</c> [previous or next].</param>
        /// <param name="sequence">The sequence.</param>
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
        /// Builds the week title.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildWeekTitle(RenderTreeBuilder builder)
        {
            var weekNames= typeof(DayOfWeek).GetEnumNames();
            foreach (var name in weekNames)
            {
                var week = Enum.Parse<DayOfWeek>(name);
                if(!WeekMapper.TryGetValue(week,out string? value))
                {
                    value = name;
                }


                builder.OpenComponent<TableCell>(0);
                builder.AddAttribute(9, nameof(TableCell.Header), true);
                builder.AddAttribute(10, nameof(TableCell.ChildContent), (RenderFragment)(th =>
                {
                    th.AddContent(0, value);
                }));
                builder.CloseComponent();
            }
        }

        /// <summary>
        /// Builds the body.
        /// </summary>
        /// <param name="builder">The builder.</param>
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

        /// <summary>
        /// Builds the year.
        /// </summary>
        /// <param name="builder">The builder.</param>
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

        /// <summary>
        /// Clicks the previous or next.
        /// </summary>
        /// <param name="prevOrNext">if set to <c>true</c> [previous or next].</param>
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
        /// Builds the year month.
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
                if(!MonthMapper.TryGetValue(month,out string? value))
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
        /// Builds the year month date.
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
                BuildCalendarContent(builder, i, day.ToString(), day, disabled: true);
            }

            var daysInMounth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
            for (int i = 1; i <= daysInMounth; i++)
            {
                var day = i;
                var today = DateTime.Today;

                BuildCalendarContent(builder, i + 500, day.ToString(), day, focus: new DateTime(CurrentYear, CurrentMonth, day) == today);

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
                BuildCalendarContent(builder, i + 100, day.ToString(), day, disabled: true);
            }

            builder.CloseElement();
        }

        /// <summary>
        /// Builds the new line.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="sequence">The sequence.</param>
        private static void BuildNewLine(RenderTreeBuilder builder, int sequence)
        {
            builder.CloseElement();
            builder.OpenElement(sequence, "tr");
        }

        /// <summary>
        /// Builds the content of the calendar.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="sequence">The sequence.</param>
        /// <param name="text">The text.</param>
        /// <param name="value">The value.</param>
        /// <param name="focus">if set to <c>true</c> [focus].</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        void BuildCalendarContent(RenderTreeBuilder builder, int sequence, string text, int value, bool focus = false, bool disabled = false)
        {
            builder.OpenRegion(sequence + 1000);
            builder.OpenElement(0,"td");
            builder.AddAttribute(100 + sequence, "class", Css.Create
                .Add(disabled, "adjacent")
                .Add(focus && TodayColor.HasValue, TodayColor.GetEnumCssClass())
                .Add(CompareCurrent(),"active focus")
                .Add(!disabled, "link"));

            if (!disabled)
            {
                builder.AddAttribute(200 + sequence, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, (e) =>
                {
                    DateTime? clickedValue = default;
                    switch (ViewMode)
                    {
                        case CalendarViewMode.Year:
                            clickedValue = new DateTime(value, 1, 1);
                            break;
                        case CalendarViewMode.Month:
                            clickedValue = new DateTime(CurrentYear, value, 1);
                            break;
                        case CalendarViewMode.Date:
                            clickedValue = new DateTime(CurrentYear, CurrentMonth, value);
                            break;
                        case CalendarViewMode.Time:
                            break;
                        case CalendarViewMode.DateTime:
                            break;
                        default:
                            break;
                    }
                    Value = clickedValue;
                    ValueChanged.InvokeAsync(clickedValue);
                }));
            }
            builder.AddContent(1000 + sequence, text);

            builder.CloseElement();
            builder.CloseRegion();


            bool CompareCurrent()
            {
                if (!Value.HasValue)
                {
                    return false;
                }
                var selectedValue = Value.Value;
                switch (ViewMode)
                {
                    case CalendarViewMode.Year:
                        return selectedValue.Year == value;
                    case CalendarViewMode.Month:
                        return selectedValue.Month == value && selectedValue.Year == CurrentYear;
                    case CalendarViewMode.Date:
                        return selectedValue.Day == value && selectedValue.Year == CurrentYear && selectedValue.Month == CurrentMonth;
                    case CalendarViewMode.Time:
                        break;
                    case CalendarViewMode.DateTime:
                        break;
                    default:
                        return false;
                }
                return false;
            }
        }
    }

    /// <summary>
    /// Defines the view mode of calendar.
    /// </summary>
    public enum CalendarViewMode
    {
        /// <summary>
        /// Display the years only.
        /// </summary>
        Year = 0,
        /// <summary>
        /// Display the years and months.
        /// </summary>
        Month = 1,
        /// <summary>
        /// Display the years, months and dates.
        /// </summary>
        Date = 2,
        /// <summary>
        /// Display time only.
        /// </summary>
        Time = 3,
        /// <summary>
        /// Display date and time.
        /// </summary>
        DateTime = 4,
    }

    /// <summary>
    /// Defines the calendar months.
    /// </summary>
    public enum CalendarMonth
    {
        /// <summary>
        /// Janurary.
        /// </summary>
        Janurary = 1,
        /// <summary>
        /// February.
        /// </summary>
        February = 2,
        /// <summary>
        /// March.
        /// </summary>
        March = 3,
        /// <summary>
        /// April.
        /// </summary>
        April = 4,
        /// <summary>
        /// May.
        /// </summary>
        May = 5,
        /// <summary>
        /// June.
        /// </summary>
        June = 6,
        /// <summary>
        /// July.
        /// </summary>
        July = 7,
        /// <summary>
        /// Augest.
        /// </summary>
        Augest = 8,
        /// <summary>
        /// September.
        /// </summary>
        September = 9,
        /// <summary>
        /// October.
        /// </summary>
        October = 10,
        /// <summary>
        /// November.
        /// </summary>
        November = 11,
        /// <summary>
        /// December.
        /// </summary>
        December = 12
    }
}
