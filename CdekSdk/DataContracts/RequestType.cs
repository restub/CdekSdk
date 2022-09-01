using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Request types.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public enum RequestType
    {
        [EnumMember(Value = "CREATE")]
        Create,

        [EnumMember(Value = "UPDATE")]
        Update,

        [EnumMember(Value = "DELETE")]
        Delete,

        [EnumMember(Value = "AUTH")]
        Auth,

        [EnumMember(Value = "GET")]
        Get,
    }
}
