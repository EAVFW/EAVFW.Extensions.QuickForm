using Newtonsoft.Json;
using System;
using System.Data;
using System.Reflection;

namespace EAVFW.Extensions.Configuration.RJSF
{
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

    public static class QuickformBuilderExtensions
    {
        public static ISchemaBuilder AddQuickFormInputComponentProp(this ISchemaBuilder builder, string propertyName, string option, object value)
        {
            var uischema = builder.Uischema;

            if (!uischema.ContainsKey(propertyName))
            {
                uischema[propertyName] = new UISchema();
            }
            uischema = uischema[propertyName];

            if (!uischema.ContainsKey("ui:inputProps"))
            {
                uischema["ui:inputProps"] = new UISchema();
            }
            uischema = uischema["ui:inputProps"];

            uischema.Add(option, new UISchema(value));

            return builder;
        }

        public static ISchemaBuilder WithQuickForm(this ISchemaBuilder builder)
        {

            foreach (var prop in builder.Type.GetProperties())
            {
                var propName = prop.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;


                var quickformprops = prop.GetCustomAttributes<QuickFormInputComponentPropAttribute>();

                foreach (var option in quickformprops)
                {

                    builder.AddQuickFormInputComponentProp(propName, option.Option, option.Value);

                }
            }
            return builder;

        }
    }

}
