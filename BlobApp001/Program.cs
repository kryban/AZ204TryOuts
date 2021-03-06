using System;
using System.IO;
using Azure.Storage.Blobs;

namespace StorageBlobApp001
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = "DefaultEndpointsProtocol=https;AccountName=bansstorageaccount;AccountKey=naLbJKB2T2ck/3c/6ian7b6t6kjAb+XKn9aoc31fm5XwTPxbM0M1eJo6Fx9F3zwbCUs2ehjV413BF5TtEj5L9g==;EndpointSuffix=core.windows.net";
            string containerName = "banscontainer";
            string filepath = @"C:\Users\karoy\Desktop\NewFolder\cn3.jpg";

            //CreateBlobContainer(connstr, containerName);

            UploadBlobtoContainer(connstr, containerName, filepath);
            
            Console.WriteLine("Hello World!");
        }

        private static void UploadBlobtoContainer(string connstr, string containerName, string filepath)
        {
            BlobContainerClient containerClient = new BlobContainerClient(connstr, containerName);

            FileStream fileStream = File.OpenRead(filepath);
            containerClient.UploadBlob("bansblobfromcode", fileStream);
            fileStream.Close();
        }

        private static void CreateBlobContainer(string connstr, string containerName)
        {
            BlobServiceClient serviceClient = new BlobServiceClient(connstr);
            serviceClient.CreateBlobContainer("banscontainerviacode001");
        }


    }
}
