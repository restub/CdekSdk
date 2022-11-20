using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using CdekSdk.DataContracts;
using Restub;
using Restub.DataContracts;

namespace CdekSdk
{
    /// <summary>
    /// CDEK API Exception.
    /// </summary>
    [Serializable]
    public class CdekApiException : RestubException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CdekApiException"/> class.
        /// </summary>
        /// <param name="code">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner <see cref="Exception"/> instance.</param>
        public CdekApiException(HttpStatusCode code, string message, Exception innerException)
            : base(code, GetMessage(code, message), innerException)
        {
        }

        private static string GetMessage(HttpStatusCode code, string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                return message;
            }

            return code.ToString();
        }

        /// <inheritdoc/>
        protected CdekApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <inheritdoc/>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
