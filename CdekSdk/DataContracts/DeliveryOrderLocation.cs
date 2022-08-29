using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents CDEK order delivery location.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class DeliveryOrderLocation
    {
        [DataMember(Name = "code")]
        public int? CityCode { get; set; } // as returned by GetCities method

        [DataMember(Name = "fias_guid")]
        public string FiasGuid { get; set; } // UUID

        [DataMember(Name = "postal_code")]
        public string PostalCode { get; set; } // 344017

        [DataMember(Name = "longitude")]
        public decimal Longitude { get; set; }

        [DataMember(Name = "latitude")]
        public decimal Latitude { get; set; }

        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; } // "RU"

        [DataMember(Name = "region")]
        public string Region { get; set; }

        [DataMember(Name = "region_code")]
        public int RegionCode { get; set; } // as returned by GetRegions method

        [DataMember(Name = "sub_region")]
        public string SubRegion { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; } // "Москва"

        [DataMember(Name = "address")]
        public string Address { get; set; } // street address in the specified city
    }
}
