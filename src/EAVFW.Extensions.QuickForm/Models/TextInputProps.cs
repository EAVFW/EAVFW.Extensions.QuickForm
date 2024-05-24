using Newtonsoft.Json;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class TextInputProps : QuestionProps
    {
        [JsonProperty("inputType")]
        public override InputType InputType => InputType.Text;

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }
    }

    public class MultilineTextInputProps : QuestionProps
    {
        [JsonProperty("inputType")]
        public override InputType InputType => InputType.MultilineText;

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }
    }


}
