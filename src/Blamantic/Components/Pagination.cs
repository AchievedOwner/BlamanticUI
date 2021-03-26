using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a pagination component using by <see cref="Menu"/> component.
    /// </summary>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    public class Pagination : BlamanticComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pagination"/> class.
        /// </summary>
        public Pagination()
        {

        }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        [Parameter] public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the size of the page. Default is the first element of <see cref="PageSizeStakeholders"/>.
        /// </summary>
        [Parameter] public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the page size stakeholders. Default is 10 20 30 50 100.
        /// </summary>
        [Parameter] public IReadOnlyList<int> PageSizeStakeholders { get; set; } = new[] { 10, 20, 30, 50, 100 };
        /// <summary>
        /// Gets or sets the total count of data source.
        /// </summary>
        [Parameter] public int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets the page number count that must a even number from 5 to 21. Default is 7.
        /// </summary>
        [Parameter] public int PageNumberCount { get; set; } = 7;
        /// <summary>
        /// Gets or sets a value to show statistic label. Default is <c>true</c>.
        /// </summary>
        [Parameter] public bool ShowStatistic { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to show 'navigate to'. Default is <c>true</c>.
        /// </summary>
        [Parameter] public bool ShowNavigateTo { get; set; } = true;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter] public Size? Size { get; set; }

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        [Parameter] public JustifyContent Alignment { get; set; } = JustifyContent.Around;

        /// <summary>
        /// A callback method invoked when <see cref="CurrentPage"/> changed.
        /// </summary>
        [Parameter] public EventCallback<int> OnCurrentPageChanged { get; set; }

        /// <summary>
        /// A callback method invoked when <see cref="CurrentPage"/> changed.
        /// </summary>
        [Parameter] public EventCallback<int> CurrentPageChanged { get; set; }
        /// <summary>
        /// A callback method invoked when <see cref="PageSize"/> changed.
        /// </summary>
        [Parameter] public EventCallback<int> PageSizeChanged { get; set; }
        /// <summary>
        /// A callback method invoked when <see cref="TotalCount"/> changed.
        /// </summary>
        [Parameter] public EventCallback<int> TotalCountChanged { get; set; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        public int TotalPages
        {
            get
            {
                var total = TotalCount + PageSize - 1;
                if (total <= 0)
                {
                    total = 1;
                }

                var result = total  / PageSize;
                if (result < 0)
                {
                    result = 1;
                }
                return result;
            }
        }


        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// At lease one element - PageSizeStakeholders
        /// </exception>
        protected override void OnInitialized()
        {
            //if (CurrentPage <= 0)
            //{
            //    throw new ArgumentException("Must greater than 1", nameof(CurrentPage));
            //}

            //if (TotalCount <= 0)
            //{
            //    throw new ArgumentException("Must greater than 1", nameof(TotalCount));
            //}

            if (PageSizeStakeholders == null || !PageSizeStakeholders.Any())
            {
                throw new ArgumentException("At lease one element", nameof(PageSizeStakeholders));
            }
            PageSize = PageSizeStakeholders[0];
            base.OnInitialized();
        }

        /// <summary>
        /// Builds the render tree.
        /// </summary>
        /// <param name="root">The root.</param>
        protected override void BuildRenderTree(RenderTreeBuilder root)
        {
            root.OpenElement(0, "div");
            root.AddAttribute(1, "style", $"display:flex;flex-direction:row;justify-content:{Alignment.GetEnumMemberValue<DefaultValueAttribute>()}");
            root.AddContent(2, builder =>
            {
                BuildStatistic(builder);

                builder.OpenComponent<Menu>(10);
                builder.AddAttribute(11, nameof(Menu.Pagination), true);
                builder.AddAttribute(12, nameof(Menu.Size), Size);
                builder.AddAttribute(13, nameof(Menu.Linked), true);
                BuildPaginationPart(builder);
                builder.CloseComponent();

                    BuildPageSizeForm(builder);
            });
            root.CloseElement();            

            void BuildPaginationPart(RenderTreeBuilder builder)
            {
                #region Pager
                builder.AddAttribute(10, nameof(Menu.ChildContent), (RenderFragment)(item =>
                {
                    #region First page
                    if (CurrentPage <= 1)
                    {
                        BuildPageItem(item, 10, 1, 1, disabled: true, active: true);
                    }
                    else
                    {
                        #region Previous
                        BuildPageItem(item, 1, "<<", "Previous", NavigateToPrevious);
                        #endregion

                        BuildPageItem(item, 10, 1, 1, NavigateToFirst);
                    }
                    #endregion

                    #region Next 5 pages
                    if (CurrentPage > PageNumberCount / 2)
                    {
                        var backTo = PageNumberCount - 5;
                        if (backTo <= 1)
                        {
                            backTo = 1;
                        }
                        BuildPageItem(item, 20, "...", "Next 5 pages", () => NavigateToPage(backTo));
                    }
                    #endregion

                    #region Page Number
                    var (start, end) = ComputePageNumber();
                    for (int i = start + 1; i <= end - 1; i++)
                    {
                        var current = i;
                        var sequence = i + 30;
                        if (CurrentPage == current)
                        {
                            BuildPageItem(item, sequence, current, current, disabled: true, active: true);
                        }
                        else
                        {
                            BuildPageItem(item, sequence, current, current, () => NavigateToPage(current));
                        }
                    }
                    #endregion

                    #region Previous 5 page
                    if (CurrentPage < TotalPages - PageNumberCount / 2)
                    {
                        var nextTo = CurrentPage + 5;
                        if (nextTo >= TotalPages)
                        {
                            nextTo = TotalPages;
                        }
                        BuildPageItem(item, 20, "...", "Previous 5 pages", () => NavigateToPage(nextTo));
                    }
                    #endregion

                    #region Last page
                    if (TotalPages > 1)
                    {
                        if (CurrentPage >= TotalPages)
                        {
                            BuildPageItem(item, 90, TotalPages, TotalPages, disabled: true, active: true);
                        }
                        else
                        {
                            BuildPageItem(item, 90, TotalPages, TotalPages, NavigateToLast);

                            #region  Next page
                            BuildPageItem(item, 100, ">>", "Next", NavigateToNext);
                            #endregion
                        }
                    }
                    #endregion
                }));
                #endregion

                void BuildPageItem(RenderTreeBuilder builder, int sequence, object content, object title, Func<Task> callback = default, bool disabled = false, bool active = false)
                {
                    builder.OpenComponent<Item>(sequence);
                    builder.AddAttribute(sequence + 1, "title", title);
                    builder.AddAttribute(sequence + 2, nameof(Item.Disabled), disabled);
                    builder.AddAttribute(sequence + 3, nameof(Item.Actived), disabled);
                    if (callback != null)
                    {
                        builder.AddAttribute(sequence + 5, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, callback));
                    }
                    builder.AddAttribute(sequence + 8, nameof(Item.ChildContent), (RenderFragment)(child => child.AddContent(0, content.ToString())));
                    builder.CloseComponent();
                }
            }

            void BuildPageSizeForm(RenderTreeBuilder builder)
            {
                builder.OpenComponent<Form>(20);
                builder.AddAttribute(21, nameof(Form.Model), this);
                builder.AddAttribute(22, "style", "margin-left:5px");
                builder.AddAttribute(23, nameof(Form.ChildContent), (RenderFragment<EditContext>)(child =>
                  {
                      return new RenderFragment(form =>
                       {
                           form.OpenComponent<Field>(0);
                           form.AddAttribute(1, nameof(Field.Inline), true);
                           form.AddAttribute(2, nameof(Field.ChildContent), (RenderFragment)(field =>
                             {
                                 #region Dropdown Page Size
                                 field.OpenComponent<InputBox>(0);
                                 field.AddAttribute(1, nameof(InputBox.Size), Size);
                                 field.AddAttribute(2, nameof(InputBox.ChildContent), (RenderFragment)(input =>
                                     {
                                         input.OpenElement(0, "select");
                                         input.AddAttribute(1, "onchange", EventCallback.Factory.Create<ChangeEventArgs>(this, (e) => SelectPageSize(e.Value)));
                                         input.AddContent(5, (select =>
                                            {
                                                for (int i = 0; i < PageSizeStakeholders.Count; i++)
                                                {
                                                    var value = PageSizeStakeholders[i];
                                                    select.OpenElement(i, "option");
                                                    select.AddAttribute(i, "value", value);
                                                    select.AddContent(i, $"{value}");
                                                    select.CloseElement();
                                                }
                                            }));
                                         input.CloseElement();
                                     }));
                                 field.CloseComponent();
                                 #endregion

                                 #region Navigate to

                                 if (ShowNavigateTo)
                                 {
                                     field.OpenComponent<InputBox>(10);
                                     field.AddAttribute(11, nameof(InputBox.Size), Size);
                                     field.AddAttribute(18, nameof(InputBox.ChildContent), (RenderFragment)(input =>
                                       {
                                           input.OpenElement(0, "label");
                                           input.AddAttribute(1, "style", "display:flex;align-items:center");
                                           input.AddContent(6, "Navigate To");
                                           input.CloseElement();

                                           input.OpenElement(10, "input");
                                           input.AddAttribute(11, "style", "text-align:center;width:60px");
                                           input.AddAttribute(14, "onchange", EventCallback.Factory.Create<ChangeEventArgs>(this, RedirectToSpecifyPage));
                                           input.CloseElement();
                                       }));
                                     field.CloseComponent();
                                 }
                                 #endregion
                             }));
                           form.CloseComponent();
                       });
                  }));
                builder.CloseComponent();
            }
        }

        private void BuildStatistic(RenderTreeBuilder builder)
        {
            if (ShowStatistic)
            {
                builder.OpenComponent<InputBox>(0);
                builder.AddAttribute(1, nameof(InputBox.Size), Size);
                builder.AddAttribute(2, nameof(InputBox.ChildContent), (RenderFragment)(input =>
                {
                    input.OpenElement(0, "label");
                    input.AddAttribute(1, "style", "display:flex;align-items:center;margin-right:5px");
                    input.AddContent(5, $"{PageSize} of {TotalCount} Items");
                    input.CloseElement();
                }));
                builder.CloseComponent();
            }
        }


        /// <summary>
        /// Navigates to first.
        /// </summary>
        public Task NavigateToFirst() => ChangeCurrentPage(1);

        /// <summary>
        /// Navigates to previous.
        /// </summary>
        public async Task NavigateToPrevious()
        {
            if (CurrentPage <= 1)
            {
                CurrentPage = 1;
            }
            else
            {
                CurrentPage--;
            }
            await ChangeCurrentPage(CurrentPage);
        }

        /// <summary>
        /// Navigates to next.
        /// </summary>
        public async Task NavigateToNext()
        {
            if (CurrentPage >= TotalPages)
            {
                CurrentPage = TotalPages;
            }
            else
            {
                CurrentPage++;
            }
            await ChangeCurrentPage(CurrentPage);
        }

        /// <summary>
        /// Navigates to last.
        /// </summary>
        /// <returns></returns>
        public Task NavigateToLast() => ChangeCurrentPage(TotalPages);

        /// <summary>
        /// Navigates to specify page.
        /// </summary>
        /// <param name="page">The page to navigate.</param>
        public Task NavigateToPage(int page) => ChangeCurrentPage(page);

        /// <summary>
        /// Changes the current page.
        /// </summary>
        /// <param name="page">The page.</param>
        async Task ChangeCurrentPage(int page)
        {
            CurrentPage = page;
            await CurrentPageChanged.InvokeAsync(page);
            await OnCurrentPageChanged.InvokeAsync(page);
        }

        /// <summary>
        /// Changes the size of the page.
        /// </summary>
        /// <param name="size">The size.</param>
        async Task ChangePageSize(int size)
        {
            await NavigateToFirst();
            PageSize = size;
            await PageSizeChanged.InvokeAsync(size);
        }

        /// <summary>
        /// Selects the size of the page.
        /// </summary>
        /// <param name="selectedItem">The selected item.</param>
        async Task SelectPageSize(object selectedItem)
        {
            if (!int.TryParse(selectedItem.ToString(), out int size))
            {
                size = PageSizeStakeholders[0];
            }

            await ChangePageSize(size);
        }

        /// <summary>
        /// Redirects to specify page.
        /// </summary>
        /// <param name="e">The <see cref="ChangeEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        Task RedirectToSpecifyPage(ChangeEventArgs e)
        {
            var page = 1;
            if (!string.IsNullOrWhiteSpace(e.Value?.ToString()))
            {
                page = Convert.ToInt32(e.Value);
            }
            return NavigateToPage(page);
        }

        /// <summary>
        /// Changes the total count.
        /// </summary>
        /// <param name="count">The count.</param>
        async Task ChangeTotalCount(int count)
        {
            await NavigateToFirst();
            TotalCount = count;
            await TotalCountChanged.InvokeAsync(count);
        }

        /// <summary>
        /// Computes the page number.
        /// </summary>
        /// <returns></returns>
        (int start, int end) ComputePageNumber()
        {
            var start = 0;
            var end = 0;

            var middle = PageNumberCount / 2;
            if (CurrentPage <= middle)
            {
                start = 1;
                end = PageNumberCount;
            }
            else if (CurrentPage > middle)
            {
                start = CurrentPage - middle;
                end = CurrentPage + middle;
            }
            if (end > TotalPages)
            {
                end = TotalPages;
                if (start + end != PageNumberCount - 2)
                {
                    start = end - PageNumberCount + 2 - 1;
                }
            }
            if (end <= PageNumberCount)
            {
                start = 1;
            }

            return (start, end);
        }

        /// <summary>
        /// Defiens the layout of flex.
        /// </summary>
        public enum JustifyContent
        {
            /// <summary>
            /// Left of content.
            /// </summary>
            [DefaultValue("left")]
            Left,
            /// <summary>
            /// Right of content.
            /// </summary>
            [DefaultValue("right")]
            Right,
            /// <summary>
            /// Cneter of content.
            /// </summary>
            [DefaultValue("center")]
            Center,
            /// <summary>
            /// Between of content.
            /// </summary>
            [DefaultValue("space-between")]
            Between,
            /// <summary>
            /// Around of content.
            /// </summary>
            [DefaultValue("space-around")]
            Around
        }
    }
}
