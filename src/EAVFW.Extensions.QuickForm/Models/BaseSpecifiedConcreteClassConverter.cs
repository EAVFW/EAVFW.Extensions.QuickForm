using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Serialization;

namespace EAVFW.Extensions.QuickForm.Models
{
    public class BaseSpecifiedConcreteClassConverter<TBase> : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(TBase).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }

}
