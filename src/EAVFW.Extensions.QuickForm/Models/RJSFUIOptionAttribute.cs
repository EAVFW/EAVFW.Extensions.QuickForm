using System;

namespace EAVFW.Extensions.QuickForms.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =true)]
    public class RJSFUIOptionAttribute : Attribute
    {
        public RJSFUIOptionAttribute(RJSFOption option, object value)
        {
            Option = option;
            Value = value;
        }
        public RJSFOption Option { get; set; }
        public object Value { get; set; }
    }

}
