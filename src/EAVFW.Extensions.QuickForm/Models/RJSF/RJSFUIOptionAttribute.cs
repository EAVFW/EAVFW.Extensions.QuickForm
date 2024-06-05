using System;

namespace EAVFW.Extensions.QuickForm.Models.RJSF
{
    [AttributeUsage(AttributeTargets.Property| AttributeTargets.Class, AllowMultiple = true)]
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

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class QuickFormInputComponentPropAttribute : Attribute
    {
        public QuickFormInputComponentPropAttribute(string option, object value)
        {
            Option = option;
            Value = value;
        }
        public string Option { get; set; }
        public object Value { get; set; }
    }


    
}
