
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace EAVFW.Extensions.QuickForms.Models
{
    public enum InputType
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "multilinetext")]
        MultilineText,
        [EnumMember(Value = "rtf")]
        RTF,
        [EnumMember(Value = "image")]
        Image,
        [EnumMember(Value = "date")]
        Date,
        [EnumMember(Value = "dropdown")]
        Dropdown,
        [EnumMember(Value = "intro")]
        Intro,
        [EnumMember(Value = "submit")]
        Submit,
        [EnumMember(Value = "ending")]
        Ending,
        [EnumMember(Value = "none")]
        None
    }

  
}
