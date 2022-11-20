using CdekSdk.DataContracts;
using Restub;

namespace CdekSdk
{
    /// <summary>
    /// CDEK API Credentials.
    /// </summary>
    public class CdekCredentials : Credentials<CdekClient, CdekAuthToken>
    {
        /// <summary>
        /// CDEK test account, see https://api-docs.cdek.ru/29923849.html.
        /// </summary>
        public static CdekCredentials TestCredentials { get; } = new CdekCredentials
        {
            ClientAccount = "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI",
            ClientSecret = "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG",
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CdekCredentials"/> class.
        /// </summary>
        public CdekCredentials()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CdekCredentials"/> class.
        /// </summary>
        /// <param name="clientAccount">Client account.</param>
        /// <param name="clientSecret">Client secret.</param>
        public CdekCredentials(string clientAccount, string clientSecret)
        {
            ClientAccount = clientAccount;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Gets or sets client account identifier.
        /// </summary>
        public string ClientAccount { get; set; }

        /// <summary>
        /// Gets or sets client API secret, or password.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Authenticates the client using account/secret pair.
        /// </summary>
        /// <param name="client">API client.</param>
        public override CdekAuthToken Authenticate(CdekClient client) =>
            client.GetAuthToken(ClientAccount, ClientSecret);
    }
}
