using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Tariff information.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public class TariffInfo
    {
        [DataMember(Name = "tariff_code")]
        public int TariffCode { get; set; }

        [DataMember(Name = "tariff_name")]
        public string TariffName { get; set; }

        [DataMember(Name = "tariff_description")]
        public string TariffDescription { get; set; }

        [DataMember(Name = "delivery_mode")]
        public DeliveryMode DeliveryMode { get; set; }

        [DataMember(Name = "delivery_sum")]
        public decimal DeliverySum { get; set; }

        [DataMember(Name = "period_min")]
        public int PeriodMin { get; set; }

        [DataMember(Name = "period_max")]
        public int PeriodMax { get; set; }
    }
}
