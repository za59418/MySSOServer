using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using IdentityModel;
using IdentityModel.Client;
using Microsoft.IdentityModel.Protocols;

namespace DCI.SSO.ClientLib
{
    public partial class SSOLoginCtrl : UserControl
    {
        public event EventHandler<LoginResult> Done;
        OpenIdConnectConfiguration _config;
        OidcSettings _settings;
        string _nonce;
        string _verifier;
        public Form Window { get; set; }

        public SSOLoginCtrl()
        {
            InitializeComponent();
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
        }

        public void Init(string ClientId, string ServerUrl, string ClientUrl)
        {
            _settings = new OidcSettings
            {
                Authority = ServerUrl,
                ClientId = ClientId,
                ClientSecret = "secret",
                RedirectUri = ClientUrl,
                Scope = "openid logon profile write",
                LoadUserProfile = true
            };
        }

        public async Task LoginAsync()
        {
            if (_config == null)
            {
                await LoadOpenIdConnectConfigurationAsync();
            }

            //this.Visible = true;
            if (null != this.Window)
                this.Window.Visible = true;
            string url = CreateUrl();

            webBrowser1.Navigate(url);
        }

        private string CreateUrl()
        {
            _nonce = CryptoRandom.CreateUniqueId(32);
            _verifier = CryptoRandom.CreateUniqueId(32);
            var challenge = _verifier.ToCodeChallenge();

            var request = new AuthorizeRequest(_config.AuthorizationEndpoint);

            return request.CreateAuthorizeUrl(
                clientId: _settings.ClientId,
                responseType: "code id_token",
                scope: _settings.Scope,
                redirectUri: _settings.RedirectUri,
                nonce: _nonce,
                responseMode: OidcConstants.ResponseModes.FormPost,
                codeChallenge: challenge,
                codeChallengeMethod: OidcConstants.CodeChallengeMethods.Sha256);
        }

        private async Task LoadOpenIdConnectConfigurationAsync()
        {
            var discoAddress = _settings.Authority + "/.well-known/openid-configuration";

            var manager = new ConfigurationManager<OpenIdConnectConfiguration>(discoAddress);
            _config = await manager.GetConfigurationAsync();
        }

        private async void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().StartsWith(_settings.RedirectUri))
            {
                AuthorizeResponse response;
                if (e.Url.AbsoluteUri.Contains("#"))
                {
                    response = new AuthorizeResponse(e.Url.AbsoluteUri);
                }
                else
                {
                    HtmlDocument document = ((WebBrowser)sender).Document;
                    if (null != document)
                    {
                        var inputElements = document.GetElementsByTagName("INPUT").OfType<HtmlElement>();
                        var resultUrl = "?";

                        foreach (var input in inputElements)
                        {
                            resultUrl += input.GetAttribute("name") + "=";
                            resultUrl += input.GetAttribute("value") + "&";
                        }

                        e.Cancel = true;
                        //this.Visible = false;
                        if (null != this.Window)
                            this.Window.Visible = false;
                        resultUrl = resultUrl.TrimEnd('&');
                        response = new AuthorizeResponse(resultUrl);
                    }
                    else
                    {
                        response = null;
                    }
                }
                if (null != response)
                {
                    var loginResult = await ValidateResponseAsync(response);
                    Done?.Invoke(this, loginResult);
                }
            }
        }

        private async Task<LoginResult> ValidateResponseAsync(AuthorizeResponse response)
        {
            // id_token validieren
            var tokenClaims = ValidateIdentityToken(response.IdentityToken);

            if (tokenClaims == null)
            {
                return new LoginResult { ErrorMessage = "Invalid identity token." };
            }

            // nonce validieren
            var nonce = tokenClaims.FirstOrDefault(c => c.Type == JwtClaimTypes.Nonce);

            if (nonce == null || !string.Equals(nonce.Value, _nonce, StringComparison.Ordinal))
            {
                return new LoginResult { ErrorMessage = "Inalid nonce." };
            }

            // c_hash validieren
            var c_hash = tokenClaims.FirstOrDefault(c => c.Type == JwtClaimTypes.AuthorizationCodeHash);

            if (c_hash == null || ValidateCodeHash(c_hash.Value, response.Code) == false)
            {
                return new LoginResult { ErrorMessage = "Invalid code." };
            }

            // code eintauschen gegen tokens
            var tokenClient = new TokenClient(
                _config.TokenEndpoint,
                _settings.ClientId,
                _settings.ClientSecret);

            var tokenResponse = await tokenClient.RequestAuthorizationCodeAsync(
                code: response.Code,
                redirectUri: _settings.RedirectUri,
                codeVerifier: _verifier);

            if (tokenResponse.IsError)
            {
                return new LoginResult { ErrorMessage = tokenResponse.Error };
            }

            // optional userinfo aufrufen
            var profileClaims = new List<Claim>();
            if (_settings.LoadUserProfile)
            {
                var userInfoClient = new UserInfoClient(
                    new Uri(_config.UserInfoEndpoint),
                    tokenResponse.AccessToken);

                var userInfoResponse = await userInfoClient.GetAsync();
                profileClaims = userInfoResponse.GetClaimsIdentity().Claims.ToList();
            }

            var principal = CreatePrincipal(tokenClaims, profileClaims);

            return new LoginResult
            {
                Success = true,
                User = principal,
                IdentityToken = response.IdentityToken,
                AccessToken = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken,
                AccessTokenExpiration = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn)
            };
        }

        private ClaimsPrincipal CreatePrincipal(List<Claim> tokenClaims, List<Claim> profileClaims)
        {
            List<Claim> filteredClaims = new List<Claim>(tokenClaims);

            if (_settings.FilterClaims)
            {
                filteredClaims = tokenClaims.Where(c => !_settings.FilterClaimTypes.Contains(c.Type)).ToList();
            }

            var allClaims = new List<Claim>();
            allClaims.AddRange(filteredClaims);
            allClaims.AddRange(profileClaims);

            var id = new ClaimsIdentity(allClaims.Distinct(new ClaimComparer()), "OIDC");
            return new ClaimsPrincipal(id);
        }

        private bool ValidateCodeHash(string c_hash, string code)
        {
            using (var sha = SHA256.Create())
            {
                var codeHash = sha.ComputeHash(Encoding.ASCII.GetBytes(code));
                byte[] leftBytes = new byte[16];
                Array.Copy(codeHash, leftBytes, 16);

                var codeHashB64 = Base64Url.Encode(leftBytes);

                return string.Equals(c_hash, codeHashB64, StringComparison.Ordinal);
            }
        }

        private List<Claim> ValidateIdentityToken(string identityToken)
        {
            var tokens = new List<X509SecurityToken>(
                from key in _config.JsonWebKeySet.Keys
                select new X509SecurityToken(new X509Certificate2(Convert.FromBase64String(key.X5c.First()))));

            var parameter = new TokenValidationParameters
            {
                ValidIssuer = _config.Issuer,
                ValidAudience = _settings.ClientId,
                IssuerSigningTokens = tokens
            };

            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();
            var handler = new JwtSecurityTokenHandler();

            SecurityToken token;
            try
            {
                return handler.ValidateToken(identityToken, parameter, out token).Claims.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
