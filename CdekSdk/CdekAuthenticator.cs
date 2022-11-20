using CdekSdk.DataContracts;
using Restub;

namespace CdekSdk
{
    /// <summary>
    /// CDEK API authenticator using credentials.
    /// </summary>
    internal class CdekAuthenticator : Authenticator<CdekClient, CdekAuthToken>
    {
        public CdekAuthenticator(CdekClient apiClient, CdekCredentials credentials)
            : base(apiClient, credentials)
        {
        }

        public override void InitAuthHeaders(CdekAuthToken authToken) =>
            AuthHeaders["Authorization"] = $"Bearer {authToken.AccessToken}";
    }
}
