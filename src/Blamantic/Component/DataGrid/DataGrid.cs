namespace BlamanticUI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using YoiBlazor;

    /// <summary>
    /// Represents a binding data source to render a table component.
    /// </summary>
    public class DataGrid : BlamanticComponentBase,IHasUIComponent, IHasSelectable,
        IHasColor,
        IHasCompact,
        IHasPadded,
        IHasVery,
        IHasSize,
        IHasBasic,
        IHasInverted,
        IHasCelled
    {
        #region Parameters
        /// <summary>
        /// Gets or sets the data source to render in grid.
        /// </summary>
        [Parameter] public object DataSource { get; set; }
        [Parameter] public bool Inverted { get; set; }
        [Parameter] public bool Basic { get; set; }
        [Parameter] public Color? Color { get; set; }
        [Parameter] public bool Selectable { get; set; }
        [Parameter] public bool Compact { get; set; }
        [Parameter] public bool Padded { get; set; }
        [Parameter] public bool Very { get; set; }
        [Parameter] public Size? Size { get; set; }
        [Parameter] public bool Celled { get; set; }

        [Parameter] public RenderFragment RowTemplates { get; set; }

        #endregion

        #region Properties

        internal ICollection<DataGridBindingTemplate> Columns { get; set; } = new HashSet<DataGridBindingTemplate>();

        internal IEnumerable GetEnumerableDataSource()
        {
            if(DataSource is not IEnumerable data)
            {
                throw new InvalidCastException($"The {nameof(DataSource)} must support {nameof(IEnumerable)} type");
            }
            return data;
        }
        #endregion

        #region Methods

        #region Internal
        internal void AddColumn(DataGridBindingTemplate template)
        {
            if (template is null)
            {
                throw new System.ArgumentNullException(nameof(template));
            }

            Columns.Add(template);
            NotifyStateChanged();
        }
        #endregion

        #region Private


        void BuildTable(RenderTreeBuilder builder, string position, RenderFragment fragment)
        {
            builder.OpenComponent<Table>(0);
            builder.AddAttribute(1, nameof(Table.Inverted), Inverted);
            builder.AddAttribute(2, nameof(Table.Color), Color);
            builder.AddAttribute(3, nameof(Table.Basic), Basic);
            builder.AddAttribute(4, nameof(Table.Padded), Padded);
            builder.AddAttribute(5, nameof(Table.Size), Size);
            builder.AddAttribute(6, nameof(Table.Very), Very);
            builder.AddAttribute(7, nameof(Table.Compact), Compact);
            builder.AddAttribute(8, nameof(Table.Selectable), Selectable);
            builder.AddAttribute(9, nameof(Table.Fixed), true);

            //Resolve Data Source

            switch (position.ToLower())
            {
                case "header":
                    builder.AddAttribute(20, nameof(Table.Header), fragment);
                    break;
                case "footer":
                    builder.AddAttribute(20, nameof(Table.Footer), fragment);
                    break;
                default:
                    builder.AddAttribute(20, nameof(Table.Body), fragment);
                    break;
            }
            builder.CloseComponent();
        }

        #endregion

        #region Protected

        /// <summary>
        /// Builds data grid tree.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            AddCommonAttributes(builder);
            #region Header

            builder.AddContent(10, (RenderFragment)(header =>
            {
                header.OpenElement(0, "div");
                header.AddAttribute(1, "class", "datagrid-header");
                header.AddContent(5, BuildHeaderTable);
                header.CloseElement();
            }));
            #endregion

            #region Body
            builder.AddContent(20, body =>
            {
                body.OpenElement(0, "div");
                body.AddAttribute(1, "class", "datagrid-body");
                body.AddContent(5, BuildBodyTable);
                body.CloseElement();
            });
            #endregion

            #region Footer
            #endregion

            builder.CloseElement();

            builder.OpenRegion(100);
            builder.OpenComponent<CascadingValue<DataGrid>>(0);
            builder.AddAttribute(1, nameof(CascadingValue<DataGrid>.IsFixed), true);
            builder.AddAttribute(2, nameof(CascadingValue<DataGrid>.Value), this);
            builder.AddAttribute(2, nameof(CascadingValue<DataGrid>.ChildContent), RowTemplates);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        private void BuildHeaderTable(RenderTreeBuilder builder)
        {
            BuildTable(builder, "Header", new RenderFragment(header =>
              {
                  header.OpenComponent<Tr>(0);

                  header.AddAttribute(1, nameof(Tr.ChildContent), (RenderFragment)(th =>
                 {
                     foreach (var item in Columns)
                     {
                         th.OpenComponent<Th>(0);
                         th.AddAttribute(10, nameof(Th.ChildContent), (RenderFragment)(child =>
                        {
                            child.AddContent(0, item.GetHeader());
                        }));
                         th.CloseComponent();
                     }
                 }));

                  header.CloseComponent();
              }));
        }

        private void BuildBodyTable(RenderTreeBuilder builder)
        {
            BuildTable(builder,"Body", body =>
            {
                int i = 0;
                foreach (var item in GetEnumerableDataSource())
                {
                    var index = i;
                    body.OpenComponent<Tr>(0);
                    body.SetKey(index);
                    body.AddAttribute(10, nameof(Tr.ChildContent), (RenderFragment)(td =>
                      {
                          foreach (var column in Columns)
                          {
                              td.OpenComponent<Td>(0);

                              td.AddAttribute(10, nameof(Td.ChildContent), (RenderFragment)(child =>
                               {
                                   if (column is DataGridFieldTemplate fieldTemplate)
                                   {
                                       var value = GetFieldValue(item, column.FieldName);
                                       child.AddContent(0, string.Format(column.Format, value));
                                   }
                               }));
                              td.CloseComponent();
                          }
                      }));
                    body.CloseComponent();
                    i++;
                }
            });
        }

        protected override void CreateComponentCssClass(Css css)
        {
            css.Add("datagrid");
        }


        #endregion

        #region Public
        public static object? GetFieldValue(object field,string name)
        {
            return field.GetType().GetProperty(name).GetValue(field);
        }

        public static T? GetFieldValue<T>(object field,string name)
        {
            var value = GetFieldValue(field, name);
            if (value is not null)
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            return default;
        }
        #endregion

        #endregion
    }
}
