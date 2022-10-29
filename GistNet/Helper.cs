using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GistNet
{
    public static class Helper
    {
        public static async Task<JsonObject> ToJson(this HttpResponseMessage Resp)
        {
            try
            {
                string StrResp = await Resp.Content.ReadAsStringAsync();
                return JsonNode.Parse(StrResp)!.AsObject();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
