using RefreshAADRefreshTokenCore;
using System.Diagnostics;
using System.Text.Json;

var uris = new[] { "https://login.microsoftonline.com/" };

if (args.Length > 0)
    uris = args;

Console.WriteLine("Requesting cookies for the following URIs: " + String.Join(",", uris));
Console.WriteLine($"Process    : {Process.GetCurrentProcess().Id}");
Console.WriteLine($"Thread ID  : {AppDomain.GetCurrentThreadId()}\n");

try
{
    foreach (var uri in uris)
    {
        var cookies = ProofOfPossessionCookieInfoManager
            .GetCookieInfoForUri(uri)
            .ToList();

        Console.WriteLine($"Uri: {uri}");
        

        if (cookies.Any())
        {

            Console.WriteLine("--- COOKIE ---");
            foreach (var c in cookies)
            {
                var parsed = new ParsedPopCookie(c);
                var json = JsonSerializer.Serialize<ParsedPopCookie>(parsed, new JsonSerializerOptions(JsonSerializerDefaults.General)
                {
                    WriteIndented = true,
                });
                Console.WriteLine(json);
                //Console.WriteLine($"    Name      : {c.Name}");
                //Console.WriteLine($"    Flags     : {c.Flags}");
                //Console.WriteLine($"    Data      : {c.Data}");
                //Console.WriteLine($"    P3PHeader : {c.P3PHeader}\n");
            }
            Console.WriteLine("--- COOKIE END ---");
        }
        else
        {
            Console.WriteLine($"    No cookies\n");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Unhandled exception: " + e);
}

Console.WriteLine("DONE");
Console.ReadLine();