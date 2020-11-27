using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示结合 <see cref="Menu"/> 元素呈现分页的功能，并提供相应的交互。
    /// </summary>
    /// <seealso cref="Blamantic.Abstractions.BlamanticComponentBase" />
    public class Pagination:BlamanticComponentBase
    {
        /// <summary>
        /// 设置当前页码。
        /// </summary>
        [Parameter] public int CurrentPage { get; set; }
        /// <summary>
        /// 设置每一页呈现的数据量。默认使用 <see cref="PageSizeStakeholders"/> 的第1个元素。
        /// <para>
        /// 在使用双向绑定支持时，建议只获取而不修改，以免造成与 <see cref="PageSizeStakeholders"/> 值不匹配的问题。
        /// </para>
        /// </summary>

        [Parameter] public int PageSize { get; set; }

        /// <summary>
        /// 设置每页数据量的下拉候选项，至少有一个元素。默认是10, 20, 30, 50, 100。
        /// </summary>
        [Parameter] public IReadOnlyList<int> PageSizeStakeholders { get; set; } = new[] { 10, 20, 30, 50, 100 };
        /// <summary>
        /// 设置数据的总记录数。
        /// </summary>
        [Parameter] public int TotalCount { get; set; }
        /// <summary>
        /// 设置显示页码的个数，范围是5-21的奇数。默认是 7 个。
        /// </summary>
        [Parameter] public int PageNumberCount { get; set; } = 7;
        /// <summary>
        /// 设置一个布尔值，表示是否显示总记录数统计，默认是 <c>true</c>。
        /// </summary>
        [Parameter] public bool ShowTotalCount { get; set; } = true;

        /// <summary>
        /// 设置一个布尔值，表示是否显示“跳转到”的组件。默认是 <c>true</c>。
        /// </summary> 
        [Parameter] public bool ShowNavigateTo { get; set; } = true;

        /// <summary>
        /// 设置分页的尺寸。
        /// </summary>
        [Parameter] public Size? Size { get; set; }

        /// <summary>
        /// 设置分页的对齐方式。
        /// </summary>
        [Parameter] public JustifyContent Alignment { get; set; } = JustifyContent.Around;

        /// <summary>
        /// 设置当 <see cref="CurrentPage"/> 发生改变后的回调方法。
        /// </summary>
        [Parameter] public EventCallback<int> OnCurrentPageChanged { get; set; }

        /// <summary>
        /// 表示使用 <c>@bind-CurrentPage</c> 双向绑定指令的回调方法。
        /// </summary>
        [Parameter] public EventCallback<int> CurrentPageChanged { get; set; }
        /// <summary>
        /// 表示使用 <c>@bind-PageSize</c> 双向绑定指令的回调方法。
        /// </summary>
        [Parameter] public EventCallback<int> PageSizeChanged { get; set; }
        /// <summary>
        /// 表示使用 <c>@bind-TotalCount</c> 双向绑定指令的回调方法。
        /// </summary>
        [Parameter] public EventCallback<int> TotalCountChanged { get; set; }

        /// <summary>
        /// 获取总页数。
        /// </summary>
        public int TotalPages => (TotalCount + PageSize - 1) / PageSize;


        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// 不能小于1 - CurrentPage
        /// or
        /// 不能小于1 - TotalCount
        /// or
        /// 至少要有1个候选项 - PageSizeStakeholders
        /// </exception>
        protected override void OnInitialized()
        {
            if (CurrentPage <= 0)
            {
                throw new ArgumentException("不能小于1", nameof(CurrentPage));
            }

            if (TotalCount <= 0)
            {
                throw new ArgumentException("不能小于1", nameof(TotalCount));
            }

            if (PageSizeStakeholders == null || !PageSizeStakeholders.Any())
            {
                throw new ArgumentException("至少要有1个候选项", nameof(PageSizeStakeholders));
            }
            PageSize = PageSizeStakeholders.First();
            base.OnInitialized();
        }

        /// <summary>
        /// 构造分页组件。
        /// </summary>
        /// <param name="root"><see cref="RenderTreeBuilder"/> 实例。</param>
        protected override void BuildRenderTree(RenderTreeBuilder root)
        {
            root.OpenElement(0, "div");
            root.AddAttribute(1, "style", $"display:flex;flex-direction:row;justify-content:{Alignment.GetEnumMemberValue<DefaultValueAttribute>()}");
            root.AddContent(2, builder =>
            {
                if (ShowTotalCount)
                {
                    builder.OpenComponent<InputBox>(0);
                    builder.AddAttribute(1, nameof(InputBox.Size), Size);
                    builder.AddAttribute(2, nameof(InputBox.ChildContent), (RenderFragment)(input =>
                    {
                        input.OpenElement(0, "label");
                        input.AddAttribute(1, "style", "display:flex;align-items:center;margin-right:5px");
                        input.AddContent(5, $"共 {TotalCount} 条");
                        input.CloseElement();
                    }));
                    builder.CloseComponent();
                }

                builder.OpenComponent<Menu>(10);
                builder.AddAttribute(11, nameof(Menu.Pagination), true);
                builder.AddAttribute(12, nameof(Menu.Size), Size);
                builder.AddAttribute(13, nameof(Menu.Linked), true);
                BuildPaginationPart(builder);
                builder.CloseComponent();

                if (ShowNavigateTo)
                {
                    BuildPageSizeForm(builder);
                }


            });
            root.CloseElement();

            

            void BuildPaginationPart(RenderTreeBuilder builder)
            {
                #region 分页项
                builder.AddAttribute(10, nameof(Menu.ChildContent), (RenderFragment)(item =>
                {


                    #region 第一个页码（首页）
                    if (CurrentPage <= 1)
                    {
                        BuildPageItem(item, 10, 1, 1, disabled: true, active: true);
                    }
                    else
                    {
                        #region 上一页
                        BuildPageItem(item, 1, "<<", "上一页", NavigateToPrevious);
                        #endregion

                        BuildPageItem(item, 10, 1, 1, NavigateToFirst);
                    }
                    #endregion

                    #region 后退5页
                    if (CurrentPage > PageNumberCount / 2)
                    {
                        var backTo = PageNumberCount - 5;
                        if (backTo <= 1)
                        {
                            backTo = 1;
                        }
                        BuildPageItem(item, 20, "...", "后退5页", () => NavigateToPage(backTo));
                    }
                    #endregion

                    #region 分页数字
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

                    #region 前进5页
                    if (CurrentPage < TotalPages - PageNumberCount / 2)
                    {
                        var nextTo = CurrentPage + 5;
                        if (nextTo >= TotalPages)
                        {
                            nextTo = TotalPages;
                        }
                        BuildPageItem(item, 20, "...", "前进5页", () => NavigateToPage(nextTo));
                    }
                    #endregion

                    #region 最后一个页码(末页)
                    if (TotalPages > 1)
                    {
                        if (CurrentPage >= TotalPages)
                        {
                            BuildPageItem(item, 90, TotalPages, TotalPages, disabled: true, active: true);
                        }
                        else
                        {
                            BuildPageItem(item, 90, TotalPages, TotalPages, NavigateToLast);

                            #region  下一页
                            BuildPageItem(item, 100, ">>", "下一页", NavigateToNext);
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
                                 #region 数据呈现候选下拉菜单
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
                                                    select.AddContent(i, $"{value}/页");
                                                    select.CloseElement();
                                                }
                                            }));
                                         input.CloseElement();
                                     }));
                                 field.CloseComponent();
                                 #endregion

                                 #region 跳转到

                                 field.OpenComponent<InputBox>(10);
                                 field.AddAttribute(11, nameof(InputBox.Size), Size);                                 
                                 field.AddAttribute(18, nameof(InputBox.ChildContent), (RenderFragment)(input =>
                                   {
                                       input.OpenElement(0, "label");
                                       input.AddAttribute(1, "style", "display:flex;align-items:center");
                                       input.AddContent(6, "跳转到");
                                       input.CloseElement();

                                       input.OpenElement(10, "input");
                                       input.AddAttribute(11, "style", "text-align:center;width:60px");
                                       input.AddAttribute(14, "onchange", EventCallback.Factory.Create<ChangeEventArgs>(this, RedirectToSpecifyPage));
                                       input.CloseElement();
                                   }));
                                 field.CloseComponent();
                                 #endregion
                             }));
                           form.CloseComponent();
                       });
                  }));
                builder.CloseComponent();
            }
        }



        /// <summary>
        /// 导航到首页。
        /// </summary>
        public Task NavigateToFirst() => ChangeCurrentPage(1);

        /// <summary>
        /// 导航到上一页。
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
        /// 导航到下一页。
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
        /// 导航到末页。
        /// </summary>
        public Task NavigateToLast() => ChangeCurrentPage(TotalPages);

        /// <summary>
        /// 导航到自定义页。
        /// </summary>
        /// <param name="page">要导航的页。</param>
        public Task NavigateToPage(int page) => ChangeCurrentPage(page);

        /// <summary>
        /// 变更当前分页的页码，并触发 <see cref="CurrentPageChanged"/> 事件。
        /// </summary>
        /// <param name="page">要设置的分页页码。</param>
        async Task ChangeCurrentPage(int page)
        {
            CurrentPage = page;
            await CurrentPageChanged.InvokeAsync(page);
            await OnCurrentPageChanged.InvokeAsync(page);
        }

        /// <summary>
        /// 变更每页的呈现的数据，并触发 <see cref="PageSizeChanged"/> 事件。
        /// </summary>
        /// <param name="size">每页呈现的数据。</param>
        async Task ChangePageSize(int size)
        {
            await NavigateToFirst();
            PageSize = size;
            await PageSizeChanged.InvokeAsync(size);
        }

        /// <summary>
        /// 选择每页呈现的数据量选项。
        /// </summary>
        /// <param name="selectedItem">选择的项。</param>
        async Task SelectPageSize(object selectedItem)
        {
            if (!int.TryParse(selectedItem.ToString(), out int size))
            {
                size = PageSizeStakeholders[0];
            }

            await ChangePageSize(size);
        }

        /// <summary>
        /// 跳转到指定的页面
        /// </summary>
        /// <param name="e">The <see cref="ChangeEventArgs"/> instance containing the event data.</param>        
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
        /// 变更分页的总记录数，并触发 <see cref="TotalCountChanged"/> 事件。
        /// </summary>
        /// <param name="count">要变更的总记录数。</param>
        async Task ChangeTotalCount(int count)
        {
            await NavigateToFirst();
            TotalCount = count;
            await TotalCountChanged.InvokeAsync(count);
        }

        /// <summary>
        /// 计算分页数字并返回开始和结束的索引。
        /// </summary>
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
        /// 设置 Flex 的横向布局模式。
        /// </summary>
        public enum JustifyContent
        {
            /// <summary>
            /// 居左。
            /// </summary>
            [DefaultValue("left")]
            Left,
            /// <summary>
            /// 居右。
            /// </summary>
            [DefaultValue("right")]
            Right,
            /// <summary>
            /// 居中。
            /// </summary>
            [DefaultValue("center")]
            Center,
            /// <summary>
            /// 两端。
            /// </summary>
            [DefaultValue("space-between")]
            Between,
            /// <summary>
            /// 环绕。
            /// </summary>
            [DefaultValue("space-around")]
            Around
        }
    }
}
