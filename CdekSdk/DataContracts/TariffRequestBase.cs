using System;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Delivery calculation options, base class.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public class TariffRequestBase
    {
        [DataMember(Name = "type")]
        public DeliveryType? DeliveryType { get; set; } // default is DeliveryType.OnlineStore

        [DataMember(Name = "date")]
        public DateTime? Date { get; set; } // default is today

        [DataMember(Name = "currency")]
        public int? Currency { get; set; } // default is the contract currency

        [DataMember(Name = "from_location")]
        public Location FromLocation { get; set; }

        [DataMember(Name = "to_location")]
        public Location ToLocation { get; set; }

        [DataMember(Name = "packages")]
        public PackageSize[] Packages { get; set; }
    }
}
