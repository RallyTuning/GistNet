using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace GistNet
{
    /// <summary>Create a new Gist</summary>
    public class Create
    {
        /// <summary>Personal Token key from GitHub</summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>Content of your Gist</summary>
        public Gist Content { get; set; } = new();

        /// <summary>Create a new Gist</summary>
        public Create()
        {

        }

        /// <summary>
        /// Push your new Gist on GitHub
        /// </summary>
        /// <returns>A JSON with the new Gist details</returns>
        /// <exception cref="Exception">Any error</exception>
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

                return StrRes;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>THe content Gist class</summary>
        public class Gist
        {
            /// <summary>A short description of your Gist</summary>
            [JsonPropertyName("description")]
            public string Description { get; set; } = string.Empty;

            /// <summary>Choose if the Gist is public or private</summary>
            [JsonPropertyName("public")]
            public bool IsPublic { get; set; } = true;

            /// <summary>A list of files inside your Gist</summary>
            [JsonPropertyName("files")]
            public Dictionary<string, FileContent> FilesList { get; set; } = new();

            /// <summary>A class for the content of your file</summary>
            public class FileContent
            {
                /// <summary>Content of your file</summary>
                [JsonPropertyName("content")]
                public string Content { get; set; } = string.Empty;

                /// <summary>Content of your file</summary>
                public FileContent(string Content)
                {
                    this.Content = Content;
                }
            }
        }
    }
}