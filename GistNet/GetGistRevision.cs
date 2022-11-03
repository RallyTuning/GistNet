namespace GistNet
{
    /// <summary>Get a single Gist by their ID</summary>
    public class GetGistRevision
    {
        private string StrToken { get; set; } = string.Empty;
        private string StrID { get; set; } = string.Empty;
        private string StrRevision { get; set; } = string.Empty;


        /// <summary>
        /// Get a single Gist by their ID
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="ID">ID of the Gist to obtain</param>
        /// <param name="Revision">The SHA of the requested revision</param>
        public GetGistRevision(string Token, string ID, string Revision)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(ID)) { throw new Exception("Empty Gist ID"); }
            if (string.IsNullOrWhiteSpace(Revision)) { throw new Exception("Empty Revision SHA"); }

            StrToken = Token;
            StrID = ID;
            StrRevision = Revision;
        }


        /// <summary>
        /// Get a single Gist by their ID
        /// </summary>
        /// <returns>A JSON with the Gist details</returns>
        /// <exception cref="Exception">Any error</exception>
        public async Task<string> Get()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                using HttpRequestMessage Req = new(new HttpMethod("GET"), $"https://api.github.com/gists/{StrID}/{StrRevision}");
                Req.Headers.Accept.Clear();
                Req.Headers.Add("User-Agent", "GistNet");
                Req.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                Req.Headers.Add("Authorization", "Bearer " + StrToken.Trim());

                Res = await HClnt.SendAsync(Req);
                Res.EnsureSuccessStatusCode();

                string StrRes = await Res.Content.ReadAsStringAsync();

                return StrRes;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
