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
    public class MoonControllerTest
    {
        public Mock<IMoonRepository> moonRepository { get; set; }
        public Mock<IProfileRepository> profileRepository { get; set; }
        public List<Moon> moons { get; set; }
        public Profile profile { get; set; }
        public MoonController controller { get; set; }

        public MoonControllerTest()
        {
            moons = new List<Moon>
            {
                new Moon { Id = 1, Name = "Moon 1", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 1 },
                new Moon { Id = 2, Name = "Moon 2", CreatedDate = DateTime.Now, LastUpdatedDate = DateTime.Now, Ordinal = 2 },
            };
            moonRepository = new Mock<IMoonRepository>();
            moonRepository
                .Setup(p => p.GetMoonsAsync())
                .ReturnsAsync(moons);

            profile = new Profile
            {
                Id = 1,
                TypeId = 1,
                TypeName = "Moon",
                Content = "Content",
                Introduction = "Introduction",
                HasRings = false
            };

            profileRepository = new Mock<IProfileRepository>();
            profileRepository
                .Setup(p => p.GetProfileAsync(1, "Moon"))
                .ReturnsAsync(profile);

            controller = new MoonController(moonRepository.Object, profileRepository.Object);
        }

        [TestMethod]
        public async Task Controller_Get_All_Moons()
        {
            IEnumerable<Moon> result = await controller.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Moon 1", result.Take(1).SingleOrDefault().Name);
            Assert.AreEqual("Moon 2", result.Skip(1).Take(1).SingleOrDefault().Name);
        }

        [TestMethod]
        public async Task Controller_Get_Moon()
        {
            throw new NotImplementedException();
        }
    }
}
