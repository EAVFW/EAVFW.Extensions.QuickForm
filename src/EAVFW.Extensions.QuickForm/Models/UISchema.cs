using Newtonsoft.Json;
using System.Collections.Generic;

namespace EAVFW.Extensions.QuickForms.Models
{
    [JsonConverter(typeof(UISchemaConverter))]
    public class UISchema : Dictionary<string, UISchema>
    {
        public UISchema(object value)
        {
            Value = value;
        }
        public UISchema()
        {
           
        }
        public string Label => this["ui:label"].Value as string;
        public object Value { get; set; }
    }

}
