using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Delivery service types.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public enum ServiceType
    {
        [EnumMember(Value = "INSURANCE")]
        Insurance,

        [EnumMember(Value = "TAKE_SENDER")]
        TakeSender,

        [EnumMember(Value = "DELIV_RECEIVER")]
        DeliveryReceiver,

        [EnumMember(Value = "TRYING_ON")]
        TryingOn,

        [EnumMember(Value = "PART_DELIV")]
        PartialDelivery,

        [EnumMember(Value = "REVERSE")]
        Reverse,

        [EnumMember(Value = "DANGER_CARGO")]
        DangerousCargo,

        [EnumMember(Value = "SMS")]
        Sms,

        [EnumMember(Value = "THERMAL_MODE")]
        ThermalMode,

        [EnumMember(Value = "COURIER_PACKAGE_A2")]
        CourierPackageA2,

        [EnumMember(Value = "SECURE_PACKAGE_A2")]
        SecurePackageA2,

        [EnumMember(Value = "SECURE_PACKAGE_A3")]
        SecurePackageA3,

        [EnumMember(Value = "SECURE_PACKAGE_A4")]
        SecurePackageA4,

        [EnumMember(Value = "SECURE_PACKAGE_A5")]
        SecurePackageA5,

        [EnumMember(Value = "NOTIFY_ORDER_CREATED")]
        NotifyOrderCreated,

        [EnumMember(Value = "NOTIFY_ORDER_DELIVERY")]
        NotifyOrderDelivery,

        [EnumMember(Value = "CARTON_BOX_XS")]
        CartonBoxXs,

        [EnumMember(Value = "CARTON_BOX_S")]
        CartonBoxS,

        [EnumMember(Value = "CARTON_BOX_M")]
        CartonBoxM,

        [EnumMember(Value = "CARTON_BOX_L")]
        CartonBoxL,

        [EnumMember(Value = "CARTON_BOX_500GR")]
        CartonBox500gr,

        [EnumMember(Value = "CARTON_BOX_1KG")]
        CartonBox1kg,

        [EnumMember(Value = "CARTON_BOX_2KG")]
        CartonBox2kg,

        [EnumMember(Value = "CARTON_BOX_3KG")]
        CartonBox3kg,

        [EnumMember(Value = "CARTON_BOX_5KG")]
        CartonBox5kg,

        [EnumMember(Value = "CARTON_BOX_10KG")]
        CartonBox10kg,

        [EnumMember(Value = "CARTON_BOX_15KG")]
        CartonBox15kg,

        [EnumMember(Value = "CARTON_BOX_20KG")]
        CartonBox20kg,

        [EnumMember(Value = "CARTON_BOX_30KG")]
        CartonBox30kg,

        [EnumMember(Value = "BUBBLE_WRAP")]
        BubbleWrap,

        [EnumMember(Value = "WASTE_PAPER")]
        WastePaper,

        [EnumMember(Value = "CARTON_FILLER")]
        CartonFiller,

        [EnumMember(Value = "BAN_ATTACHMENT_INSPECTION")]
        BanAttachmentInspection,

        [EnumMember(Value = "PHOTO_DOCUMENT")]
        PhotoDocument,
    }
}
