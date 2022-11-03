using System.Text.Json;
using System.Text.Json.Serialization;

namespace GistNet
{
    /// <summary>Rename files inside an existing Gist</summary>
    public class RenameFiles
    {
        private string StrToken { get; set; } = string.Empty;
        private string StrID { get; set; } = string.Empty;

        /// <summary>Content of the Gist</summary>
        public Details Content { get; set; } = new();


        /// <summary>
        /// Rename files inside an existing Gist
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="ID">ID of the Gist to update</param>
        public RenameFiles(string Token, string ID)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(ID)) { throw new Exception("Empty Gist ID"); }

            StrToken = Token;
            StrID = ID;
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
                using HttpRequestMessage Req = new(new HttpMethod("PATCH"), $"https://api.github.com/gists/{StrID}");
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
            /// <summary>A list of files to rename</summary>
            [JsonPropertyName("files")]
            public Dictionary<string, FileContent> Files { get; set; } = new();

            /// <summary>A class for the content of the file</summary>
            public class FileContent
            {
                /// <summary>Content of the file</summary>
                [JsonPropertyName("filename")]
                public string FileName { get; set; } = string.Empty;

                /// <summary>Content of the file</summary>
                public FileContent(string NewName)
                {
                    this.FileName = NewName;
                }
            }
        }
    }
}
