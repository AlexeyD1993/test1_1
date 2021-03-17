using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace test1_1.Parcers.HtmlParcer
{
    class HttpParcer : IParcer
    {
        private void CleanSegments(UriBuilder uri)
        {
            string[] segments = uri.Path.Split('/');

            for (int i = 0; i < segments.Length; i++)
            {
                if (String.IsNullOrEmpty(segments[i]))
                    continue;
                foreach (string param in Params.findedNames)
                {
                    if (segments[i].ToUpper() == param.ToUpper())
                    {
                        if (i < segments.Length - 1)
                            segments[i + 1] = Params.ChangeName(segments[i + 1]);
                    }
                }
            }
            uri.Path = "";
            foreach (string segment in segments)
            {
                if (!String.IsNullOrEmpty(segment))
                    uri.Path += segment + '/';
            }
            uri.Path = uri.Path.Remove(uri.Path.Length - 1);
        }

        private void CleanQuery(UriBuilder uri)
        {
            string[] queries = uri.Query.Split('&');
            if (queries[0] == "")
                return;
            uri.Query = "";
            foreach (string query in queries)
            {
                string[] paramStrings = query.Split('=');
                foreach (string paramName in Params.findedNames)
                {
                    if (paramStrings[0].Trim('?') == paramName)
                        paramStrings[1] = Params.ChangeName(paramStrings[1]);
                }
                uri.Query += paramStrings[0] + "=" + paramStrings[1] + "&";
            }
            uri.Query = uri.Query.Remove(uri.Query.Length - 1);
        }

        public string TryParce(string str)
        {
            try
            {
                Uri currUri = new Uri(str); // для попытки распарсить строку
                
                UriBuilder uri = new UriBuilder(str);
                CleanSegments(uri);
                CleanQuery(uri);
                if (uri.Path.Length == 1)
                    return uri.Uri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port & ~UriComponents.Path,
                               UriFormat.UriEscaped);
                
                return uri.Uri.ToString();
            }
            catch (UriFormatException e)
            {
                return str;
            }
        }
    }
}
