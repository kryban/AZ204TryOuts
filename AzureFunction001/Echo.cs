using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AzureFunction001
{
    public static class Echo
    {
        [FunctionName("Echo")]
        public static IActionResult Run([HttpTrigger("GET","POST")]HttpRequest request, ILogger logger)
        {
            string body;
            logger.LogInformation("Received a request on bans-Azurefunction001");

            foreach(var header in request.Headers)
            {
                var headerKey = header.Key;
                var headerValue = header.Value.ToString();
                logger.LogInformation($"Header: {headerKey} -- Value: {headerValue}");
            }

            using(StreamReader reader = new StreamReader(request.Body))
            {
                body = reader.ReadToEnd();
                logger.LogInformation(body);
            }      

            return new OkObjectResult(request.QueryString.Value);
        }
    }
}
