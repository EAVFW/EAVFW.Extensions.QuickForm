using EAVFW.Extensions.QuickForm.Models.Questions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace EAVFW.Extensions.QuickForm.Models
{
    public class IntroProps 
    {
        
        [JsonProperty("text")]
        public string Text { get; set; }

        
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }
       
        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        [System.Text.Json.Serialization.JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; }
    }

}
