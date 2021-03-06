using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace func
{
    public static class Recurring
    {
        [FunctionName("Herhalend")]
        public static void Run([TimerTrigger("*/1 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            //log.LogInformation($"\n-----------------------\nC# Timer trigger function executed at: {DateTime.Now:ss}\n-----------------------\n");

            string connstr = "DefaultEndpointsProtocol=https;AccountName=bansstorage001;AccountKey=apmMvokuSsGMFyK81kUD0KGLVjKpI0pQG5hNFtPqzAuOgWJ+0alGWlOSq0AegrLhy2zPMAKPNf9LoimhcQIlWg==;EndpointSuffix=core.windows.net";
            string container = "bansblob001";
            string blobName = $"UploadByTime{DateTime.Now:ffff}";
            string path = @"C:\Users\karoy\Desktop\NewFolder\conf\cn3.jpg";

            BlobClient blobClient = new BlobClient(connstr, container, blobName);

            if (!blobClient.Exists())
            {
                blobClient.Upload(path);
                log.LogInformation($"Blob uploaded -- {DateTime.Now:ffff}");
            }
            //else
            //{
            //    blobClient.DeleteIfExists(DeleteSnapshotsOption.IncludeSnapshots, null, default);
            //    log.LogInformation($"Blob deleted -- {DateTime.Now:ffff}");
            //}
        }
    }
}