using Lacuna.Signer.Client;
using Lacuna.Spa.Api;
using Newtonsoft.Json;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var domain = "https://signer-lac.azurewebsites.net";
            var token = "API Sample App|43fc0da834e48b4b840fd6e8c37196cf29f919e5daedba0f1a5ec17406c13a99";

            SignerClient SignerClient = new SignerClient(domain, token);

            var paginatedSearchParams = new PaginatedSearchParams() { Q = "Sample" };
            var paginatedSearchResult = SignerClient.ListFoldersPaginatedAsync(paginatedSearchParams, null).Result;

            var resultJson = JsonConvert.SerializeObject(paginatedSearchResult, Formatting.Indented);

            Console.WriteLine(resultJson);
        }
    }
}
