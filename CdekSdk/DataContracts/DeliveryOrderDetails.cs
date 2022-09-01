using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents delivery order details.
    /// EN: https://api-docs.cdek.ru/33828849.html
    /// RU: https://api-docs.cdek.ru/29923975.html
    /// </summary>
    [DataContract]
    public class DeliveryOrderDetails : IHasErrors
    {
        [DataMember(Name = "entity")]
        public DeliveryOrderEntity Entity { get; set; }

        [DataMember(Name = "requests")]
        public List<RequestStatus> Requests { get; set; }

        public IEnumerable<Error> GetErrors() =>
            from r in Requests ?? Enumerable.Empty<RequestStatus>()
            from e in r.Errors ?? Enumerable.Empty<Error>()
            select e;
    }
}
