﻿using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    [DataContract]
    public class Region
    {
        [DataMember(Name = "country")]
        public string CountryName { get; set; }

        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }

        [DataMember(Name = "region")]
        public string RegionName { get; set; }

        [DataMember(Name = "region_code")]
        public int RegionCode { get; set; }
    }
}
