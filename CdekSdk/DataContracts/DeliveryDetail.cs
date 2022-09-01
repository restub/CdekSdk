using System.Collections.Generic;
using System.Runtime.Serialization;
using CdekSdk.Toolbox;
using Newtonsoft.Json;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents delivery shipping detail.
    /// EN: https://api-docs.cdek.ru/33828849.html
    /// RU: https://api-docs.cdek.ru/29923975.html
    /// </summary>
    [DataContract]
    public class DeliveryDetail
    {
        [DataMember(Name = "date"), JsonConverter(typeof(DateOnlyConverter))]
        public string Date { get; set; }

        [DataMember(Name = "recipient_name")]
        public string RecipientName { get; set; }

        [DataMember(Name = "payment_sum")]
        public decimal PaymentSum { get; set; }

        [DataMember(Name = "delivery_sum")]
        public decimal DeliverySum { get; set; }

        [DataMember(Name = "total_sum")]
        public decimal TotalSum { get; set; }

        [DataMember(Name = "payment_info")]
        public List<DeliveryDetailPaymentInfo> PaymentInfo { get; set; }
    }
}
