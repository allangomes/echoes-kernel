using System;
using Auxo.Data;
using Echoes.Core;
using Moq;
using NUnit.Framework;

namespace Auxo.Echoes.Test
{   
    public class CityService_Test
    {
        protected Mock<IRepository<City>> _repo;
        protected CityService _service;

        [SetUp]
        public void SetUp()
        { 
            _repo = new Mock<IRepository<City>>();
            _service = new CityService(_repo.Object); 
        }
    }

    [TestFixture]
    public class CityService_Insert : CityService_Test
    {
        [Test]
        public void When_Invalid_Model_No_Call_Repository()
        {
            var city = new City { Name = "" };
            _service.Insert(city);
            _repo.Verify(r => r.Insert(city), Times.Never);
        }

        [Test]
        public void When_Valid_Model_Call_Repository()
        {
            var city = new City { Name = "CEARÁ" };
            _service.Insert(city);
            _repo.Verify(r => r.Insert(city), Times.Once);
        }
    }

    [TestFixture]
    public class CityService_Update : CityService_Test
    {
        [Test]
        public void When_Invalid_Model_No_Call_Repository()
        {
            var city = new City { Name = "" };
            _service.Update(city);
            _repo.Verify(r => r.Update(city), Times.Never);
        }

        [Test]
        public void When_Valid_Model_Call_Repository()
        {
            var city = new City { Name = "CEARÁ" };
            _service.Update(city);
            _repo.Verify(r => r.Update(city), Times.Once);
        }
    }

    [TestFixture]
    public class CityService_Delete : CityService_Test
    {
        [Test]
        public void When_Valid_Call_Repository()
        {
            var city = new City();
            _service.Delete(city);
            _repo.Verify(r => r.Delete(city), Times.Once);
        }
    }
}