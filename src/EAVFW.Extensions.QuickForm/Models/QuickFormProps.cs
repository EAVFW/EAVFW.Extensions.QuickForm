using Newtonsoft.Json;
using System.Collections.Generic;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class QuickFormProps
    {
        [JsonProperty("intro")]
        public IntroProps Intro { get; set; }
        [JsonProperty("submit")]
        public SubmitProps Submit { get; set; }
        [JsonProperty("ending")]
        public EndingProps Ending { get; set; }

        [JsonProperty("questions")]
        public Dictionary<string, QuestionProps> QuestionsContainer { get; set; }

        /// <summary>
        /// This is added such one may added extra data in the document
        /// that is not lost while serialization
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; }
    }
}