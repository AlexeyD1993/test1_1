using System;
using System.Security.Policy;
using test1_1;
using Xunit;

namespace TestParcer
{
    public class SecureCleanerTest
    {
        [Fact]
        public void SecureCleaner_CleanString_CleanRequestBodyContainsXML_OK()
        {
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://test.com/users/max/info?pass=123456";
            httpReq.RequestBody = "http://test.com?order=<main><user>max</user><pass>123456</pass></main>";
            httpReq.ResponseBody = "ok";

            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            Assert.Equal("http://test.com/users/XXX/info?pass=XXXXXX", System.Web.HttpUtility.UrlDecode(httpReq.Url));
            Assert.Equal("http://test.com?order=<main><user>XXX</user><pass>XXXXXX</pass></main>", System.Web.HttpUtility.UrlDecode(httpReq.RequestBody));
            Assert.Equal("ok", System.Web.HttpUtility.UrlDecode(httpReq.ResponseBody));
        }

        [Fact]
        public void SecureCleaner_CleanString_CleanRequestBodyContainsJSON_OK()
        {
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://test.com/users/max/info?pass=123456";
            httpReq.RequestBody = "http://test.com?order={\"main\":{\"user\":\"max\",\"pass\":\"123456\"}}";
            httpReq.ResponseBody = "ok";

            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            Assert.Equal("http://test.com/users/XXX/info?pass=XXXXXX", System.Web.HttpUtility.UrlDecode(httpReq.Url));
            Assert.Equal("http://test.com?order={\"main\":{\"user\":\"XXX\",\"pass\":\"XXXXXX\"}}", System.Web.HttpUtility.UrlDecode(httpReq.RequestBody));
            Assert.Equal("ok", System.Web.HttpUtility.UrlDecode(httpReq.ResponseBody));
        }

        [Fact]
        public void SecureCleaner_CleanString_RestAndGetUrl_OK()
        {
            //Arrange
            HttpResult httpReq = new HttpResult();
            httpReq.Url = "http://test.com/users/max/info?pass=123456";
            httpReq.RequestBody = "ok";
            httpReq.ResponseBody = "ok";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            httpReq = secureCleaner.CleanString(httpReq);

            //Assert
            Assert.Equal("http://test.com/users/XXX/info?pass=XXXXXX", httpReq.Url);
            Assert.Equal("ok", httpReq.RequestBody);
            Assert.Equal("ok", httpReq.ResponseBody);
        }

        [Fact]
        public void SecureCleaner_CleanString_TestBookingcom_OK()
        {
            //Arrange
            HttpResult bookingcomHttpResult = new HttpResult();
            bookingcomHttpResult.Url = "http://test.com/users/max/info?pass=123456";
            bookingcomHttpResult.RequestBody = "http://test.com?user=max&pass=123456";
            bookingcomHttpResult.ResponseBody = "http://test.com?user=max&pass=123456";

            //Act
            SecureCleaner secureCleaner = new SecureCleaner();
            bookingcomHttpResult = secureCleaner.CleanString(bookingcomHttpResult);

            //Assert
            Assert.Equal("http://test.com/users/XXX/info?pass=XXXXXX", bookingcomHttpResult.Url);
            Assert.Equal("http://test.com?user=XXX&pass=XXXXXX", bookingcomHttpResult.RequestBody);
            Assert.Equal("http://test.com?user=XXX&pass=XXXXXX", bookingcomHttpResult.ResponseBody);
        }
    }
}
