using Newtonsoft.Json;
using NJsonSchema;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using EAVFW.Extensions.QuickForm.Models;

namespace EAVFW.Extensions.QuickForm.Models.RJSF
{
    public class RSJFProps
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
