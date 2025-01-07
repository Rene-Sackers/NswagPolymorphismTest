using System.Runtime.Serialization;
using Newtonsoft.Json;
using NJsonSchema.NewtonsoftJson.Converters;

namespace InheritanceExample.Models;

[JsonConverter(typeof(JsonInheritanceConverter))]
[KnownType(typeof(Dog))]
[KnownType(typeof(Spider))]
public abstract class Animal
{
	public int LegCount { get; set; }
}

public class Dog : Animal
{
	public int TailLength { get; set; }
}

public class Spider : Animal
{
	public bool Venomous { get; set; }
}