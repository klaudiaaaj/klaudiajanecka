using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;
using WebAPI.Interfaces;

namespace WebAPI.Services
{
    public class AuthorizationService: IAuthorizationService
    {
        public IConfiguration _cfg { get; set; }
        public AuthorizationService(IConfiguration cfg)
        {
            _cfg = cfg;
        }

        public bool IsGithubPushAllowed(string payload, string eventName, string signatureWithPrefix)
        {
            string Sha1Prefix = "sha1=";

            if (string.IsNullOrWhiteSpace(payload))
            {
                throw new ArgumentNullException(nameof(payload));
            }
            if (string.IsNullOrWhiteSpace(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }
            if (string.IsNullOrWhiteSpace(signatureWithPrefix))
            {
                throw new ArgumentNullException(nameof(signatureWithPrefix));
            }

            if (signatureWithPrefix.StartsWith(Sha1Prefix, StringComparison.OrdinalIgnoreCase))
            {
                var signature = signatureWithPrefix.Substring(Sha1Prefix.Length);
                var secret = Encoding.ASCII.GetBytes(_cfg.GetValue<string>("Webhooks:Github:SecretKey:Push"));

                var payloadBytes = Encoding.ASCII.GetBytes(payload);

                using (var hmSha1 = new HMACSHA1(secret))
                {
                    var hash = hmSha1.ComputeHash(payloadBytes);

                    var hashString = ToHexString(hash);

                    if (hashString.Equals(signature))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string ToHexString(byte[] bytes)
        {
            var builder = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                builder.AppendFormat("{0:x2}", b);
            }

            return builder.ToString();

        }
    }
}

