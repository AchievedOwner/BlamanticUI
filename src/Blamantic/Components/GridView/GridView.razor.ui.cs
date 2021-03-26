using System;
using System.Linq;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using YoiBlazor;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace BlamanticUI
{
    partial class GridView
    {
        /// <summary>
        /// Builds the header table.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildHeaderTable(RenderTreeBuilder builder)
        {
            BuildTable(builder, nameof(Table.Header), new RenderFragment(row =>
            {
                if (HeaderTemplate is null)
                {
                    row.OpenComponent<TableRow>(0);

                    row.AddAttribute(1, nameof(TableRow.ChildContent), (RenderFragment)(th =>
                    {

                        if (AutoGenerateColumns)
                        {
                            var properties = DataSource.GetType().GenericTypeArguments[0].GetProperties();
                            foreach (var dataField in properties)
                            {
                                var headerText = dataField.GetCustomAttribute<DisplayAttribute>()?.Name;
                                if (string.IsNullOrEmpty(headerText))
                                {
                                    headerText = dataField.Name;
                                }
                                BuildCell<TableHeader>(th, child => child.AddContent(0, headerText));
                            }
                        }
                        else
                        {
                            foreach (var column in Fields)
                            {
                                var headerText = column.HeaderText;

                                //When HeaderText is null or empty string, use DataField for header text
                                if (column is GridViewBoundField boundField && string.IsNullOrEmpty(column.HeaderText))
                                {
                                    headerText = boundField.DataField;
                                }
                                BuildCell<TableHeader>(th, child => child.AddContent(0, headerText), th => AddCellWidthAttribute(th, column, 5));
                            }
                        }
                    }));

                    row.CloseComponent();
                }
                else
                {
                    row.AddContent(0, HeaderTemplate);
                }
            }));
        }

        /// <summary>
        /// Builds the body table.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildBodyTable(RenderTreeBuilder builder)
        {
            builder.OpenRegion(200);
            BuildTable(builder, nameof(Table.Body), body =>
            {
                int i = 0;

                if (!FilterdData.Any())
                {
                    body.OpenComponent<TableRow>(0);
                    body.AddAttribute(10, nameof(TableRow.ChildContent), (RenderFragment)(tr =>
                    {
                        if (EmptyTemplate is null)
                        {
                            EmptyTemplate = builder => builder.AddContent(0, "There is no data!!");
                        }

                        tr.OpenComponent<TableCell>(0);
                        tr.AddAttribute(1, "colspan", FilterdData.GetType().GetGenericTypeDefinition().GetProperties().Length);
                        tr.AddAttribute(2, nameof(TableCell.HorizontalAlignment), HorizontalAlignment.Center);
                        tr.AddAttribute(10, nameof(TableCell.ChildContent), EmptyTemplate);
                        tr.CloseComponent();
                    }));

                    body.CloseComponent();
                }

                foreach (var row in FilterdData)
                {
                    var index = i;
                    body.OpenComponent<TableRow>(0);
                    body.SetKey(index);
                    body.AddAttribute(10, nameof(TableRow.ChildContent), (RenderFragment)(td =>
                    {
                        if (AutoGenerateColumns)
                        {
                            var properties = row.GetType().GetProperties();
                            foreach (var dataField in properties)
                            {
                                var format = dataField.GetCustomAttribute<DisplayFormatAttribute>()?.DataFormatString;
                                var value = dataField.GetValue(row);
                                if (!string.IsNullOrEmpty(format))
                                {
                                    value = string.Format(format, value);
                                }

                                BuildCell<TableCell>(td, child => child.AddContent(0, value));
                            }
                        }
                        else
                        {
                            foreach (var column in Fields)
                            {
                                if (column is GridViewBoundField boundField)
                                {
                                    var value = GetFieldValue(row, boundField.DataField);
                                    if (!string.IsNullOrEmpty(boundField.FieldFormat))
                                    {
                                        value = string.Format(boundField.FieldFormat, value);
                                    }
                                    BuildCell<TableCell>(td, child => child.AddContent(0, value), td => AddCellWidthAttribute(td, column, 5));
                                }
                                else if (column is GridViewTemplateField templateField)
                                {
                                    BuildCell<TableCell>(td, templateField.ItemTemplate(row), td => AddCellWidthAttribute(td, column, 5));
                                }
                            }
                        }
                    }));
                    body.CloseComponent();
                    i++;
                }
            });
            builder.CloseRegion();
        }

        /// <summary>
        /// Builds the footer table.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildFooterTable(RenderTreeBuilder builder)
        {
            BuildTable(builder, nameof(Table.Footer), footer =>
            {
                footer.AddContent(0, FooterTemplate);
            });
        }

        /// <summary>
        /// Builds the pagination.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void BuildPagination(RenderTreeBuilder builder)
        {
            builder.OpenComponent<Pagination>(0);

            builder.AddAttribute(1, nameof(Pagination.CurrentPage), CurrentPage);
            builder.AddAttribute(2, nameof(Pagination.PageSize), PageSize);
            builder.AddAttribute(3, nameof(Pagination.PageSizeStakeholders), PageSizeStackholders);
            builder.AddAttribute(3, nameof(Pagination.TotalCount), TotalCount);
            builder.AddAttribute(4, nameof(Pagination.OnCurrentPageChanged), EventCallback.Factory.Create<int>(this,
                async page =>
                {
                    CurrentPage = page;
                    await LoadData();
                }));
            builder.AddAttribute(5, nameof(Pagination.Alignment), PaginationAlignment);

            builder.CloseComponent();
        }

        /// <summary>
        /// Adds the cell width attribute.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="column">The column.</param>
        /// <param name="sequence">The sequence.</param>
        static void AddCellWidthAttribute(RenderTreeBuilder builder, GridViewFieldBase column, int sequence)
        {
            if (!string.IsNullOrEmpty(column.Width))
            {
                builder.AddAttribute(sequence, nameof(TableCell.AdditionalStyles), (StyleCollection)Style.Create.Add("width", column.Width));
            }
        }

        /// <summary>
        /// Build the cell in table row.
        /// </summary>
        /// <typeparam name="T">The type of component in cell.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="value">The value.</param>
        /// <param name="addAttributesAction">The add attributes action.</param>
        static void BuildCell<T>(RenderTreeBuilder builder, RenderFragment value, Action<RenderTreeBuilder> addAttributesAction = default)
            where T : IComponent
        {
            builder.OpenComponent<T>(0);
            addAttributesAction?.Invoke(builder);
            builder.AddAttribute(10, nameof(TableCell.ChildContent), value);
            builder.CloseComponent();
        }
        /// <summary>
        /// Builds the table.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="position">The position.</param>
        /// <param name="fragment">The fragment.</param>
        void BuildTable(RenderTreeBuilder builder, string position, RenderFragment fragment)
        {
            builder.OpenComponent<Table>(0);
            builder.AddAttribute(3, nameof(Table.Basic), Basic);
            builder.AddAttribute(4, nameof(Table.Padded), Padded);
            builder.AddAttribute(5, nameof(Table.Size), Size);
            builder.AddAttribute(6, nameof(Table.Very), Very);
            builder.AddAttribute(7, nameof(Table.Compact), Compact);
            builder.AddAttribute(8, nameof(Table.Selectable), Selectable);
            builder.AddAttribute(9, nameof(Table.Fixed), true);
            builder.AddAttribute(10, nameof(Table.Celled), Celled);
            builder.AddAttribute(11, nameof(Table.Striped), Striped);
            builder.AddAttribute(12, nameof(Table.Structured), Structured);


            if (position == "Body" && (InvertedHeaderOnly || !Inverted))
            {
                Color = null;
                Inverted = false;
            }
            builder.AddAttribute(16, nameof(Table.Inverted), Inverted);

            builder.AddAttribute(17, nameof(Table.Color), Color);
            builder.AddAttribute(20, position, fragment);

            builder.CloseComponent();
        }
    }
}
