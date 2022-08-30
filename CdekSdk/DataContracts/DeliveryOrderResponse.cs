using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents created delivery order information.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class DeliveryOrderResponse
    {
        [DataMember(Name = "entity")]
        public Entity Entity { get; set; }

        [DataMember(Name = "requests")]
        public List<RequestStatus> Requests { get; set; }
    }
}
