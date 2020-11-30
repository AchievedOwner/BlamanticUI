using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Blamantic.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using YoiBlazor;

namespace Blamantic
{
    /// <summary>
    /// 表示多功能的下拉列表。
    /// </summary>
    /// <typeparam name="T">The type of the source.</typeparam>
    /// <seealso cref="Blamantic.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="Blamantic.Abstractions.IHasUIComponent" />
    /// <seealso cref="Blamantic.Abstractions.IHasSelectable" />
    /// <seealso cref="Blamantic.Abstractions.IHasFluid" />
    public class DropDownList<T> : BlamanticComponentBase,IDisposable,
        IHasUIComponent, 
        IHasSelectable, 
        IHasFluid, 
        IHasStateToggle,
        IHasActive,
        IHasSize,
        IHasCompact,
        IHasInverted,
        IHasSpan,
        IHasInline
    {
        private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
        /// <summary>
        /// 初始化 <see cref="DropDownList{T}"/> 类的新实例。
        /// </summary>
        public DropDownList()
        {
            Selectable = true;
            FilterExpression = CompareSearchValue;
            _validationStateChangedHandler = (s, e) => StateHasChanged();
        }

        #region 参数
        /// <summary>
        /// 设置是否具有选择样式。
        /// </summary>
        [Parameter] [CssClass("selection")] public bool Selectable { get; set; }

        /// <summary>
        /// 设置对数据源是否可以直接进行过滤。
        /// </summary>
        [Parameter] [CssClass("search")] public bool Filterable { get; set; }

        /// <summary>
        /// 设置菜单向上显示。
        /// </summary>
        [Parameter] [CssClass("upward")]public bool Up { get; set; }

        /// <summary>
        /// 设置成流式布局并把宽度设置为 100% 以此撑满整个父元素。
        /// </summary>
        [Parameter] public bool Fluid { get; set; }

        /// <summary>
        /// 设置是否显示列表。
        /// </summary>
        [Parameter] [CssClass("active")] public bool Actived { get; set; }

        /// <summary>
        /// 当数据源是复杂类型（通常是实体）时，用于指定过滤的字段。未指定 <see cref="FilterExpression"/> 时有效。
        /// </summary>
        [Parameter] public string FilterField { get; set; }

        /// <summary>
        /// 设置当选择项后显示一个“x”可移除选中项。
        /// </summary>
        [Parameter] public bool Removable { get; set; }

        /// <summary>
        /// 设置是否禁用。
        /// </summary>
        [Parameter] public bool Disabled { get; set; }
        /// <summary>
        /// 设置尺寸大小。
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// 设置反转背景。
        /// </summary>
        [Parameter] public bool Inverted { get; set; }
        /// <summary>
        /// 设置内边距的压缩。
        /// </summary>
        [Parameter] public bool Compact { get; set; }

        /// <summary>
        /// 设置在搜索候选列表中的最大数量。默认是 10。
        /// </summary>
        [Parameter] public int MaxFilterItems { get; set; } = 10;
        /// <summary>
        /// 设置下拉列表的列数排版。
        /// </summary>
        [Parameter] [CssClass(" column", Suffix = true)] public Span? Span { get; set; }
        /// <summary>
        /// 设置成为行内样式模式。
        /// </summary>
        [Parameter] public bool Inline { get; set; }

        /// <summary>
        /// 设置初始化时的默认项 UI 内容。
        /// </summary>
        [Parameter] public RenderFragment DefaultItem { get; set; }
        /// <summary>
        /// 设置对列表项呈现的 UI 内容。
        /// </summary>
        [Parameter] public RenderFragment<T> ItemFormat { get; set; }

        /// <summary>
        /// 设置选中项的值。
        /// </summary>
        [Parameter] public string Value { get; set; }
        /// <summary>
        /// 设置当选中值更改后触发的回调。
        /// </summary>
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        /// <summary>
        /// 表示双向绑定的表达式。
        /// </summary>
        [Parameter]public Expression<Func<string>> ValueExpression { get; set; }

        /// <summary>
        /// 表示用于自定义搜索数据的表达式。
        /// <para>
        /// 参数1：搜索框键入的文本；参数2：数据源中每一行的类型；返回 <c>true</c> 则为匹配过滤的结果，否则为 <c>false</c>。
        /// </para>
        /// </summary>
        [Parameter] public Func<string, T, bool> FilterExpression { get; set; }

        /// <summary>
        /// 级联 <see cref="EditContext"/> 参数，可以结合 <see cref="Form"/> 对控件进行验证。
        /// </summary>
        [CascadingParameter]EditContext CascadedEditContext { get; set; }


        /// <summary>
        /// 表示已过滤的数据源。
        /// </summary>
        protected IEnumerable<T> FilterdDataSource { get;private set; }
        #endregion

        /// <summary>
        /// 获取一个布尔值，表示搜索过滤已经输入了内容。
        /// </summary>
        protected bool Filtered { get; private set; }

        /// <summary>
        /// 表示搜索框已输入的值。
        /// </summary>
        protected string FilterdInputValue { get; private set; }

        /// <summary>
        /// 获取经过双向绑定之后的当前值。
        /// </summary>
        protected string CurrentValue
        {
            get => Value;
            set
            {
                var hasChanged = !EqualityComparer<string>.Default.Equals(value, Value);
                if (hasChanged)
                {
                    Value = value;
                    ValueChanged.InvokeAsync(value);
                    if (CascadedEditContext != null)
                    {
                        var fieldIdentifier = FieldIdentifier.Create(ValueExpression);
                        CascadedEditContext.NotifyFieldChanged(fieldIdentifier);
                    }
                }
            }
        }

        /// <summary>
        /// 获取或设置列表中选中的项。
        /// </summary>
        T SelectedItem { get; set; }
        


        /// <summary>
        /// 设置当下拉列表显示或隐藏时触发的回调方法。
        /// </summary>
        [Parameter] public EventCallback<bool> OnActive { get; set; }
        /// <summary>
        /// 设置下拉列表的数据源。
        /// </summary>
        [Parameter] public IEnumerable<T> DataSource { get; set; }

        /// <summary>
        /// 设置当列表项被选中后触发的回调方法。
        /// </summary>
        [Parameter] public EventCallback<T> OnItemSelected { get; set; }

        /// <summary>
        /// 设置当输入过滤值时触发的回调方法。
        /// </summary>
        [Parameter] public EventCallback<string> OnFiltering { get; set; }
        public EventCallback<bool> OnActived { get; set; }

        /// <summary>
        /// Method invoked when the component has received parameters from its parent in
        /// the render tree, and the incoming values have been assigned to properties.
        /// </summary>
        /// <exception cref="ArgumentNullException">DataSource</exception>
        protected override void OnParametersSet()
        {
            if (DataSource == null)
            {
                throw new ArgumentNullException(nameof(DataSource));
            }
            if (ItemFormat == null)
            {
                ItemFormat = value => new RenderFragment(builder => builder.AddContent(0, value?.ToString()));
            }

            if (CascadedEditContext != null)
            {
                CascadedEditContext.OnValidationStateChanged += _validationStateChangedHandler;
            }
        }

        /// <summary>
        /// Method invoked after each time the component has been rendered. Note that the component does
        /// not automatically re-render after the completion of any returned <see cref="T:System.Threading.Tasks.Task" />, because
        /// that would cause an infinite render loop.
        /// </summary>
        /// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
        /// on this component instance; otherwise <c>false</c>.</param>
        /// <remarks>
        /// The <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> and <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)" /> lifecycle methods
        /// are useful for performing interop, or interacting with values recieved from <c>@ref</c>.
        /// Use the <paramref name="firstRender" /> parameter to ensure that initialization work is only performed
        /// once.
        /// </remarks>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Search(null);
            }
        }

        /// <summary>
        /// 创建组件所需要的 class 类。
        /// </summary>
        /// <param name="css"><see cref="T:YoiBlazor.Css" /> 实例。</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add(Actived, "visible").Add(Removable, "clearable").Add("dropdown");
        }

        /// <summary>
        /// Renders the component to the supplied <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" />.
        /// </summary>
        /// <param name="builder">A <see cref="T:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder" /> that will receive the render output.</param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            if (!Disabled)
            {
                builder.AddAttribute(1, "tabindex", 1);
                builder.AddAttribute(2, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, () => Toggle()));
                builder.AddAttribute(3, "onblur", EventCallback.Factory.Create<FocusEventArgs>(this, () => this.Active(false)));
            }
            AddElementReference(builder);
            
            builder.AddContent(5, child =>
            {
                BuildDefaultText(child);
                BuildDropdownIcon(child);
                BuildRemoveIcon(child);
                BuildSearchInput(child);
                BuildDropDownItems(child);

            });


            builder.CloseElement();
        }

        private void BuildRemoveIcon(RenderTreeBuilder child)
        {
            if (Removable && SelectedItem != null)
            {
                child.OpenComponent<Icon>(40);
                child.AddAttribute(41, nameof(Icon.IconClass), "remove");
                child.AddAttribute(42, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, () => SelectItem(default)));
                child.AddEventStopPropagationAttribute(44, "onclick", true);
                child.CloseComponent();
            }
        }

        /// <summary>
        /// 构建搜索框。
        /// </summary>
        /// <param name="child"></param>
        private void BuildSearchInput(RenderTreeBuilder child)
        {
            if (Filterable)
            {
                child.OpenElement(30, "input");
                child.AddAttribute(31, "class", "search");
                child.AddAttribute(32, "value", FilterdInputValue);
                child.AddAttribute(35, "oninput", EventCallback.Factory.Create<ChangeEventArgs>(this, e => Search(e.Value?.ToString())));
                child.CloseElement();
            }
        }

        /// <summary>
        /// 构建下拉图标。
        /// </summary>
        /// <param name="child"></param>
        private static void BuildDropdownIcon(RenderTreeBuilder child)
        {
            child.OpenComponent<Icon>(20);
            child.AddAttribute(21, nameof(Icon.IconClass), "dropdown");
            child.CloseComponent();
        }

        /// <summary>
        /// 构建默认文本。
        /// </summary>
        /// <param name="child"></param>
        private void BuildDefaultText(RenderTreeBuilder child)
        {
            child.OpenElement(10, "div");
            child.AddAttribute(11, "class", BuildCssClass());

            if (SelectedItem != null)
            {
                child.AddContent(17, ItemFormat(SelectedItem));
            }
            else
            {
                if (DefaultItem != null)
                {
                    child.AddContent(17, DefaultItem);
                }
                else
                {
                    var defaulValue = DataSource.FirstOrDefault();
                    SelectItem(defaulValue).GetAwaiter().GetResult();
                    child.AddContent(17, ItemFormat(defaulValue));
                }
            }
            child.CloseElement();

            string BuildCssClass()
            {
                var list = new List<string>();

                if (DefaultItem != null && CurrentValue == null)
                {
                    list.Add("default");
                }

                if (Filtered)
                {
                    list.Add("filtered");
                }
                list.Add("text");
                return string.Join(" ", list);
            }
        }

        /// <summary>
        /// 构造下拉菜单项。
        /// </summary>
        /// <param name="builder">The builder.</param>
        void BuildDropDownItems(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Menu>(0);
            builder.AddAttribute(1, nameof(Menu.UI), false);

            builder.AddAttribute(2, nameof(Menu.AdditionalStyles), (StyleCollection)(Style.Create.Add( Actived,"display","block")));
            builder.AddAttribute(3, nameof(Menu.AdditionalCssClass), (CssClassCollection)( Actived ? "visible" : "hidden"));
            builder.AddAttribute(10, nameof(Menu.ChildContent), (RenderFragment)(menu =>
              {
                  var sequence = 0;
                  var i = 0;
                  if (FilterdDataSource != null)
                  {
                      foreach (var source in FilterdDataSource.Take(MaxFilterItems))
                      {
                          var index = i;
                          menu.OpenComponent<Item>(sequence + i);
                          menu.SetKey(index);
                          menu.AddAttribute( 1, nameof(Item.AdditionalCssClass), (CssClassCollection)BuildMenuItemCssClass(source));
                          
                          menu.AddAttribute( 5, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, () => SelectItem(source)));
                          menu.AddAttribute( 10, nameof(Item.ChildContent), (RenderFragment)(item =>
                                {
                                    item.AddContent(0, ItemFormat(source));
                                }));
                          menu.CloseComponent();
                          i++;
                      }

                      if (!FilterdDataSource.Any())
                      {
                          menu.OpenComponent<Message>(1000);
                          menu.AddAttribute(1005, nameof(Message.ChildContent), (RenderFragment)(message => {
                              message.AddContent(0, "没有找到任何内容");
                          }));
                          menu.CloseComponent();
                      }
                  }
              }));
            builder.CloseComponent();

            string BuildMenuItemCssClass(T item)
            {
                var list = new List<string>();

                if (Filtered && !FilterExpression(FilterdInputValue, item))
                {
                    list.Add("filtered");
                }

                if (Value != null && CurrentValue != null && FilterExpression(CurrentValue,item))
                {
                    list.Add("active");
                }

                return string.Join(" ", list);
            }
        }

        /// <summary>
        /// 切换下拉菜单的显示/隐藏。
        /// </summary>
        public async Task Toggle()
        {
            await this.Active(!Actived);
        }

        /// <summary>
        /// 释放组件。
        /// </summary>
        public void Dispose()
        {
            if (CascadedEditContext != null)
            {
                CascadedEditContext.OnValidationStateChanged -= _validationStateChangedHandler;
            }
        }

        /// <summary>
        /// 默认过滤方式。
        /// </summary>
        /// <param name="input">搜索框输入的值。</param>
        /// <returns>过滤后的结果。</returns>
        IEnumerable<T> DefaultFilter(string input)
        {
            return DataSource.Where(value =>
            {
                return FilterExpression(input,value);
            });
        }

        /// <summary>
        /// 比较搜索框输入的值。
        /// </summary>
        /// <param name="input">输入的值。</param>
        /// <param name="value">选择的值。</param>
        /// <returns>匹配返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        private bool CompareSearchValue(string input, T value)
        {
            if (typeof(T).IsClass && typeof(T) != typeof(string))
            {
                if (string.IsNullOrWhiteSpace(FilterField))
                {
                    return false;
                }
                var seachValueProperty = value.GetType().GetProperty(FilterField);
                if (FilterField == seachValueProperty.Name)
                {
                    return seachValueProperty.GetValue(value).ToString().Contains(input);
                }
            }
            return value.ToString().Contains(input);
        }

        /// <summary>
        /// 获取指定数据源的值。
        /// </summary>
        /// <param name="source">数据源。</param>
        private string GetValue(T source)
        {
            if (source == null)
            {
                return null;
            }
            object value = source;
            if (typeof(T).IsClass && typeof(T) != typeof(string) && !string.IsNullOrWhiteSpace(FilterField))
            {
                value = source.GetType().GetProperty(FilterField)?.GetValue(source);
            }
            return value?.ToString();
        }

        /// <summary>
        /// 输入指定值并过滤检索数据。
        /// </summary>
        /// <param name="input">搜索框输入的值。</param>
        public async Task Search(string input)
        {
            FilterdInputValue = input;
            await OnFiltering.InvokeAsync(input);
            Filtered = !string.IsNullOrEmpty(input);
            if (Filtered)
            {
                FilterdDataSource = DefaultFilter(input);
            }
            else
            {
                FilterdDataSource = DataSource;
            }
            StateHasChanged();
        }

        /// <summary>
        /// 选择指定列表的项。
        /// </summary>
        /// <param name="selectedItem">选择的项。</param>
        public async Task SelectItem(T selectedItem)
        {
            SelectedItem = selectedItem;
            CurrentValue = GetValue(selectedItem);
            Filtered = false;
            FilterdInputValue = null;
            FilterdDataSource = DataSource;
            await OnItemSelected.InvokeAsync(selectedItem);

            CascadedEditContext?.NotifyValidationStateChanged();
            StateHasChanged();
        }

        /// <summary>
        /// 切换禁用/启用状态。
        /// </summary>
        /// <param name="disabled"><c>true</c> 为禁用；否则为启用。</param>
        public Task Disable(bool disabled = true)
        {
            Disabled = disabled;
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
