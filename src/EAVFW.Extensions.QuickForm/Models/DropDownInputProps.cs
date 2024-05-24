using Newtonsoft.Json;
using System.Collections.Generic;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class DropDownInputProps : QuestionProps
    {
        [JsonProperty("inputType")]
        public override InputType InputType => InputType.Dropdown;

        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; } = null;
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; } = null;



        [JsonProperty("maxItems")]
        public string MaxItems { get; set; } = null;

        [JsonProperty("minItems")]
        public string MinItems { get; set; } = null;
        [JsonProperty("options")]
        public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

    }
     

}
