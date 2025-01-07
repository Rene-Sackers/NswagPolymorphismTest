using InheritanceExample.Client;
using Newtonsoft.Json;

using var httpClient = new HttpClient();
var animalsClient = new Client("https://localhost:7235/", httpClient);

var gotAnimals = await animalsClient.GetAsync();
Console.WriteLine(JsonConvert.SerializeObject(gotAnimals, Formatting.Indented));

await animalsClient.PostAsync(new Spider {LegCount = 8, Venomous = true });