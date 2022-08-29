using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents CDEK delivery order additional service, like wrapping, packaging, notifications, etc.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class DeliveryOrderService
    {
        [DataMember(Name = "code")]
        public ServiceType Code { get; set; }

        [DataMember(Name = "parameter")]
        public string Parameter { get; set; } // depends on the service
    }
}
