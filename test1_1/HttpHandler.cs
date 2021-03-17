using System;
using System.Collections.Generic;
using System.Text;

namespace test1_1
{
    public class HttpHandler
    {
        HttpResult _currentLog;
        public HttpResult CurrentLog { get { return _currentLog; } }

        public string Process(HttpResult httpResultProcess)
        {
            var httpResult = new HttpResult
            {
                Url = httpResultProcess.Url,
                RequestBody = httpResultProcess.RequestBody,
                ResponseBody = httpResultProcess.ResponseBody
            };

            //очищаем secure данные в httpResult, либо создаем новый clearedHttpResult на основе httpResult
            httpResult = new SecureCleaner().CleanString(httpResult);

            Log(httpResult);

            return httpResultProcess.ResponseBody;
        }

        /// <summary>
        /// Логирует данные запроса, они должны быть уже без данных которые нужно защищать 
        /// </summary>
        /// <param name="result"></param>
        protected void Log(HttpResult result)
        {
            _currentLog = new HttpResult
            {
                Url = result.Url,
                RequestBody = result.RequestBody,
                ResponseBody = result.ResponseBody
            };
        }
    }

}
