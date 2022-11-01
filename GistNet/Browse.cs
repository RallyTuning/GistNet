namespace GistNet
{
    /// <summary>Browse existing Gists</summary>
    public class Browse
    {
        /// <summary>Personal Token key from GitHub</summary>
        private string StrToken { get; set; } = string.Empty;

        /// <summary>User to get Gists of (If different from the Token's owner, then will only show public Gists)</summary>
        private string StrUser { get; set; } = string.Empty;

        /// <summary>
        /// Browse existing Gists
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="User">User to get Gists of (If different from the Token's owner, then will only show public Gists)</param>
        public Browse(string Token,string User)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(User)) { throw new Exception("Empty User"); }

            StrToken = Token;
            StrUser = User;
        }

        /// <summary>
        /// Get a list of any Gist of the logged user
        /// </summary>
        /// <returns>A big JSON with all the user Gist</returns>
        /// <exception cref="Exception">Any error</exception>
        public async Task<string> GetAll()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                HClnt.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                using HttpRequestMessage Req = new(new HttpMethod("GET"), $"https://api.github.com/users/{StrUser}/gists");
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
