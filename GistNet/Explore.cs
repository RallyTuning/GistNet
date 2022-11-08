using System.Globalization;

namespace GistNet
{
    /// <summary>Explore public Gists</summary>
    public class Explore
    {
        private string StrToken { get; set; } = string.Empty;
        private string URL { get; set; } = "https://api.github.com/gists";


        /// <summary>
        /// Explore public Gists
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        public Explore(string Token)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }

            StrToken = Token;
        }

        /// <summary>
        /// Explore public Gists by browsing a specific page. (30 per page)
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="Page">Optional: Number of the page to check. Default is 1</param>
        public Explore(string Token, int Page)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }

            StrToken = Token;

            URL += "?page=" + Page;
        }

        /// <summary>
        /// Explore public Gists from a specific date, by max amount of them per page and how many in every page
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="Per_Page">Optional: Number of items per page. Default is 30</param>
        /// <param name="Page">Optional: Number of the page to check. Default is 1</param>
        public Explore(string Token, int Per_Page, int Page)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }

            StrToken = Token;

            URL += "?per_page=" + Per_Page + "&page=" + Page;
        }

        /// <summary>
        /// Explore public Gists from a specific date
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="Since">Only show notifications updated after the given time. This is a timestamp in ISO 8601 format: <c>YYYY-MM-DDTHH:MM:SSZ</c></param>
        public Explore(string Token, DateTime Since)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            StrToken = Token;

            URL += "?since=" + Since.ToString("o", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Explore public Gists from a specific date, by max amount of them per page and how many in every page
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="Since">Only show updated Gists after the given time. This is a timestamp in ISO 8601 format: <c>YYYY-MM-DDTHH:MM:SSZ</c></param>
        /// <param name="Per_Page">Optional: Number of items per page. Default is 30</param>
        /// <param name="Page">Optional: Number of the page to check. Default is 1</param>
        public Explore(string Token, DateTime Since, int Per_Page, int Page)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }

            StrToken = Token;

            URL += "?since=" + Since.ToString("o", CultureInfo.InvariantCulture) + "&per_page=" + Per_Page + "&page=" + Page;
        }


        /// <summary>
        /// Explore public Gists
        /// </summary>
        /// <returns>A big JSON with all the public Gists of the specific user</returns>
        /// <exception cref="Exception">Any error</exception>
        public async Task<string> GetAll()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                using HttpRequestMessage Req = new(new HttpMethod("GET"), URL);
                Req.Headers.Accept.Clear();
                Req.Headers.Add("User-Agent", "GistNet");
                Req.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

                Res = await HClnt.SendAsync(Req);
                Res.EnsureSuccessStatusCode();

                string StrRes = await Res.Content.ReadAsStringAsync();

                return StrRes;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
