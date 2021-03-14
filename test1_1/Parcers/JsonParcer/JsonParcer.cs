using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test1_1.Parcers.JsonParcer
{
    class JsonParcer : IParcer
    {
        public JsonParcer()
        { 
        }

        private JToken RecourceFind(JToken host)
        {
            List<JToken> childrens = host.Children().ToList();
            foreach (JToken currElem in childrens)
            {
                host.Replace(RecourceFind(currElem));
            }
            foreach (string findedName in Params.findedNames)
            {
                if (host.Value<string>() == findedName)
                {
                    host.Replace(Params.ChangeName(host.Value<string>()));
                }
            }
            host.Replace(RecourceFind(host.Next));

            return host;
        }

        //Params.findedNames
        //private JObject RecourceFind(JObject host)
        //{   
        //    return result;
        //}

        public string TryParce(string str)
        {
            try
            {
                JObject data = (JObject)JsonConvert.DeserializeObject(str);

                RecourceFind(data.First);
                //data = (JObject)RecourceFind(data);

                //foreach (string findedName in Params.findedNames)
                //{
                //    //IEnumerable<JToken> jTokens = data.SelectTokens(findedName);
                //    //foreach (JToken jToken in jTokens)
                //    //{
                //    //    jToken.Replace(Params.ChangeName(jToken.Value<string>()));
                //    //}
                //}
                return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            }
            catch (JsonException ex)
            {
                return str;
            }
        }
    }
}
