using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Request states.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public enum RequestState
    {
        /// <summary>
        /// Pre-validation passed and request accepted.
        /// </summary>
        [EnumMember(Value = "ACCEPTED")]
        Accepted,

        /// <summary>
        /// The request is awaiting processing (depends on the execution of another request).
        /// </summary>
        [EnumMember(Value = "WAITING")]
        Waiting,

        /// <summary>
        /// The request was processed successfully.
        /// </summary>
        [EnumMember(Value = "SUCCESSFUL")]
        Successful,

        /// <summary>
        /// The request was processed with an error.
        /// </summary>
        [EnumMember(Value = "INVALID")]
        Invalid,
    }
}
