using System.Text.Json;
using System.Text.Json.Serialization;

namespace GistNet
{
    /// <summary>Create a new Gist</summary>
    public class Create
    {
        private string StrToken { get; set; } = string.Empty;

        /// <summary>Content of the Gist</summary>
        public Details Content { get; set; } = new();


        /// <summary>
        /// Create a new Gist
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        public Create(string Token)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }

            StrToken = Token;
        }


        /// <summary>
        /// Push the new Gist on GitHub
        /// </summary>
        /// <returns>A JSON with the new Gist details</returns>
        /// <exception cref="Exception">Any error</exception>
        public async Task<string> Push()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                using HttpRequestMessage Req = new(new HttpMethod("POST"), "https://api.github.com/gists");
                Req.Headers.Accept.Clear();
                Req.Headers.Add("User-Agent", "GistNet");
                Req.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                Req.Headers.Add("Authorization", "Bearer " + StrToken.Trim());

                Req.Content = new StringContent(JsonSerializer.Serialize(Content));
                Req.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                Res = await HClnt.SendAsync(Req);
                Res.EnsureSuccessStatusCode();

                string StrRes = await Res.Content.ReadAsStringAsync();

                return StrRes;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        /// <summary>THe content Gist class</summary>
        public class Details
        {
            /// <summary>A short description of the Gist</summary>
            [JsonPropertyName("description")]
            public string Description { get; set; } = string.Empty;

            /// <summary>The visibility of the Gist, <see langword="true"/> for public or <see langword="false"/> for private</summary>
            [JsonPropertyName("public")]
            public bool IsPublic { get; set; } = true;

            /// <summary>A list of files to attach to the Gist</summary>
            [JsonPropertyName("files")]
            public Dictionary<string, FileContent> Files { get; set; } = new();

            /// <summary>A class for the content of the file</summary>
            public class FileContent
            {
                /// <summary>Content of the file</summary>
                [JsonPropertyName("content")]
                public string Content { get; set; } = string.Empty;

                /// <summary>Content of the file</summary>
                public FileContent(string Content)
                {
                    this.Content = Content;
                }
            }
        }
    }
}