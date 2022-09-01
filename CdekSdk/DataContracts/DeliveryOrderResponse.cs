using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents created or deleted delivery order information.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class DeliveryOrderResponse : IHasErrors
    {
        [DataMember(Name = "entity")]
        public Entity Entity { get; set; }

        [DataMember(Name = "requests")]
        public List<RequestStatus> Requests { get; set; }

        public IEnumerable<Error> GetErrors() =>
            from r in Requests ?? Enumerable.Empty<RequestStatus>()
            from e in r.Errors ?? Enumerable.Empty<Error>()
            select e;
    }
}
