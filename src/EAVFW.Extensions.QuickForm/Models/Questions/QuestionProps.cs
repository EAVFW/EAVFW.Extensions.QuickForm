using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Serialization;
using EAVFW.Extensions.QuickForms.Models;
using System.Collections.Generic;

namespace EAVFW.Extensions.QuickForm.Models.Questions
{

    [JsonConverter(typeof(QuestionPropsJsonConverter))]
    public abstract class QuestionProps
    {
        [JsonProperty("inputType")]

        public abstract string InputType { get;   }

        [JsonProperty("logicalName")]
        public string LogicalName { get; set; }

        [JsonExtensionData]
        public Dictionary<string,object> AdditionalData { get; set; }
    }

    public class UnknoqnQuestionProps : QuestionProps
    {
        public override string InputType { get; }
    }

}
