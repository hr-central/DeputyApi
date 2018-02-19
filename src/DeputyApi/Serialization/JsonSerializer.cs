using System;
using Newtonsoft.Json;

namespace DeputyApi.Serialization
{
    internal class JsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public string Serialize<T>(T model) => JsonConvert.SerializeObject(model, Settings);

        public T Deserialize<T>(string serialized)
        {
            if (string.IsNullOrEmpty(serialized))
                throw new ArgumentNullException(nameof(serialized));
            return JsonConvert.DeserializeObject<T>(serialized, Settings);
        }
    }
}
