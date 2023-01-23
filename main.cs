//Created Jan 2023 
//
//Author Alex Nelson

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(
            "https://type.fit/api/quotes"
        );
        // Console.WriteLine(response);
        var jsonAsDictionary = System.Text.Json.JsonSerializer.Deserialize<Object>(response);

      Random random = new Random();
      int randNum = random.Next(1641);
        // Console.WriteLine(jsonAsDictionary);
        Console.WriteLine("");
      
        JsonNode mainNode = JsonNode.Parse(response)!;
      
        // Quote and Author Nodes
        JsonNode quoteNode = mainNode[randNum]!["text"]!;
        JsonNode authorNode = mainNode[randNum]!["author"]!;
        

        //Output quote and author 
        Console.WriteLine("Quote: " + quoteNode);

         Console.WriteLine("\nAuthor: " + authorNode);
        Console.WriteLine("\n\nDone");
    }
}
