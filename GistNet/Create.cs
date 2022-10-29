using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace GistNet
{
    public class Create
    {
        public string Token { get; set; } = String.Empty;
        public Gist Content { get; set; } = new();

        public Create()
        {

        }

        public async Task<string> Push()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                HClnt.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                using HttpRequestMessage Req = new(new HttpMethod("POST"), "https://api.github.com/gists");
                Req.Headers.TryAddWithoutValidation("Accept", "application/vnd.github+json");
                Req.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token.Trim());

                Req.Content = new StringContent(JsonSerializer.Serialize(Content));
                Req.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                Res = await HClnt.SendAsync(Req);
                Res.EnsureSuccessStatusCode();

                string StrRes = await Res.Content.ReadAsStringAsync();
                //return JsonNode.Parse(StrResp)!.AsObject();
                return StrRes;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public class Gist
        {
            [JsonPropertyName("description")]
            public string Description { get; set; } = String.Empty;
            [JsonPropertyName("public")]
            public bool IsPublic { get; set; } = true;
            [JsonPropertyName("files")]
            public Dictionary<string, FileContent> FilesList { get; set; } = new();

            public class FileContent
            {
                [JsonPropertyName("content")]
                public string Content { get; set; } = String.Empty;

                public FileContent(string Content)
                {
                    this.Content = Content;
                }
            }
        }
    }
}