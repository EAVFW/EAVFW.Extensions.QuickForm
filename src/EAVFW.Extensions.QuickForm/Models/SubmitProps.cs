using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class SubmitProps : QuestionProps
    {
        public override InputType InputType => InputType.Submit;

        [JsonProperty("text")]
        public string Text { get; set; }

       
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }

        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        [JsonProperty("submitFields")]
        public SubmitFields SubmitFields { get; set; }

        [JsonProperty("submitUrl")]
        public string SubmitUrl { get; set; }
        [JsonProperty("submitMethod")]
        public string SubmitMethod { get; set; } = "POST";
    }

}
