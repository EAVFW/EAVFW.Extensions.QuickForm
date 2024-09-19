using EAVFW.Extensions.QuickForm.Models.Questions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EAVFW.Extensions.QuickForm.Models
{
    public class LayoutDefinition
    {
        [JsonProperty("defaultNextButtonText")]
        public string DefaultNextButtonText { get; set; }
          
        [JsonProperty("tokens")]
        public Dictionary<string, object> Tokens { get; set; }
 
        [JsonProperty("autoAdvanceSlides")]
        public bool AutoAdvanceSlides { get; set; }
 
        [JsonProperty("enableQuestionNumbers")]
        public bool EnableQuestionNumbers { get; set; }
 
        [JsonProperty("showPressEnter")]
        public bool ShowPressEnter { get; set; }
 
        [JsonProperty("defaultSlideButtonIcon")]
        public string DefaultSlideButtonIcon { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        [System.Text.Json.Serialization.JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; } 
    

    }
    public class QuickFormValidationDefinition
    {
        [Newtonsoft.Json.JsonExtensionData]
        [System.Text.Json.Serialization.JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; }


        [JsonProperty("messages")]
        public Dictionary<string, object> Messages { get; set; } = new Dictionary<string, object> { };
    }
    public class QuickFormDefinition
    {
        [JsonProperty("validation")]
        public QuickFormValidationDefinition Validation { get; set; }

        [JsonProperty("intro")]
        public IntroProps Intro { get; set; }
        [JsonProperty("submit")]
        public SubmitProps Submit { get; set; }
        [JsonProperty("ending")]
        public EndingProps Ending { get; set; }
        [JsonProperty("layout")]
        public LayoutDefinition Layout { get; set; }

        [JsonProperty("questions")]
        public Dictionary<string, QuestionProps> Questions { get; set; } = new Dictionary<string, QuestionProps> { };

        /// <summary>
        /// This is added such one may added extra data in the document
        /// that is not lost while serialization
        /// </summary>
        [Newtonsoft.Json.JsonExtensionData]
        [System.Text.Json.Serialization.JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; }
    }
}