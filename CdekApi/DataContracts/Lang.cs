using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Supported languages.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    public enum Lang
    {
        [DataMember(Name = "rus")]
        Rus,

        [DataMember(Name = "eng")]
        Eng,

        [DataMember(Name = "zho")]
        Zho
    }
}
