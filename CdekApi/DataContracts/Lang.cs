using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Supported languages.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public enum Lang
    {
        [EnumMember(Value = "rus")]
        Rus,

        [EnumMember(Value = "eng")]
        Eng,

        [EnumMember(Value = "zho")]
        Zho
    }
}
