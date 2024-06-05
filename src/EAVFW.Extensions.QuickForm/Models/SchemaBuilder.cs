using Newtonsoft.Json;
using NJsonSchema;
using System.Runtime.Serialization;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using EAVFW.Extensions.QuickForm.Models.RJSF;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace EAVFW.Extensions.QuickForm.Models
{
    public interface ISchemaBuilder
    {

    }
    public class SchemaBuilder : ISchemaBuilder
    {
        protected UISchema Uischema = new UISchema();
        private readonly Type _type;

        public SchemaBuilder(Type type)
        {
            _type = type;
        }
        public String GetEnumMemberValue(RJSFOption value)

        {
            return value.GetType()
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }




        public ISchemaBuilder AddQuickFormInputComponentProp(string propertyName, string option, object value)
        {
            var uischema = Uischema;

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

            return this;
        }
        public ISchemaBuilder AddUIOption<TOptionValue>(string propertyName, RJSFOption option, TOptionValue value)
        {
            var uischema = Uischema;

            if (!uischema.ContainsKey(propertyName))
            {
                uischema[propertyName] = new UISchema();
            }
            uischema = uischema[propertyName];

            uischema.Add($"ui:{GetEnumMemberValue(option)}", new UISchema(value));

            return this;
        }
        public ISchemaBuilder AddUIOption<TOptionValue>(RJSFOption option, TOptionValue value)
        { 
            Uischema.Add($"ui:{GetEnumMemberValue(option)}", new UISchema(value));

            return this;
        }


        public RJSFProps Build()
        {
            foreach(var attr in _type.GetCustomAttributes<RJSFUIOptionAttribute>())
            {
                AddUIOption(attr.Option, attr.Value);
            }   

            foreach (var prop in _type.GetProperties())
            {
                var propName = prop.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;

                var options = prop.GetCustomAttributes<RJSFUIOptionAttribute>();
                foreach (var option in options)
                {

                    AddUIOption(propName, option.Option, option.Value);

                }

                var quickformprops = prop.GetCustomAttributes<QuickFormInputComponentPropAttribute>();

                foreach (var option in quickformprops)
                {

                    AddQuickFormInputComponentProp(propName, option.Option, option.Value);

                }
            }
            var schema = JsonSchema.FromType(_type);



            return new RJSFProps
            {
                Schema = schema,
                UISchema = Uischema,
            };
        }

     
    }
    public class SchemaBuilder<T> : SchemaBuilder, ISchemaBuilder
    {
        public SchemaBuilder() : base(typeof(T))
        {

        }
        public ISchemaBuilder AddUIOption<TProp, TOptionValue>(Expression<Func<T, TProp>> picker, RJSFOption option, TOptionValue value)
        {
            var uischema = Uischema;

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


    }

}
