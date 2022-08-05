using System;
using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Delivery calculation options to get the available tariffs.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public class TariffRequest
    {
        [DataMember(Name = "type")]
        public int? DeliveryType { get; set; } // default is DeliveryType.OnlineStore

        [DataMember(Name = "date")]
        public DateTime? Date { get; set; } // default is today

        [DataMember(Name = "currency")]
        public int? Currency { get; set; } // default is the contract currency

        [DataMember(Name = "lang")]
        public Lang? Lang { get; set; } // default is rus

        [DataMember(Name = "from_location")]
        public Location FromLocation { get; set; }

        [DataMember(Name = "to_location")]
        public Location ToLocation { get; set; }

        [DataMember(Name = "packages")]
        public PackageSize[] Packages { get; set; }
    }
}
