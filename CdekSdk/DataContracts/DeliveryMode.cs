using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Delivery modes (appendix 3).
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public enum DeliveryMode
    {
        [EnumMember(Value = "1")]
        DoorToDoor = 1,

        [EnumMember(Value = "2")]
        DoorToWarehouse = 2,

        [EnumMember(Value = "3")]
        WarehouseToDoor = 3,

        [EnumMember(Value = "4")]
        WarehouseToWarehouse = 4,

        [EnumMember(Value = "6")]
        DoorToParcelTeminal = 6,

        [EnumMember(Value = "7")]
        WarehouseToParcelTerminal = 7,

        [EnumMember(Value = "8")]
        ParcelTerminalToDoor = 8,

        [EnumMember(Value = "9")]
        ParcelTerminalToWarehouse = 9,

        [EnumMember(Value = "10")]
        ParcelTerminalToParcelTerminal = 10,
    }
}
