using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents an item of a package to be delivered.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class PackageItem
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "ware_key")]
        public string WareKey { get; set; }

        [DataMember(Name = "payment")]
        public DeliveryOrderPayment Payment { get; set; }

        [DataMember(Name = "weight")]
        public int Weight { get; set; }

        [DataMember(Name = "weight_gross")]
        public int WeightGross { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "delivery_amount")]
        public decimal DeliveryAmount { get; set; }

        [DataMember(Name = "name_i18n")]
        public string NameI18n { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "cost")]
        public double Cost { get; set; }
    }
}
