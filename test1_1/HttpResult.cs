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

        public static bool operator ==(HttpResult res1, HttpResult res2)
        {
            if ((res1.Url == res2.Url) &&
                (res1.RequestBody == res2.RequestBody) && 
                (res1.ResponseBody == res2.ResponseBody))
                    return true;
            else
                return false;
        }
        public static bool operator !=(HttpResult res1, HttpResult res2)
        {
            if ((res1.Url == res2.Url) && 
                (res1.RequestBody == res2.RequestBody) && 
                (res1.ResponseBody == res2.ResponseBody))
                    return false;
            else
                return true;
        }
    }
}
