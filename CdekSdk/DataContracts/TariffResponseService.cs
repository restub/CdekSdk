using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Service amount for the tariff calculation response.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345430.html
    /// </summary>
    [DataContract]
    public class TariffResponseService
    {
        [DataMember(Name = "code")]
        public ServiceType Code { get; set; }

        [DataMember(Name = "sum")]
        public string Sum { get; set; }
    }
}
