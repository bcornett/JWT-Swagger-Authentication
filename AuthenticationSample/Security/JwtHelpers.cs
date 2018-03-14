using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationSample.Security
{
    public class JwtHelpers
    {
        private const string PlainTextSecurityKey = "This is my shared, not so secret, secret!";

        public const string Audience = "http://localhost:54335/";
        public const string Issuer = "http://localhost:54335/";

        public static SymmetricSecurityKey Key =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PlainTextSecurityKey));
}
}
