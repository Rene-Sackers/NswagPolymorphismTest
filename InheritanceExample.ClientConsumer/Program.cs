using InheritanceExample.Client;
using Newtonsoft.Json;

using var httpClient = new HttpClient();
var animalsClient = new Client("https://localhost:7235/", httpClient);

var gotAnimals = await animalsClient.GetAnimalsAsync();
Console.WriteLine(JsonConvert.SerializeObject(gotAnimals, Formatting.Indented));

var postAnimals = new Animal[]
{
	new Dog {LegCount = 4, TailLength = 30},
	new Spider { LegCount = 8, Venomous = true}
};
await animalsClient.PostAnimalsAsync(postAnimals);