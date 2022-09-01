using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Delivery payment types.
    /// EN: https://api-docs.cdek.ru/33828849.html
    /// RU: https://api-docs.cdek.ru/29923975.html
    /// </summary>
    [DataContract]
    public enum DeliveryPaymentType
    {
        [EnumMember(Value = "CASH")]
        Cash,

        [EnumMember(Value = "CARD")]
        Card = 2,
    }
}
