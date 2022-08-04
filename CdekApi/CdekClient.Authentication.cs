using CdekApi.DataContracts;
using RestSharp;

namespace CdekApi
{
    /// <remarks>
    /// CDEK API Client, athentication primitives.
    /// </remarks>
    public partial class CdekClient
    {
        /// <summary>
        /// Acquires a JWT token for the CDEK API.
        /// </summary>
        /// <param name="clientAccount">Account identifier.</param>
        /// <param name="clientSecret">Client secret or password.</param>
        internal AuthToken GetAuthToken(string clientAccount, string clientSecret)
        {
            // POST request using multipart form data
            var restRequest = new RestRequest("oauth/token?parameters", Method.POST)
            {
                AlwaysMultipartFormData = true,
            }
            .AddParameter("grant_type", "client_credentials")
            .AddParameter("client_id", clientAccount)
            .AddParameter("client_secret", clientSecret);

            // doesn't work this way:
            //var token = Post<AuthToken>("oauth/token?parameters", null, new[]
            //{
            //    new Parameter("grant_type", "client_credentials", ,
            //    client_id = clientAccount,
            //    client_secret = clientSecret,
            //});

            return Execute<AuthToken>(restRequest);
        }
    }
}