using System.Globalization;
using System.Net.Http.Headers;

namespace GistNet
{
    /// <summary>Browse existing Gists</summary>
    public class Browse
    {
        private string StrToken { get; set; } = string.Empty;
        private string URL { get; set; } = "https://api.github.com/users/";


        /// <summary>
        /// Browse existing Gists
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="User">User to get Gists of (If different from the Token's owner, then will only show public Gists)</param>
        public Browse(string Token, string User)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(User)) { throw new Exception("Empty User"); }

            StrToken = Token;

            URL += User + "/gists";
        }

        /// <summary>
        /// Browse existing Gists by browsing a specific page. (30 per page)
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="User">User to get Gists of (If different from the Token's owner, then will only show public Gists)</param>
        /// <param name="Page">Optional: Number of the page to check. Default is 1</param>
        public Browse(string Token, string User, int Page)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(User)) { throw new Exception("Empty User"); }

            StrToken = Token;

            URL += User + "/gists?page=" + Page;
        }

        /// <summary>
        /// Browse existing Gists from a specific date
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="User">User to get Gists of (If different from the Token's owner, then will only show public Gists)</param>
        /// <param name="Since">Only show notifications updated after the given time. This is a timestamp in ISO 8601 format: <c>YYYY-MM-DDTHH:MM:SSZ</c></param>
        public Browse(string Token, string User, DateTime Since)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(User)) { throw new Exception("Empty User"); }

            StrToken = Token;

            URL += User + "/gists?since=" + Since.ToString("o", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Browse existing Gists from a specific date, by max amount of them per page and how many in every page
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="User">User to get Gists of (If different from the Token's owner, then will only show public Gists)</param>
        /// <param name="Per_Page">Optional: Number of items per page. Default is 30</param>
        /// <param name="Page">Optional: Number of the page to check. Default is 1</param>
        public Browse(string Token, string User, int Per_Page, int Page)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(User)) { throw new Exception("Empty User"); }

            StrToken = Token;

            URL += User + "/gists?per_page=" + Per_Page + "&page=" + Page;
        }

        /// <summary>
        /// Browse existing Gists from a specific date, by max amount of them per page and how many in every page
        /// </summary>
        /// <param name="Token">Personal Token key from GitHub</param>
        /// <param name="User">User to get Gists of (If different from the Token's owner, then will only show public Gists)</param>
        /// <param name="Since">Only show updated Gists after the given time. This is a timestamp in ISO 8601 format: <c>YYYY-MM-DDTHH:MM:SSZ</c></param>
        /// <param name="Per_Page">Optional: Number of items per page. Default is 30</param>
        /// <param name="Page">Optional: Number of the page to check. Default is 1</param>
        public Browse(string Token, string User, DateTime Since, int Per_Page, int Page)
        {
            if (string.IsNullOrWhiteSpace(Token)) { throw new Exception("Empty Token"); }
            if (string.IsNullOrWhiteSpace(User)) { throw new Exception("Empty User"); }

            StrToken = Token;

            URL += User + "/gists?since=" + Since.ToString("o", CultureInfo.InvariantCulture) + "&per_page=" + Per_Page + "&page=" + Page;
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
                //HClnt.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
                HClnt.DefaultRequestHeaders.Accept.Clear();
                HClnt.DefaultRequestHeaders.Add("User-Agent", "GistNet");
                HClnt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));


                using HttpRequestMessage Req = new(new HttpMethod("GET"), URL);
                //Req.Headers.TryAddWithoutValidation("Accept", "application/vnd.github+json");
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
