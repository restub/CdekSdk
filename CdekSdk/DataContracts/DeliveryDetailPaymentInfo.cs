using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents delivery detail payment info.
    /// EN: https://api-docs.cdek.ru/33828849.html
    /// RU: https://api-docs.cdek.ru/29923975.html
    /// </summary>
    [DataContract]
    public class DeliveryDetailPaymentInfo
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "sum")]
        public decimal Sum { get; set; }

        [DataMember(Name = "delivery_sum")]
        public decimal DeliverySum { get; set; }

        [DataMember(Name = "total_sum")]
        public decimal TotalSum { get; set; }
    }
}
