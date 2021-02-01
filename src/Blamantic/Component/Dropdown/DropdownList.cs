using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using BlamanticUI.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using YoiBlazor;

namespace BlamanticUI
{
    /// <summary>
    /// Render a dropdown list component that support two-way binding.
    /// </summary>
    /// <typeparam name="T">The type of data source.</typeparam>
    /// <seealso cref="BlamanticUI.Abstractions.BlamanticComponentBase" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasUIComponent" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSelectable" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasFluid" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasStateToggle" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasActive" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSize" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasCompact" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInverted" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasSpan" />
    /// <seealso cref="BlamanticUI.Abstractions.IHasInline" />
    public class DropDownList<T> : FormInputBase<string>,IDisposable,
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

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownList{T}"/> class.
        /// </summary>
        public DropDownList()
        {
            Selectable = true;
            FilterExpression = CompareSearchValue;
            FilterEmptyContent = builder => builder.AddContent(0, "No results found.");
        }

        #region Parameters        
        /// <summary>
        /// Gets or sets a value indicating whether hover style while cursor moving over items.
        /// </summary>
        [Parameter] [CssClass("selection")] public bool Selectable { get; set; }

        /// <summary>
        /// Gets or sets to display a input filter for candidate items.
        /// </summary>
        [Parameter] [CssClass("search")] public bool Filterable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the drop up direction.
        /// </summary>
        [Parameter] [CssClass("upward")]public bool Up { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is fluid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fluid; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Fluid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this drop down list is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actived; otherwise, <c>false</c>.
        /// </value>
        [Parameter] [CssClass("active")] public bool Actived { get; set; }

        /// <summary>
        /// Gets or sets the field of data source to be filtered.
        /// </summary>
        [Parameter] public string FilterField { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the selected item can be removable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if removable; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Removable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DropDownList{T}"/> is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        [Parameter] public Size? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to compact space of text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if compact; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Compact { get; set; }

        /// <summary>
        /// Gets or sets the maximum filter items.
        /// </summary>
        [Parameter] public int MaxFilterItems { get; set; } = 10;
        /// <summary>
        /// Gets or sets the span of column.
        /// </summary>
        [Parameter] [CssClass(" column", Suffix = true)] public ColSpan Span { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether is inline paragraph.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inline; otherwise, <c>false</c>.
        /// </value>
        [Parameter] public bool Inline { get; set; }

        /// <summary>
        /// Gets or sets the default item before selected.
        /// </summary>
        [Parameter] public RenderFragment DefaultItem { get; set; }
        /// <summary>
        /// Gets or sets the format of item to display in list.
        /// </summary>
        [Parameter] public RenderFragment<T> ItemFormat { get; set; }

        /// <summary>
        /// Gets or sets the UI content while empty filtered items from data source.
        /// </summary>
        [Parameter] public RenderFragment FilterEmptyContent { get; set; }

        /// <summary>
        /// Gets or sets an expression for filter that can do customization data filtered.
        /// <list type="bullet">
        /// <item>arg1: the text of search input;</item>
        /// <item>arg2: a item of data source;</item>
        /// <item>return <c>true</c> if result matched for filter, otherwise <c>false</c>.</item>
        /// </list>
        /// </summary>
        [Parameter] public Func<string, T, bool> FilterExpression { get; set; }


        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        [Parameter] public IEnumerable<T> DataSource { get; set; }

        /// <summary>
        /// Gets or sets a callback method invoked when item is selected.
        /// </summary>
        [Parameter] public EventCallback<T> OnItemSelected { get; set; }

        /// <summary>
        /// Gets or sets a callback method invoked when a item is filtered.
        /// </summary>
        [Parameter] public EventCallback<string> OnFiltering { get; set; }
        /// <summary>
        /// Gets or sets a callback method whether active state has changed.
        /// </summary>
        [Parameter] public EventCallback<bool> OnActived { get; set; }

        #endregion

        /// <summary>
        /// Gets the filtered data source.
        /// </summary>
        protected IEnumerable<T> FilterdDataSource { get; private set; }

        /// <summary>
        /// Gets a value indicating whether display in drop down list that has filtered items.
        /// </summary>
        protected bool Filtered { get; private set; }

        /// <summary>
        /// Gets the filterd value of search input.
        /// </summary>
        protected string FilterdInputValue { get; private set; }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        T SelectedItem { get; set; }

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
        /// Override to create the CSS class that component need.
        /// </summary>
        /// <param name="css">The instance of <see cref="T:YoiBlazor.Css" /> class.</param>
        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("dropdown").Add(Actived, "visible").Add(Removable, "clearable");
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
                builder.AddAttribute(1, "tabindex", new Random().Next());
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

        /// <summary>
        /// Builds the remove icon.
        /// </summary>
        /// <param name="child">The child.</param>
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
        /// Builds the search input.
        /// </summary>
        /// <param name="child">The child.</param>
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
        /// Builds the dropdown icon.
        /// </summary>
        /// <param name="child">The child.</param>
        private static void BuildDropdownIcon(RenderTreeBuilder child)
        {
            child.OpenComponent<Icon>(20);
            child.AddAttribute(21, nameof(Icon.IconClass), "dropdown");
            child.CloseComponent();
        }

        /// <summary>
        /// Builds the default text.
        /// </summary>
        /// <param name="child">The child.</param>
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
        /// Builds the drop down items.
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
                          menu.AddAttribute(1005, nameof(Message.ChildContent), FilterEmptyContent);
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
        /// Perform the toggle for actived.
        /// </summary>
        public async Task Toggle()
        {
            await this.Active(!Actived);
        }

        /// <summary>
        /// Defaults the filter.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        IEnumerable<T> GetDefaultFilter(string input) => DataSource.Where(value => FilterExpression(input, value));


        /// <summary>
        /// Compares the search value.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
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
        /// Gets the value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
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
        /// Searches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        public async Task Search(string input)
        {
            FilterdInputValue = input;
            await OnFiltering.InvokeAsync(input);
            Filtered = !string.IsNullOrEmpty(input);
            if (Filtered)
            {
                FilterdDataSource = GetDefaultFilter(input);
            }
            else
            {
                FilterdDataSource = DataSource;
            }
            StateHasChanged();
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="selectedItem">The selected item.</param>
        public async Task SelectItem(T selectedItem)
        {
            SelectedItem = selectedItem;
            CurrentValue = GetValue(selectedItem);
            Filtered = false;
            FilterdInputValue = null;
            FilterdDataSource = DataSource;
            await ValueChanged.InvokeAsync(CurrentValue);
            await OnItemSelected.InvokeAsync(selectedItem);

            EditContext?.NotifyValidationStateChanged();
            StateHasChanged();
        }
    }
}
