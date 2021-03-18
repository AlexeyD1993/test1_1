using System;
using System.Linq;
using System.Reflection;
using test1_1.Parcers;
using test1_1.Parcers.JsonParcer;
using test1_1;
using test1_1.Parcers;

namespace test1_1
{
    public class SecureCleaner
    {
        private HttpResult result = new HttpResult();
        public HttpResult CleanString(HttpResult httpResult)
        {
            HttpParcer httpParcer = new HttpParcer();
            result.Url = httpParcer.TryParce(httpResult.Url);
            result.ResponseBody = httpParcer.TryParce(httpResult.ResponseBody);
            result.RequestBody = httpParcer.TryParce(httpResult.RequestBody);
            //Решил сделать обработку классов, которые используют интерфейс IParcer
            //var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
            //                where t.GetInterfaces().Contains(typeof(IParcer))
            //                         && t.GetConstructor(Type.EmptyTypes) != null
            //                select Activator.CreateInstance(t) as IParcer;
            
            //Блок обезличивания URL
            //foreach (var instance in instances)
            //{
            //    //пробуем распарсить полученный инстанс
            //    result.Url = instance.TryParce(httpResult.Url);
            //    //если имеем полученный результат - то возвращаем его
            //    if (result.Url != httpResult.Url)
            //        break;
            //}

            //Блок обезличивания HttpRequest
            //foreach (var instance in instances)
            //{
            //    //пробуем распарсить полученный инстанс
            //    result.RequestBody = instance.TryParce(httpResult.RequestBody);
            //    //если имеем полученный результат - то возвращаем его
            //    if (result.RequestBody != httpResult.RequestBody)
            //        break;
            //}

            //Блок обезличивания HttpRequest
            //foreach (var instance in instances)
            //{
            //    //пробуем распарсить полученный инстанс
            //    result.ResponseBody = instance.TryParce(httpResult.ResponseBody);
            //    //если имеем полученный результат - то возвращаем его
            //    if (result.ResponseBody != httpResult.ResponseBody)
            //        break;
            //}

            return result;
        }
    }
}
