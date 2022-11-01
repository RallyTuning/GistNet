﻿namespace GistNet
{
    /// <summary>Get a single Gist by their ID</summary>
    public class GetByID
    {
        private string StrToken { get; set; } = string.Empty;
        private string StrID { get; set; } = string.Empty;

        /// <summary>
        /// Get a single Gist by their ID
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="ID">ID of the Gist to obtain</param>
        public GetByID(string Token, string ID)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }

            StrToken = Token;
            StrID = ID;
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
                HClnt.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                using HttpRequestMessage Req = new(new HttpMethod("GET"), $"https://api.github.com/gists/{StrID}");
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
