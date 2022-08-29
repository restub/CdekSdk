using CdekSdk.DataContracts;
using CdekSdk.Toolbox;

namespace CdekSdk
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
            return Post<AuthToken>("oauth/token?parameters", null, r =>
            {
                r.AlwaysMultipartFormData = true;
                r.AddParameters(new
                {
                    grant_type = "client_credentials",
                    client_id = clientAccount,
                    client_secret = clientSecret,
                });
            });
        }
    }
}