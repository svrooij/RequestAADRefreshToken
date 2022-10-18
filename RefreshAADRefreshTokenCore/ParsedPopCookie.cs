using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshAADRefreshTokenCore
{
    public class ParsedPopCookie
    {
        public ParsedPopCookie(PopCookieInfo original)
        {
            Original = original;
            Details = original.Data.Split(';').Select(d => d.Trim()).ToArray();
            CookieToken = Details[0];
        }
        public PopCookieInfo Original { get; init; }
        public string? Domain { get; private set; }
        public string? Path { get; private set; }
        public string? CookieToken { get; private set; }
        public string[] Details { get; private set; }

    }
}
