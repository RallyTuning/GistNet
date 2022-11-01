using System.Text.Json;
using System.Text.Json.Serialization;

namespace GistNet
{
    /// <summary>Update an existing Gist by changing the description or adding a new file</summary>
    public class UpdateGist
    {
        private string StrToken { get; set; } = string.Empty;
        private string StrGistID { get; set; } = string.Empty;

        /// <summary>Content of the Gist</summary>
        public Details Content { get; set; } = new();

        /// <summary>
        /// Update an existing Gist by changing the description or adding a new file
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="GistID">ID of the Gist to update</param>
        public UpdateGist(string Token, string GistID)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(GistID)) { throw new Exception("Empty Gist ID"); }

            StrToken = Token;
            StrGistID = GistID;
        }

        /// <summary>
        /// Update the selected Gist with the new details
        /// </summary>
        /// <returns>A JSON with the Gist details</returns>
        /// <exception cref="Exception">Any error</exception>
        public async Task<string> Patch()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                HClnt.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                using HttpRequestMessage Req = new(new HttpMethod("PATCH"), $"https://api.github.com/gists/{StrGistID}");
                Req.Headers.TryAddWithoutValidation("Accept", "application/vnd.github+json");
                Req.Headers.TryAddWithoutValidation("Authorization", "Bearer " + StrToken.Trim());

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

            /// <summary>A list of files inside the Gist</summary>
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
