using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Delivery calculation options to get the available tariffs.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public class TariffRequest : TariffRequestBase
    {
        [DataMember(Name = "tariff_code")]
        public int TariffCode { get; set; }

        [DataMember(Name = "services")]
        public List<DeliveryOrderService> Services { get; set; } = new List<DeliveryOrderService>();
    }
}
