using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents error messages.
    /// </summary>
    [DataContract]
    public class ErrorResponse : IHasErrors
    {
        [DataMember(Name = "errors")]
        public List<Error> Errors { get; set; }
    }
}
