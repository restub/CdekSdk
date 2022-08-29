using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdekApi.DataContracts;

namespace CdekApi
{
    /// <summary>
    /// CDEK API Credentials.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// CDEK test account, see https://api-docs.cdek.ru/29923849.html.
        /// </summary>
        public static Credentials TestCredentials { get; } = new Credentials
        {
            ClientAccount = "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI",
            ClientSecret = "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG",
        };

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
        public AuthToken Authenticate(CdekClient client) =>
            client.GetAuthToken(ClientAccount, ClientSecret);
    }
}
