using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    [DataContract]
    public class CityRequest
    {
        [DataMember(Name = "country_codes")]
        public string[] CountryCodes { get; set; }

        [DataMember(Name = "region_code")]
        public int? RegionCode { get; set; }

        [DataMember(Name = "kladr_region_code"), Obsolete]
        public string KladrRegionCode { get; set; }

        [DataMember(Name = "fias_region_guid"), Obsolete]
        public string FiasRegionCode { get; set; }

        [DataMember(Name = "postal_code")]
        public string PostalCode { get; set; }

        [DataMember(Name = "code")]
        public int? CityCode { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "size")]
        public int? Size { get; set; }

        [DataMember(Name = "page")]
        public int? Page { get; set; }

        [DataMember(Name = "lang")]
        public Lang? Lang { get; set; } // rus/eng/zho
    }
}
