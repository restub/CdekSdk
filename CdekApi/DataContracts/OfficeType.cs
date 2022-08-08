using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Office/pickup point types.
    /// EN: https://api-docs.cdek.ru/36990336.html
    /// RU: https://api-docs.cdek.ru/36982648.html
    /// </summary>
    [DataContract]
    public enum OfficeType
    {
        [EnumMember(Value = "PVZ")]
        Warehouse,

        [EnumMember(Value = "POSTAMAT")]
        ParcelTerminal,

        [EnumMember(Value = "ALL")]
        All
    }
}
