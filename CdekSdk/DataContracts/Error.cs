using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Single error message and code.
    /// </summary>
    [DataContract]
    public class Error
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
