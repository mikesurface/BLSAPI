namespace BlsApi.Tests;

public class HttpMessageHandlerStub : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var json = @"{
            ""status"": ""REQUEST_SUCCEEDED"",
            ""responseTime"": 100,
            ""message"": [],
            ""Results"": {
                ""series"": [{
                    ""seriesID"": ""LAUCN040010000000005"",
                    ""data"": [{
                        ""year"": ""2023"",
                        ""period"": ""M01"",
                        ""periodName"": ""January"",
                        ""value"": ""5.2"",
                        ""footnotes"": [{ ""code"": ""P"", ""text"": ""Preliminary"" }]
                    }]
                }]
            }
        }";

        var response = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(json)
        };

        return Task.FromResult(response);
    }
}

