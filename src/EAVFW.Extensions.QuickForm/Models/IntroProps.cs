using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class IntroProps : QuestionProps
    {
        public override InputType InputType => InputType.Intro;
        [JsonProperty("text")]
        public string Text { get; set; }

        
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }
       
        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }
    }

}
