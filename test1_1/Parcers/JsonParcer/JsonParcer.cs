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

        private void RecourceFind(JToken host)
        {
            foreach (string findedName in Params.findedNames)
            {
                List<JToken> tokens = host.SelectTokens(findedName).ToList();
                foreach (JToken token in tokens)
                {
                    token.Replace(Params.ChangeName(token.Value<string>()));
                }
            }

            List<JToken> childrens = host.Children().ToList();
            foreach (JToken currElem in childrens)
            {
                if (currElem.Children().ToList().Count != 0)
                {
                    RecourceFind(currElem);
                }
            }

            //if (host.Next != null)
            //{
            //    RecourceFind(host.Next);
            //}
        }

        public string TryParce(string str)
        {
            try
            {
                JObject data = (JObject)JsonConvert.DeserializeObject(str);

                RecourceFind(data);
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
