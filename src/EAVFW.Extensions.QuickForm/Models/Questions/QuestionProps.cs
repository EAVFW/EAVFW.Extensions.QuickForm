using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Serialization;
using EAVFW.Extensions.QuickForm.Models;
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
        
        [JsonProperty("schemaName")]
        public string SchemaName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }


        [JsonExtensionData]
        public Dictionary<string,object> AdditionalData { get; set; }
    }

    public class UnknoqnQuestionProps : QuestionProps
    {
        public override string InputType { get; }
    }

}
