namespace GistNet
{
    /// <summary>Get a single Gist by their ID</summary>
    public  class GetByID
    {
        /// <summary>Personal Token key from GitHub</summary>
        private string StrToken { get; set; } = string.Empty;

        /// <summary>
        /// Get a single Gist by their ID
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        public GetByID(string Token)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }

            StrToken = Token;
        }

        /// <summary>
        /// Get a single Gist by their ID
        /// </summary>
        /// <param name="ID">ID of the Gist to obtain</param>
        /// <returns>A JSON with the Gist details</returns>
        /// <exception cref="Exception">Any error</exception>
        public async Task<string> Get(string ID)
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                HClnt.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                using HttpRequestMessage Req = new(new HttpMethod("GET"), $"https://api.github.com/gists/{ID}");
                Req.Headers.TryAddWithoutValidation("Accept", "application/vnd.github+json");
                Req.Headers.TryAddWithoutValidation("Authorization", "Bearer " + StrToken.Trim());

                Res = await HClnt.SendAsync(Req);
                Res.EnsureSuccessStatusCode();

                string StrRes = await Res.Content.ReadAsStringAsync();

                return StrRes;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

    }
}
