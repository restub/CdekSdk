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

        public T Deserialize<T>(IRestResponse response) =>
            JsonConvert.DeserializeObject<T>(response.Content);

        public string Serialize(Parameter parameter) =>
            JsonConvert.SerializeObject(parameter.Value);

        public string Serialize(object obj) =>
            JsonConvert.SerializeObject(obj);
    }
}
