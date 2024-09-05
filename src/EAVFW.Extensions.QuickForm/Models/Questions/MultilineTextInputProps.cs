using EAVFW.Extensions.QuickForm.Models.Questions;
using Newtonsoft.Json;

namespace EAVFW.Extensions.QuickForm.Models
{
    public class MultilineTextInputProps : QuestionProps
    {
        [JsonProperty("inputType")]
        public override string InputType => InputTypes.MultilineText;

       

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
        [JsonProperty("paragraph")]
        public string Paragraph { get; set; }
    }


}
