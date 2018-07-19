using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchServiceName = "";
            var apiKey = "";

            var dataSourceName = "";
            var indexName = "";
            var indexerName = "";

            var azureBlobStorageConnectionString = "";
            var azureBlobStorageTableName = "";

            using (var httpClient = new HttpClient())
            {
                var dataSourceDefinition = AzureBlobStorageDataSourceDefinition(azureBlobStorageConnectionString, azureBlobStorageTableName);
                var putDataSourceRequest = PutDataSourceRequest(searchServiceName, apiKey, dataSourceName, dataSourceDefinition);
                Console.WriteLine($"Put data source {putDataSourceRequest.RequestUri}");
                Console.WriteLine();

                var putDataSourceResponse = httpClient.SendAsync(putDataSourceRequest).Result;
                var putDataSourceresponseContent = putDataSourceResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine(putDataSourceresponseContent);
                Console.WriteLine();

                var indexDefinition = IndexDefinition();
                var putIndexRequest = PutIndexRequest(searchServiceName, apiKey, indexName, indexDefinition);
                Console.WriteLine($"Put index {putIndexRequest.RequestUri}");
                Console.WriteLine();

                var putIndexResponse = httpClient.SendAsync(putIndexRequest).Result;
                var putIndexResponseContent = putIndexResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine(putIndexResponseContent);
                Console.WriteLine();

                var indexerDefinition = IndexerDefinition(dataSourceName, indexName);
                var putIndexerRequest = PutIndexerRequest(searchServiceName, apiKey, indexerName, indexerDefinition);
                Console.WriteLine($"Put indexer {putIndexerRequest.RequestUri}");
                Console.WriteLine();

                var putIndexerResponse = httpClient.SendAsync(putIndexerRequest).Result;
                var putIndexersResponseContent = putIndexerResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine(putIndexersResponseContent);
                Console.WriteLine();

                var runIndexerRequest = RunIndexerRequest(searchServiceName, apiKey, indexerName);
                Console.WriteLine($"Run indexer {runIndexerRequest}");
                Console.WriteLine();

                var runIndexerResponse = httpClient.SendAsync(runIndexerRequest).Result;
                Console.WriteLine($"Success: {runIndexerResponse.IsSuccessStatusCode}");
                Console.ReadLine();
            }
        }

        static HttpRequestMessage PutDataSourceRequest(string searchServiceName, string apiKey, string dataSourceName, string dataSourceDefinition)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://.search.windows.net/datasources/?api-version=2016-09-01");
            request.Headers.Add("api-key", apiKey);
            var body = new StringContent(dataSourceDefinition, Encoding.UTF8, "application/json");
            request.Content = body;
            return request;
        }

        static HttpRequestMessage PutIndexRequest(string searchServiceName, string apiKey, string indexName, string indexDefinition)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://.search.windows.net/indexes/?api-version=2016-09-01");
            request.Headers.Add("api-key", apiKey);
            var body = new StringContent(indexDefinition, Encoding.UTF8, "application/json");
            request.Content = body;
            return request;
        }

        static HttpRequestMessage PutIndexerRequest(string searchServiceName, string apiKey, string indexerName, string indexerDefinition)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://.search.windows.net/indexers/?api-version=2016-09-01");
            request.Headers.Add("api-key", apiKey);
            var body = new StringContent(indexerDefinition, Encoding.UTF8, "application/json");
            request.Content = body;
            return request;
        }

        static HttpRequestMessage RunIndexerRequest(string searchServiceName, string apiKey, string indexerName)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://.search.windows.net/indexers//run?api-version=2016-09-01");
            request.Headers.Add("api-key", apiKey);
            return request;
        }

        static string AzureBlobStorageDataSourceDefinition(string connectionString, string tableName)
        {


        }

        static string IndexDefinition()
        {


        }

        static string IndexerDefinition(string dataSourceName, string indexName)
        {


        }
    }
}
