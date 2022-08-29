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
    public class TariffRequest : TariffRequestBase
    {
        [DataMember(Name = "tariff_code")]
        public int TariffCode { get; set; }
    }
}
