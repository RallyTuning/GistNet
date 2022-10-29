using System.Net.Http.Headers;
using System.Text.Json;
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

        public async Task<HttpResponseMessage> Push()
        {
            try
            {
                HttpResponseMessage response;

                using (HttpClient httpClient = new())
                {
                    httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                    using (HttpRequestMessage request = new(new HttpMethod("POST"), "https://api.github.com/gists"))
                    {
                        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.github+json");
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token.Trim());

                        request.Content = new StringContent(JsonSerializer.Serialize(Content));
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                        response = await httpClient.SendAsync(request);

                        response.EnsureSuccessStatusCode();
                    }
                }
                return response;
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