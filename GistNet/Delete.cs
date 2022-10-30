﻿using System.Net.Http.Headers;
using System.Text.Json;

namespace GistNet
{
    /// <summary>Delete an existing Gist</summary>
    public class Delete
    {
        /// <summary>Personal Token key from GitHub</summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>ID of the Gist to delete</summary>
        public string ID { get; set; } = string.Empty;

        /// <summary>Delete an existing Gist</summary>
        public Delete()
        {

        }

        /// <summary>
        /// Delete your Gist on GitHub
        /// </summary>
        /// <returns>A JSON with the new Gist details</returns>
        /// <exception cref="Exception">Any error</exception>
        public async Task<string> Confirm()
        {
            try
            {
                HttpResponseMessage Res;

                using HttpClient HClnt = new();
                HClnt.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                using HttpRequestMessage Req = new(new HttpMethod("DELETE"), $"https://api.github.com/gists/{ID}");
                Req.Headers.TryAddWithoutValidation("Accept", "application/vnd.github+json");
                Req.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Token.Trim());

                Res = await HClnt.SendAsync(Req);
                Res.EnsureSuccessStatusCode();

                return Res.StatusCode.ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
