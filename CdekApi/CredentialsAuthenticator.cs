using CdekApi.DataContracts;
using RestSharp;
using RestSharp.Authenticators;

namespace CdekApi
{
    /// <summary>
    /// CDEK API authenticator using credentials.
    /// </summary>
    internal class CredentialsAuthenticator : IAuthenticator
    {
        public CredentialsAuthenticator(CdekClient apiClient, Credentials credentials)
        {
            State = AuthState.NotAuthenticated;
            Client = apiClient;
            Credentials = credentials;
        }

        private CdekClient Client { get; set; }

        private Credentials Credentials { get; set; }

        private AuthState State { get; set; }

        private enum AuthState
        {
            NotAuthenticated, InProgress, Authenticated
        }

        internal AuthToken AuthToken { get; set; }

        private string AuthHeader { get; set; }

        public void SetAuthToken(AuthToken authToken)
        {
            AuthHeader = string.IsNullOrWhiteSpace(authToken?.AccessToken) ?
                null : $"{authToken.TokenType ?? "Bearer"} " + authToken.AccessToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            // perform authentication request
            if (State == AuthState.NotAuthenticated)
            {
                State = AuthState.InProgress;
                AuthToken = Credentials.Authenticate(Client);
                SetAuthToken(AuthToken);
                State = AuthState.Authenticated;
            }

            // add authorization header if any
            if (!string.IsNullOrWhiteSpace(AuthHeader))
            {
                request.AddOrUpdateParameter("Authorization", AuthHeader, ParameterType.HttpHeader);
            }
        }

        public void Logout()
        {
            State = AuthState.NotAuthenticated;
            AuthToken = null;
        }
    }
}
