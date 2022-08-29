using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Delivery types.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public enum DeliveryType
    {
        [EnumMember(Value = "1")]
        OnlineStore = 1,

        [EnumMember(Value = "2")]
        Delivery = 2
    }
}
