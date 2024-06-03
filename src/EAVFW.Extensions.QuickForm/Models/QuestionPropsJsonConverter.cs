using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json.Linq;
using EAVFW.Extensions.QuickForm.Models.Questions;

namespace EAVFW.Extensions.QuickForm.Models
{
    public class QuestionPropsJsonConverter : JsonConverter<QuestionProps>
    {
        private static Dictionary<string, Type> _pairs;
        private static readonly JsonSerializer Serializer = new JsonSerializer();
        static QuestionPropsJsonConverter()
        {
            _pairs = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            WithPropsFromAssembly<QuestionPropsJsonConverter>();
        }
        public static void WithPropsFromAssembly<T>()
        {
            foreach (var pair in GetEnumerableOfType<T, QuestionProps>()
                .Where(k => !string.IsNullOrEmpty(k.InputType))
                .ToDictionary(k => k.InputType, v => v.GetType()))
            {
                _pairs.Add(pair.Key, pair.Value);
            }
        }
        public static IEnumerable<T> GetEnumerableOfType<TAssembly,T>(params object[] constructorArgs) where T : class
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(TAssembly)).GetTypes()
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
            var type = serializer.Deserialize<string>(typeReader);

          

            var a = _pairs.ContainsKey(type) ? Activator.CreateInstance(_pairs[type]) as QuestionProps : new UnknoqnQuestionProps();
            serializer.Populate(obj.CreateReader(), a);
         

            return a;

        }
        public override void WriteJson(JsonWriter writer, QuestionProps value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

       
    }

}
