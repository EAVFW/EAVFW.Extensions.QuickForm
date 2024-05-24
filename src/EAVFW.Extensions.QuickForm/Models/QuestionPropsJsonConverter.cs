using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace EAVFW.Extensions.QuickForms.Models
{
    public class QuestionPropsJsonConverter : JsonConverter<QuestionProps>
    {
        private static Dictionary<InputType, Type> _pairs;
        private static readonly JsonSerializer Serializer = new JsonSerializer();
        static QuestionPropsJsonConverter()
        {
            _pairs = GetEnumerableOfType<QuestionProps>().ToDictionary(k => k.InputType, v => v.GetType());
        }
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T) Activator.CreateInstance(type, constructorArgs));
            }
           // objects.Sort();
            return objects;
        }
        public override bool CanWrite => false;

        public override QuestionProps ReadJson(JsonReader reader, Type objectType, QuestionProps existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var obj = JToken.ReadFrom(reader);

            var typeReader = obj.SelectToken("$.inputType").CreateReader();
            var type = serializer.Deserialize<InputType>(typeReader);
            var a = Activator.CreateInstance(_pairs[type]) as QuestionProps;
            serializer.Populate(obj.CreateReader(), a);
         

            return a;

        }
        public override void WriteJson(JsonWriter writer, QuestionProps value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }

}
