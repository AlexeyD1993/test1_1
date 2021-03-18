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
        }

        public string TryParce(string str)
        {
            try
            {
                JObject data = (JObject)JsonConvert.DeserializeObject(str);

                RecourceFind(data);

                return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None);
            }
            catch (JsonException ex)
            {
                return str;
            }
            catch (InvalidCastException ex)
            {
                return str;
            }
        }
    }
}
