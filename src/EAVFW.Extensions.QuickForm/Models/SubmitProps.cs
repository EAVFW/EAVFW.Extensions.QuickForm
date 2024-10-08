using EAVFW.Extensions.Configuration.RJSF;
using EAVFW.Extensions.QuickForm.Models.Questions;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace EAVFW.Extensions.QuickForm.Models
{
    public class SubmitProps 
    {
        
        [JsonProperty("text")]
        public string Text { get; set; }

       
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }

        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        [JsonProperty("submitFields")]
        public RJSFProps SubmitFields { get; set; }

        [JsonProperty("submitUrl")]
        public string SubmitUrl { get; set; }
        [JsonProperty("submitMethod")]
        public string SubmitMethod { get; set; } = "POST";

        [Newtonsoft.Json.JsonExtensionData]
        [System.Text.Json.Serialization.JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; }
    }

}
