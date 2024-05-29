using Newtonsoft.Json;

namespace EAVFW.Extensions.QuickForm.Models.Questions
{
    public class TextInputProps : QuestionProps
    {
        [JsonProperty("inputType")]
        public override string InputType => InputTypes.Text;

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }
    }


}
