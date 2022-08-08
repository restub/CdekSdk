using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Delivery modes.
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
        WarehouseToParcelTerminal = 7
    }
}
