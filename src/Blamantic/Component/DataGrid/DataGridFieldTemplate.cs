using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlamanticUI
{
    using Abstractions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    /// <summary>
    /// Represents the template of item to be rendered for each row from data source withing binding field.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BlamanticUI.DataGridBindingTemplate" />
    public class DataGridFieldTemplate : DataGridBindingTemplate
    {
        public DataGridFieldTemplate()
        {
            Format = "{0}";
        }

    }
}
