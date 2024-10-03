using EAVFW.Extensions.QuickForm.Models.Questions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace EAVFW.Extensions.QuickForm.Models
{
    public class EndingProps 
    {

        

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("textIsHtml")]
        public bool TextIsHtml { get; set; }

        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }

        [JsonProperty("paragraphIsHtml")]
        public bool ParagraphIsHtml { get; set; }

        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        [System.Text.Json.Serialization.JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; }

    }

}
