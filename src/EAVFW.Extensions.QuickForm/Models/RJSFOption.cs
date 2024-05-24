using System.Runtime.Serialization;

namespace EAVFW.Extensions.QuickForms.Models
{
    public enum RJSFOption
    {
        [EnumMember(Value = "label")]
        Label,
        [EnumMember(Value = "placeholder")]
        Placeholder,
        [EnumMember(Value = "widget")]
        Widget
    }

}
