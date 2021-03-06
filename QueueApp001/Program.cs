using System;
using Azure.Storage.Queues;

namespace StorageQueueApp001
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = "DefaultEndpointsProtocol=https;AccountName=bansstorageaccount;AccountKey=naLbJKB2T2ck/3c/6ian7b6t6kjAb+XKn9aoc31fm5XwTPxbM0M1eJo6Fx9F3zwbCUs2ehjV413BF5TtEj5L9g==;EndpointSuffix=core.windows.net";
            string queuename = "bansqueue001";

            SendMessageToQueue(connstr, queuename);

            Console.WriteLine("Hello World!");
        }

        private static void SendMessageToQueue(string connstr, string queuename)
        {
            QueueClient queueClient = new QueueClient(connstr, queuename);
            queueClient.SendMessage("Hoi Hoi. Deze is via code.");
        }
    }
}
