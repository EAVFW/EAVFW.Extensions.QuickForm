using EAVFW.Extensions.QuickForm.Models.Questions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class EndingProps 
    {

        

        [JsonProperty("text")]
        public string Text { get; set; }

      
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }

        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        
    }

}
