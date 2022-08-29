using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Delivery recipient cost, for online orders only.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class DeliveryRecipientCost
    {
        [DataMember(Name = "value")]
        public decimal Value { get; set; }

        [DataMember(Name = "vat_sum")]
        public decimal? VatSum { get; set; }

        [DataMember(Name = "vat_rate")]
        public int? VatRate { get; set; } // 0, 10, 20, or null for no VAT
    }
}
