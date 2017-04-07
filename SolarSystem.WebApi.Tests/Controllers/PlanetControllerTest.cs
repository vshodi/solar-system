﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using SolarSystem.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem.WebApi.Tests.Controllers
{
    [TestClass]
    public class PlanetControllerTest
    {
        public Mock<IPlanetRepository> repository { get; set; }
        public List<Planet> planets { get; set; }
        public PlanetController controller { get; set; }

        public PlanetControllerTest()
        {
            planets = new List<Planet>
            {
                new Planet { Id = 1, Name = "Planet 1", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 1 },
                new Planet { Id = 2, Name = "Planet 2", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 2 },
            };
            repository = new Mock<IPlanetRepository>();
            repository
                .Setup(p => p.GetPlanetsAsync())
                .ReturnsAsync(planets);

            controller = new PlanetController(repository.Object);
        }

        [TestMethod]
        public async Task Controller_Get_All_Planets()
        {
            IEnumerable<Planet> result = await controller.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Planet 1", result.Take(1).SingleOrDefault().Name);
            Assert.AreEqual("Planet 2", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Controller_Get_Planet()
        {
            throw new NotImplementedException();
        }
    }
}
