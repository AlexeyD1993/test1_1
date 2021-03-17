using System;
using System.Collections.Generic;
using System.Text;
using test1_1;
using Xunit;

namespace TestParcer
{
    public class HttpHandlerTest
    {
        [Fact]
        public void HttpLogHandler_Process_BookingcomHttpResult_ClearSecureData()
        {
            //Arrange
            var bookingcomHttpResult = new HttpResult
            {
                Url = "http://test.com/users/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };
            var httpLogHandler = new HttpHandler();


            //Act
            httpLogHandler.Process(bookingcomHttpResult);

            //Assert
            Assert.Equal("http://test.com/users/XXX/info?pass=XXXXXX", httpLogHandler.CurrentLog.Url);
            Assert.Equal("http://test.com?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.RequestBody);
            Assert.Equal("http://test.com?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.ResponseBody);
        }

    }
}
