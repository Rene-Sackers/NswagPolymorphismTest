using System;
using System.Collections.Generic;
using InheritanceExample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InheritanceExample.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
	[HttpGet(Name = "GetAnimals")]
	public IEnumerable<Animal> Get()
	{
		return [
			new Dog { LegCount = 4, TailLength = 30 },
			new Spider { LegCount = 8, Venomous = true }
		];
	}

	[HttpPost(Name = "PostAnimals")]
	public void Post(IEnumerable<Animal> animals)
	{
		Console.WriteLine(JsonConvert.SerializeObject(animals, Formatting.Indented));
	}
}
