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
            httpReq.Url = "http://google.com/";
            httpReq.RequestBody = "{\"order\":\"123\"," +
                    "\"name\":\"qwe\"," +
                    "\"pass\":\"12qw\"}";
            httpReq.ResponseBody = "ok";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://google.com/";
            httpResult.RequestBody = "{\"order\":\"123\"," +
                    "\"name\":\"XXX\"," +
                    "\"pass\":\"XXXX\"}";
            httpResult.ResponseBody = "ok";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.True(httpResult == httpReq);
        }

        [Fact]
        public void SecureCleaner_CleanString_JSONResponceBody_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://google.com/";
            httpReq.RequestBody = "ok";
            httpReq.ResponseBody = "{\"order\":{\"name\":\"qwe\"," +
                    "\"pass\":\"12qw\"}}";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://google.com/";
            httpResult.RequestBody = "ok";
            httpResult.ResponseBody = "{\"order\":{\"name\":\"XXX\"," +
                    "\"pass\":\"XXXX\"}}";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.True(httpResult == httpReq);
        }

        [Fact]
        public void SecureCleaner_CleanString_GetUrlBody_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://test.com?user=max&pass=123456";
            httpReq.RequestBody = "ok";
            httpReq.ResponseBody = "ok";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://test.com?user=XXX&pass=XXXXXX";
            httpResult.RequestBody = "ok";
            httpResult.ResponseBody = "ok";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.True(httpResult == httpReq);
        }

        [Fact]
        public void SecureCleaner_CleanString_RestUrlBody_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://test.com/users/max/info";
            httpReq.RequestBody = "ok";
            httpReq.ResponseBody = "ok";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://test.com/users/XXX/info";
            httpResult.RequestBody = "ok";
            httpResult.ResponseBody = "ok";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.True(httpResult == httpReq);
        }

        [Fact]
        public void SecureCleaner_CleanString_XMLResponceBody_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://google.com";
            httpReq.RequestBody = "ok";
            httpReq.ResponseBody = "<main>" +
                                        "<order>123</order><name>max</name><pass>qwe12</pass>" +
                                      "</main>";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://google.com";
            httpResult.RequestBody = "ok";
            httpResult.ResponseBody = "<main>" +
                                        "<order>123</order><name>XXX</name><pass>XXXXX</pass>" +
                                      "</main>";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.True(httpResult == httpReq);
        }

        [Fact]
        public void SecureCleaner_CleanString_XMLRequestBody_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://google.com/";
            httpReq.RequestBody = "<main>" +
                                        "<order><name>max</name><pass>qwe12</pass></order>" +
                                      "</main>";
            httpReq.ResponseBody = "ok";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://google.com/";
            httpResult.RequestBody = "<main>" +
                                        "<order><name>XXX</name><pass>XXXXX</pass></order>" +
                                      "</main>";
            httpResult.ResponseBody = "ok";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.True(httpResult == httpReq);
        }

        [Fact]
        public void SecureCleaner_CleanString_RestAndGetUrl_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://test.com/users/max/info?pass=123456";
            httpReq.RequestBody = "ok";
            httpReq.ResponseBody = "ok";

            HttpResult httpResult = new HttpResult();
            httpResult.Url = "http://test.com/users/XXX/info?pass=XXXXXX";
            httpResult.RequestBody = "ok";
            httpResult.ResponseBody = "ok";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.True(httpResult == httpReq);
        }
    }
}
