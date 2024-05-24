using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class EndingProps : QuestionProps
    {

        public override InputType InputType => InputType.Ending;

        [JsonProperty("text")]
        public string Text { get; set; }

      
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }

        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        
    }

}
