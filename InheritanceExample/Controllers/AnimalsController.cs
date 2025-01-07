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
	[HttpGet]
	[Route("/Get")]
	public IEnumerable<Animal> Get()
	{
		return [
			new Dog { LegCount = 4, TailLength = 30 },
			new Spider { LegCount = 8, Venomous = true }
		];
	}

	[HttpPost]
	[Route("/Post")]
	public void Post(Animal animal)
	{
		Console.WriteLine($"Incoming type: {animal.GetType().FullName}");
		Console.WriteLine(JsonConvert.SerializeObject(animal, Formatting.Indented));
	}
}
