using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Serialization;

namespace EAVFW.Extensions.QuickForms.Models
{

    [JsonConverter(typeof(QuestionPropsJsonConverter))]
    public abstract class QuestionProps
    {
        [JsonProperty("inputType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract InputType InputType { get; }
    }

}
