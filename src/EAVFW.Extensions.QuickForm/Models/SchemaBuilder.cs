using Newtonsoft.Json;
using NJsonSchema;
using System.Runtime.Serialization;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
namespace EAVFW.Extensions.QuickForms.Models
{
    public class SchemaBuilder<T>
    {
        public String GetEnumMemberValue(RJSFOption value)

        {
            return value.GetType()
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

        private UISchema _uischema = new UISchema();
        public SchemaBuilder<T> AddUIOption<TProp, TOptionValue>(Expression<Func<T, TProp>> picker, RJSFOption option, TOptionValue value)
        {
            var uischema = _uischema;

            var m = picker.Body as MemberExpression;
            if (m != null)
            {
                var scope = m.Member.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;

                if (!uischema.ContainsKey(scope))
                {
                    uischema[scope] = new UISchema();
                }
                uischema = uischema[scope];
            }

            uischema.Add($"ui:{GetEnumMemberValue(option)}", new UISchema(value));

            return this;
        }

        public SchemaBuilder<T> AddUIOption<TOptionValue>(string propertyName, RJSFOption option, TOptionValue value)
        {
            var uischema = _uischema;
             
            if (!uischema.ContainsKey(propertyName))
            {
                uischema[propertyName] = new UISchema();
            }
            uischema = uischema[propertyName];
             
            uischema.Add($"ui:{GetEnumMemberValue(option)}", new UISchema(value));

            return this;
        }

        public SubmitFields Build()
        {

            foreach (var prop in typeof(T).GetProperties())
            {
               var propName= prop.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;

                var options = prop.GetCustomAttributes<RJSFUIOptionAttribute>();
                foreach (var option in options)
                {
                   
                    AddUIOption(propName, option.Option, option.Value);

                }
            }
            var schema = JsonSchema.FromType<T>();



            return new SubmitFields
            {
                Schema = schema,
                UISchema = _uischema,
            };
        }

    }

}
