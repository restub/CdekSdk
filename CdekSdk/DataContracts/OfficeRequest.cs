using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Gets the list of offices.
    /// EN: https://api-docs.cdek.ru/36990336.html
    /// RU: https://api-docs.cdek.ru/36982648.html
    /// </summary>
    [DataContract]
    public class OfficeRequest
    {
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; } // RU, EN, etc

        [DataMember(Name = "postal_code")]
        public int? PostalCode { get; set; }

        [DataMember(Name = "city_code")]
        public int? CityCode { get; set; }

        [DataMember(Name = "region_code")]
        public int? RegionCode { get; set; }

        [DataMember(Name = "fias_guid")]
        public string FiasGuid { get; set; }

        [DataMember(Name = "type")]
        public OfficeType? OfficeType { get; set; } // PVZ/POSTAMAT/ALL

        [DataMember(Name = "have_cashless")]
        public bool HasCashless { get; set; }

        [DataMember(Name = "have_cash")]
        public bool HasCash { get; set; }

        [DataMember(Name = "is_dressing_room")]
        public bool IsDressingRoom { get; set; }

        [DataMember(Name = "is_reception")]
        public bool IsReception { get; set; }

        [DataMember(Name = "is_handout")]
        public bool IsHandout { get; set; }

        [DataMember(Name = "take_only")]
        public bool TakeOnly { get; set; }

        [DataMember(Name = "allowed_cod")]
        public bool CodAllowed { get; set; }

        [DataMember(Name = "weight_max")]
        public int? WeightMax { get; set; }

        [DataMember(Name = "weight_min")]
        public int? WeightMin { get; set; }

        [DataMember(Name = "lang")]
        public Lang? Lang { get; set; } // rus/eng/zho
    }
}
