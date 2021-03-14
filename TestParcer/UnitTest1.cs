using System;
using test1_1;
using Xunit;

namespace TestParcer
{
    public class UnitTest1
    {
        [Fact]
        public void SecureCleaner_CleanString_JSONRequestBody_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://google.com";
            httpReq.RequestBody = "{\"order\":\"123\"," +
                    "\"name\":\"qwe\"," +
                    "\"pass\":\"12qw\"}";
            httpReq.ResponseBody = "ok";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://google.com";
            httpResult.RequestBody = "{\"order\":\"123\"," +
                    "\"name\":\"XXX\"," +
                    "\"pass\":\"XXXX\"}";
            httpResult.ResponseBody = "ok";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.False(httpResult == httpReq);
        }

        [Fact]
        public void SecureCleaner_CleanString_JSONResponceBody_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://google.com";
            httpReq.RequestBody = "ok";
            httpReq.ResponseBody = "{\"order\":{\"name\":\"qwe\"," +
                    "\"pass\":\"12qw\"}}";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://google.com";
            httpResult.RequestBody = "ok";
            httpResult.ResponseBody = "{\"order\":{\"name\":\"XXX\"," +
                    "\"pass\":\"XXXX\"}}";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.False(httpResult == httpReq);
        }
    }
}
