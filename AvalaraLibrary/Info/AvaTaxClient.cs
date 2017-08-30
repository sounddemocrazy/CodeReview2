using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    public partial class AvaTaxClient
    {
        private string _credentials;
        private string _clientHeader;
        private Uri _envUri;


        private static HttpClient _client = new HttpClient();


        /// <summary>
        /// Tracks the amount of time spent on the most recent API call
        /// </summary>
        public CallDuration LastCallTime { get; set; }

        /// <summary>
        /// Returns the version of the SDK that was compiled
        /// </summary>
#if NET45
        public static string SDK_TYPE { get { return "NET45"; } }
#endif
#if NETSTANDARD1_6
        public static string SDK_TYPE { get { return "NETSTANDARD1_6"; } }
#endif
#if NET20
        public static string SDK_TYPE { get { return "NET20"; } }
#endif
        #region Constructor
        /// <summary>
        /// Generate a client that connects to one of the standard AvaTax servers
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <param name="environment"></param>
        public AvaTaxClient(string appName, string appVersion, string machineName, AvaTaxEnvironment environment)
        {
            // Redo the client identifier
            WithClientIdentifier(appName, appVersion, machineName);

            // Setup the URI
            switch (environment)
            {
                case AvaTaxEnvironment.Sandbox: _envUri = new Uri(Constants.AVATAX_SANDBOX_URL); break;
                case AvaTaxEnvironment.Production: _envUri = new Uri(Constants.AVATAX_PRODUCTION_URL); break;
                default: throw new Exception("Unrecognized Environment");
            }
        }

        /// <summary>
        /// Generate a client that connects to a custom server
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <param name="customEnvironment"></param>
        public AvaTaxClient(string appName, string appVersion, string machineName, Uri customEnvironment)
        {
            // Redo the client identifier
            WithClientIdentifier(appName, appVersion, machineName);
            _envUri = customEnvironment;
        }
        #endregion


        #region Security
        /// <summary>
        /// Sets the default security header string
        /// </summary>
        /// <param name="headerString"></param>
        public AvaTaxClient WithSecurity(string headerString)
        {
            _credentials = headerString;
            return this;
        }

        /// <summary>
        /// Set security using username/password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public AvaTaxClient WithSecurity(string username, string password)
        {
            var combined = String.Format("{0}:{1}", username, password);
            var bytes = Encoding.UTF8.GetBytes(combined);
            var base64 = System.Convert.ToBase64String(bytes);
            return WithSecurity("Basic " + base64);
        }

        /// <summary>
        /// Set security using AccountId / License Key
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="licenseKey"></param>
        public AvaTaxClient WithSecurity(int accountId, string licenseKey)
        {
            var combined = String.Format("{0}:{1}", accountId, licenseKey);
            var bytes = Encoding.UTF8.GetBytes(combined);
            var base64 = System.Convert.ToBase64String(bytes);
            return WithSecurity("Basic " + base64);
        }

        /// <summary>
        /// Set security using a bearer token
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <returns></returns>
        public AvaTaxClient WithBearerToken(string bearerToken)
        {
            WithSecurity("Bearer " + bearerToken);
            return this;
        }
        #endregion

        #region Client Identification
        /// <summary>
        /// Configure client identification
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public AvaTaxClient WithClientIdentifier(string appName, string appVersion, string machineName)
        {
            _clientHeader = String.Format("{0}; {1}; {2}; {3}; {4}", appName, appVersion, "CSharpRestClient", API_VERSION, machineName);
            return this;
        }
        #endregion
        /// <summary>
        /// Represents an environment for AvaTax
        /// </summary>
        /// 

        public T RestCall<T>(string verb, AvaTaxPath relativePath, object content = null)
        {
            try
            {
                return RestCallAsync<T>(verb, relativePath, content).Result;

                // Unroll single-exception aggregates for ease of use
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count == 1)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }


        public async Task<T> RestCallAsync<T>(string verb, AvaTaxPath relativePath, object content = null)
        {
            CallDuration cd = new CallDuration();
            var s = await RestCallStringAsync(verb, relativePath, content, cd).ConfigureAwait(false);
            var o = JsonConvert.DeserializeObject<T>(s);
            cd.FinishParse();
            this.LastCallTime = cd;
            return o;
        }

        /// <summary>
        /// Implementation of raw string-returning async API 
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task<string> RestCallStringAsync(string verb, AvaTaxPath relativePath, object content = null, CallDuration cd = null)
        {
            if (cd == null) cd = new CallDuration();
            using (var result = await InternalRestCallAsync(cd, verb, relativePath, content).ConfigureAwait(false))
            {

                // Read the result
                var s = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Determine server duration
                var sd = result.Headers.GetValues("serverduration").FirstOrDefault();
                TimeSpan ServerDuration = new TimeSpan();
                TimeSpan.TryParse(sd, out ServerDuration);
                cd.FinishReceive(ServerDuration);

                // Deserialize the result
                if (result.IsSuccessStatusCode)
                {
                    return s;
                }
                else
                {
                    var err = JsonConvert.DeserializeObject<ErrorResult>(s);
                    cd.FinishParse();
                    this.LastCallTime = cd;
                    throw new AvaTaxError(err);
                }
            }
        }


        /// <summary>
        /// Implementation of raw request API
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="verb"></param>
        /// <param name="relativePath"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> InternalRestCallAsync(CallDuration cd, string verb, AvaTaxPath relativePath, object content)
        {
            // Setup the request
            using (var request = new HttpRequestMessage())
            {
                request.Method = new HttpMethod(verb);
                request.RequestUri = new Uri(_envUri, relativePath.ToString());

                // Add credentials and client header
                if (_credentials != null)
                {
                    request.Headers.Add("Authorization", _credentials);
                }
                if (_clientHeader != null)
                {
                    request.Headers.Add("X-Avalara-Client", _clientHeader);
                }

                // Add payload
                if (content != null)
                {
                    var json = JsonConvert.SerializeObject(content, SerializerSettings);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                // Send
                cd.FinishSetup();
                return await _client.SendAsync(request).ConfigureAwait(false);
            }
        }


        private JsonSerializerSettings _serializer_settings = null;
        private JsonSerializerSettings SerializerSettings
        {
            get
            {
                if (_serializer_settings == null)
                {
                    lock (this)
                    {
                        _serializer_settings = new JsonSerializerSettings();
                        _serializer_settings.NullValueHandling = NullValueHandling.Ignore;
                        _serializer_settings.Converters.Add(new StringEnumConverter());
                    }
                }
                return _serializer_settings;
            }
        }
    }

    public enum AvaTaxEnvironment
    {
        /// <summary>
        /// Represents the sandbox environment, https://sandbox-rest.avatax.com
        /// </summary>
        Sandbox = 0,

        /// <summary>
        /// Represents the production environment, https://rest.avatax.com
        /// </summary>
        Production = 1
    }
}
