using System;
using System.Linq;
using System.Reflection;
using test1_1.Parcers;
using test1_1.Parcers.JsonParcer;
using test1_1;

namespace test1_1
{
    public class SecureCleaner
    {
        private HttpResult result = new HttpResult();
        public HttpResult CleanString(HttpResult httpResult)
        {
            //Решил сделать обработку классов, которые используют интерфейс IParcer
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IParcer))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as IParcer;
            
            //Блок обезличивания URL
            foreach (var instance in instances)
            {
                //пробуем распарсить полученный инстанс
                result.Url = instance.TryParce(httpResult.Url);
                //если имеем полученный результат - то возвращаем его
                if (result.Url != httpResult.Url)
                {
                    break;
                }
            }
            //Если результатов обработки нет - то вываливаемся по exception
            //if (result.Url == "")
            //    throw new ParcerException();

            //Блок обезличивания HttpRequest
            foreach (var instance in instances)
            {
                //пробуем распарсить полученный инстанс
                result.RequestBody = instance.TryParce(httpResult.RequestBody);
                //если имеем полученный результат - то возвращаем его
                if (result.RequestBody != httpResult.RequestBody)
                {
                    break;
                }
            }
            //Если результатов обработки нет - то вываливаемся по exception
            //if (result.RequestBody == "")
            //    throw new ParcerException();

            //Блок обезличивания HttpRequest
            foreach (var instance in instances)
            {
                //пробуем распарсить полученный инстанс
                result.ResponseBody = instance.TryParce(httpResult.ResponseBody);
                //если имеем полученный результат - то возвращаем его
                if (result.ResponseBody != httpResult.ResponseBody)
                {
                    break;
                }
            }
            //Если результатов обработки нет - то вываливаемся по exception
            //if (result.ResponseBody == "")
            //    throw new ParcerException();

            return result;
        }
    }
}
