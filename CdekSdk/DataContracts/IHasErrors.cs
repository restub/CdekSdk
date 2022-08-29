using System.Collections.Generic;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Interface for REST responses containing error collections.
    /// </summary>
    public interface IHasErrors
    {
        /// <summary>
        /// Gets the errors.
        /// </summary>
        List<Error> Errors { get; }
    }
}
