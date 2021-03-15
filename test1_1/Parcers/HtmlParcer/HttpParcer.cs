using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace test1_1.Parcers.HtmlParcer
{
    class HttpParcer : IParcer
    {
        private void CleanSegments(ref Uri uri)
        {
            for (int i = 0; i < uri.Segments.Length; i++)
            {
                foreach (string param in Params.findedNames)
                {
                    if (uri.Segments[i] == param)
                    {
                        if (i < uri.Segments.Length - 1)
                            uri.Segments[i + 1] = Params.ChangeName(uri.Segments[i + 1]);
                        //else
                        //    throw ParcerException;
                    }
                }
            }
        }

        private List<QueryClass> ParceQuery(string query)
        {
            List<QueryClass> result = new List<QueryClass>();
            char[] deliverChars = new char[] { '?', '&', '/', '=' };
            string tmp = "";
            int startPos = 0;
            bool isFind = false;
            QueryClass queryClass;
            for (int i = 0; i < query.Length; i++)
            {
                isFind = false;
                foreach (char deliverChar in deliverChars)
                {
                    if (deliverChar == query[i])
                    {
                        isFind = true;
                        startPos++;
                        if (!String.IsNullOrEmpty(tmp))
                        {
                            queryClass = new QueryClass();
                            queryClass.StartPos = startPos;
                            queryClass.EndPos = i - 1;
                            queryClass.Name = tmp;
                            result.Add(queryClass);
                            startPos = i;
                        }
                        tmp = "";
                        break;
                    }
                }
                if (!isFind)
                    tmp += query[i];
            }

            queryClass = new QueryClass();
            queryClass.StartPos = startPos;
            queryClass.EndPos = query.Length;
            queryClass.Name = tmp;
            result.Add(queryClass);
            return result;
        }

        private string CleanQuery(Uri uri)
        {
            string result = uri.Scheme + "://";
            result += uri.Host;
            foreach (string segment in uri.Segments)
            {
                result += segment;
            }
            List<QueryClass> segments = ParceQuery(uri.Query);
            int lastPosSegment = 0;
            for (int i = 0; i < segments.Count; i++)
            {
                foreach (string findName in Params.findedNames)
                {
                    if (segments[i].Name == findName)
                    {
                        if (i < segments.Count - 1)
                        {
                            result += uri.Query.Substring(lastPosSegment, segments[i + 1].StartPos - lastPosSegment);
                            for (int j = segments[i + 1].StartPos; j < segments[i + 1].EndPos + 1; j++)
                            {
                                result += 'X';
                            }
                            lastPosSegment = segments[i + 1].EndPos + 1;
                            break;
                        }
                    }
                }
            }
            return result;
            //currUri.Query
        }

        public string TryParce(string str)
        {
            try
            {
                Uri currUri = new Uri(str);
                CleanSegments(ref currUri);
                return CleanQuery(currUri);
            }
            catch (UriFormatException e)
            {
                return str;
            }
            //return currUri.OriginalString;
        }
    }
}
