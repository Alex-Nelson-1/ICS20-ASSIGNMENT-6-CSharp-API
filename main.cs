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
            "https://api.openweathermap.org/data/2.5/weather?lat=45.4211435&lon=-75.6900574&appid=fe1d80e1e103cff8c6afd190cad23fa5"
        );
        // Console.WriteLine(response);
        var jsonAsDictionary = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        // Console.WriteLine(jsonAsDictionary);
        Console.WriteLine("");
        JsonNode forecastNode = JsonNode.Parse(response)!;
        Console.WriteLine(response);
        // Important Nodes
        JsonNode mainNode = forecastNode!["main"]!;
        JsonNode tempNode = mainNode!["temp"]!;
        JsonNode humidityNode = mainNode!["humidity"]!;
        JsonNode minNode = mainNode!["temp_min"]!;
        JsonNode maxNode = mainNode!["temp_max"]!;

        //Output of important nodes
        Console.WriteLine("\nTemperature: " + tempNode + " K");
        Console.WriteLine("\nHumidity: " + humidityNode + "%");
        Console.WriteLine("\nTemp Min: " + minNode + " K");
        Console.WriteLine("\nTemp Max: " + maxNode + " K");
        Console.WriteLine("\nThe weather can be found on the second half of the first line");
        Console.WriteLine("\n\nDone");
    }
}
