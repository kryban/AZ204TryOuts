using System;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace StorageTableApp001
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = "DefaultEndpointsProtocol=https;AccountName=bansstorageaccount;AccountKey=naLbJKB2T2ck/3c/6ian7b6t6kjAb+XKn9aoc31fm5XwTPxbM0M1eJo6Fx9F3zwbCUs2ehjV413BF5TtEj5L9g==;EndpointSuffix=core.windows.net";
            string tableName = "banstable001";

            CreateNewRowInTable(connstr, tableName);
        }

        private static void CreateNewRowInTable(string connstr, string tableName)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connstr);
            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable cloudTable = cloudTableClient.GetTableReference(tableName);

            Gemeente gemeente = new Gemeente("Gemeente", "Schiedam", 70000, "0606");

            TableOperation voegGemeenteToe = TableOperation.Insert(gemeente);

            cloudTable.Execute(voegGemeenteToe);
        }
    }

    public class Gemeente : TableEntity
    {
        public int Inwoneraantal { get; set; }
        public string Gemeentecode { get; set; }

        public Gemeente(string partitionKey, string rowKey, int inwoneraantal, string gemeentecode)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
            Timestamp = DateTime.Now;
            Inwoneraantal = inwoneraantal;
            Gemeentecode = gemeentecode;
        }
    }
}
