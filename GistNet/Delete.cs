namespace GistNet
{
    /// <summary>Delete an existing Gist</summary>
    public class Delete
    {
        private string StrToken { get; set; } = string.Empty;
        private string StrGistID { get; set; } = string.Empty;

        /// <summary>
        /// Delete an existing Gist
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="GistID">ID of the Gist to update</param>
        public Delete(string Token, string GistID)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(GistID)) { throw new Exception("Empty Gist ID"); }

            StrToken = Token;
            StrGistID = GistID;
        }

        /// <summary>
        /// Delete the Gist on GitHub
        /// </summary>
        /// <returns>A status code of the operation: <c>204</c> No Content; <c>304</c> Not modified; <c>403</c> Forbidden; <c>404</c> Resource not found</returns>
        /// <exception cref="Exception">Any error</exception>
        public async Task<string> Confirm()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                using HttpRequestMessage Req = new(new HttpMethod("DELETE"), $"https://api.github.com/gists/{StrGistID}");
                Req.Headers.Accept.Clear();
                Req.Headers.Add("User-Agent", "GistNet");
                Req.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                Req.Headers.Add("Authorization", "Bearer " + StrToken.Trim());

                Res = await HClnt.SendAsync(Req);
                Res.EnsureSuccessStatusCode();

                return Res.StatusCode.ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
