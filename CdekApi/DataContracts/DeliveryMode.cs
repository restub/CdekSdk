namespace CdekApi.DataContracts
{
    /// <summary>
    /// Delivery modes.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    public static class DeliveryMode
    {
        public const int DoorToDoor = 1;
        public const int DoorToWarehouse = 2;
        public const int WarehouseToDoor = 3;
        public const int WarehouseToWarehouse = 4;
        public const int DoorToParcelTeminal = 6;
        public const int WarehouseToParcelTerminal = 7;
    }
}
