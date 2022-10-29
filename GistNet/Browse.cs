using System.Text.Json.Nodes;

namespace GistNet
{
    public class Browse
    {
        public string Token { get; set; } = String.Empty;
        public string User { get; set; } = string.Empty;

        public Browse()
        {

        }

        public async Task<string> Get()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                HClnt.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                using HttpRequestMessage Req = new(new HttpMethod("GET"), $"https://api.github.com/users/{User}/gists");
                Req.Headers.TryAddWithoutValidation("Accept", "application/vnd.github+json");
                Req.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token.Trim());

                Res = await HClnt.SendAsync(Req);
                Res.EnsureSuccessStatusCode();

                string StrRes = await Res.Content.ReadAsStringAsync();
                //return JsonObject.Parse(StrResp)!.AsObject();
                return StrRes;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
