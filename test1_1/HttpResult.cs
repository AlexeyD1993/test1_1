using System;
using System.Collections.Generic;
using System.Text;

namespace test1_1
{
    public class HttpResult
    {
        public HttpResult()
        {
        }
        public string Url { get; set; } = "";
        public string RequestBody { get; set; } = "";
        public string ResponseBody { get; set; } = "";

        public HttpResult(string url, string requestBody, string responseBody)
        {
            this.Url = url;
            this.RequestBody = requestBody;
            this.ResponseBody = responseBody;
        }

        private static string RemoveSpaceAndEndOfLine(string line)
        {
            //string result = line.Trim('\r', '\n', ' '); //Почему-то трим не работает. Придется делать через реплейс
            string result = line.Replace("\r", "");
            result = result.Replace("\n", "");
            result = result.Replace(" ", "");
            return result;
        }

        public static bool operator ==(HttpResult res1, HttpResult res2)
        {
            if ((res1.Url == res2.Url) &&
                (RemoveSpaceAndEndOfLine(res1.RequestBody) == RemoveSpaceAndEndOfLine(res2.RequestBody)) && 
                (RemoveSpaceAndEndOfLine(res1.ResponseBody) == RemoveSpaceAndEndOfLine(res2.ResponseBody)))
                    return true;
            else
                return false;
        }
        public static bool operator !=(HttpResult res1, HttpResult res2)
        {
            if ((res1.Url == res2.Url) && 
                (RemoveSpaceAndEndOfLine(res1.RequestBody) == RemoveSpaceAndEndOfLine(res2.RequestBody)) && 
                (RemoveSpaceAndEndOfLine(res1.ResponseBody) == RemoveSpaceAndEndOfLine(res2.ResponseBody)))
                    return false;
            else
                return true;
        }
    }
}
