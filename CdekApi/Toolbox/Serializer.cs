using System;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;

namespace CdekApi.Toolbox
{
    /// <summary>
    /// Newtonsoft.Json serializer.
    /// </summary>
    public class Serializer : IRestSerializer
    {
        public string[] SupportedContentTypes { get; } =
        {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };

        public DataFormat DataFormat => DataFormat.Json;

        public string ContentType { get; set; } = "application/json";

        public JsonSerializerSettings Settings { get; } = CreateJsonSerializerSettings();

        private static JsonSerializerSettings CreateJsonSerializerSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            return settings;
        }

        public T Deserialize<T>(IRestResponse response) =>
            JsonConvert.DeserializeObject<T>(response.Content, Settings);

        public string Serialize(Parameter parameter) =>
            JsonConvert.SerializeObject(parameter.Value, Settings);

        public string Serialize(object obj) =>
            JsonConvert.SerializeObject(obj, Settings);
    }
}
