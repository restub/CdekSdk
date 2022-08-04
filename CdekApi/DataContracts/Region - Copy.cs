using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    [DataContract]
    public class GetRegion
    {
        [DataMember(Name = "country_codes")]
        public string[] CountryCodes { get; set; }

        [DataMember(Name = "region_code")]
        public int RegionCode { get; set; }

        [DataMember(Name = "kladr_region_code")]
        public string KladrRegionCode { get; set; }

        [DataMember(Name = "fias_region_guid")]
        public string FiasRegionCode { get; set; }

        [DataMember(Name = "size")]
        public int Size { get; set; }

        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "lang")]
        public string Lang { get; set; }
    }
}
