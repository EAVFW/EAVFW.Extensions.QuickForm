using System.Runtime.Serialization;

namespace EAVFW.Extensions.QuickForm.Models.RJSF
{
    public enum RJSFOption
    {
        [EnumMember(Value = "label")]
        Label,
        [EnumMember(Value = "placeholder")]
        Placeholder,
        [EnumMember(Value = "widget")]
        Widget,
        [EnumMember(Value = "field")]
        Field
    }

}
