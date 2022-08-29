using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents the postamat cell dimensions.
    /// EN: https://api-docs.cdek.ru/36990336.html
    /// RU: https://api-docs.cdek.ru/36982648.html
    /// </summary>
    [DataContract]
    public class CellDimensions
    {
        [DataMember(Name = "height")]
        public decimal Height { get; set; } // cm

        [DataMember(Name = "width")]
        public decimal Width { get; set; } // cm

        [DataMember(Name = "depth")]
        public decimal Depth { get; set; } // cm
    }
}
