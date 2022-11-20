using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Restub.DataContracts;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Tariff calculation response.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345430.html
    /// </summary>
    [DataContract]
    public class TariffResponse : IHasErrors
    {
        [DataMember(Name = "delivery_sum")]
        public decimal DeliverySum { get; set; }

        [DataMember(Name = "period_min")]
        public int PeriodMin { get; set; }

        [DataMember(Name = "period_max")]
        public int PeriodMax { get; set; }

        [DataMember(Name = "weight_calc")]
        public int WeightCalc { get; set; } // grams

        [DataMember(Name = "total_sum")]
        public decimal TotalSum { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "services")]
        public TariffResponseService[] Services { get; set; }

        [DataMember(Name = "errors")]
        public List<Error> Errors { get; set; }

        public string GetErrorMessage() => CdekClient.GetErrorMessage(Errors);

        public bool HasErrors() => Errors != null && Errors.Any();
    }
}
