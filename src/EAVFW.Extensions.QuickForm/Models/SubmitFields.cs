using Newtonsoft.Json;
using NJsonSchema;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class SubmitFields
    {
        [JsonProperty("schema")]
        public JsonSchema Schema { get; set; }
       
        [JsonProperty("uiSchema")]
        public Dictionary<string, UISchema> UISchema { get; set; }
        
       

        public static SchemaBuilder<T> FromType<T>()
        {
            return new SchemaBuilder<T>();
        }
    }

}
