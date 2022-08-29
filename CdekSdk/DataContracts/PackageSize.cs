using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents the dimensions and weight of a package to be delivered.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public class PackageSize
    {
        [DataMember(Name = "weight")]
        public int Weight { get; set; } // grams

        [DataMember(Name = "height")]
        public int? Height { get; set; } // cm

        [DataMember(Name = "length")]
        public int? Length { get; set; } // cm

        [DataMember(Name = "width")]
        public int? Width { get; set; } // cm
    }
}
