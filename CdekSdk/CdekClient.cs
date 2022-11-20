using System;
using System.Collections.Generic;
using System.Linq;
using CdekSdk.DataContracts;
using CdekSdk.Toolbox;
using RestSharp;
using RestSharp.Authenticators;
using Restub;
using Restub.DataContracts;

namespace CdekSdk
{
    /// <summary>
    /// CDEK API Client.
    /// </summary>
    public partial class CdekClient : RestubClient
    {
        /// <summary>
        /// Sandbox API endpoint.
        /// </summary>
        public const string SandboxApiUrl = "https://api.edu.cdek.ru/v2/";

        /// <summary>
        /// Production API endpoint.
        /// </summary>
        public const string ProductionApiUrl = "https://api.cdek.ru/v2/";

        /// <summary>
        /// Initializes a new instance of the <see cref="CdekClient"/> class.
        /// </summary>
        /// <param name="baseUrl">Base API endpoint.</param>
        /// <param name="credentials">Credentials.</param>
        public CdekClient(string baseUrl, CdekCredentials credentials)
            : base(baseUrl, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CdekClient"/> class.
        /// </summary>
        /// <param name="сlient">REST API client.</param>
        /// <param name="credentials">Credentials.</param>
        public CdekClient(string baseUrl, string clientAccount, string clientSecret)
            : base(baseUrl, new CdekCredentials(clientAccount, clientSecret))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CdekClient"/> class for sandbox.
        /// </summary>
        /// <param name="сlient">REST API client.</param>
        /// <param name="credentials">Credentials.</param>
        public CdekClient() : base(SandboxApiUrl, CdekCredentials.TestCredentials)
        {
        }

        /// <inheritdoc/>
        protected override IAuthenticator GetAuthenticator() =>
            new CdekAuthenticator(this, (CdekCredentials)Credentials);

        /// <inheritdoc/>
        protected override IRestubSerializer CreateSerializer() =>
            new CdekSerializer();

        /// <inheritdoc/>
        protected override Exception CreateException(IRestResponse res, string msg, IHasErrors errors) =>
            new CdekApiException(res.StatusCode, msg, base.CreateException(res, msg, errors))
            {
                ErrorResponseText = res.Content,
            };

        /// <inheritdoc/>
        protected override IHasErrors DeserializeErrorResponse(IRestResponse response) =>
            Serializer.Deserialize<CdekErrorResponse>(response);

        /// <summary>
        /// Produces single error message from a collection of errors.
        /// </summary>
        /// <param name="errors">List of errors.</param>
        /// <returns>Concatenated error message.</returns>
        internal static string GetErrorMessage(IEnumerable<Error> errors) =>
            string.Join(". ", (errors ?? Enumerable.Empty<Error>())
                .Select(e => e.Message)
                .Distinct()
                .Where(s => !string.IsNullOrWhiteSpace(s)));
    }
}