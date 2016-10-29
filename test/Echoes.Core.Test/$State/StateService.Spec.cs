using System;
using Auxo.Data;
using Echoes.Core;
using Moq;
using NUnit.Framework;

namespace Auxo.Echoes.Test
{   
    public class StateService_Test
    {
        protected Mock<IRepository<State>> _repo;
        protected StateService _service;

        [SetUp]
        public void SetUp()
        { 
            _repo = new Mock<IRepository<State>>();
            _service = new StateService(_repo.Object); 
        }
    }

    [TestFixture]
    public class StateService_Insert : StateService_Test
    {
        [Test]
        public void When_Invalid_Model_No_Call_Repository()
        {
            var state = new State { Code = "", Name = "" };
            _service.Insert(state);
            _repo.Verify(r => r.Insert(state), Times.Never);
        }

        [Test]
        public void When_Valid_Model_Call_Repository()
        {
            var state = new State { Code = "CE", Name = "CEARÁ" };
            _service.Insert(state);
            _repo.Verify(r => r.Insert(state), Times.Once);
        }
    }

    [TestFixture]
    public class StateService_Update : StateService_Test
    {
        [Test]
        public void When_Invalid_Model_No_Call_Repository()
        {
            var state = new State { Code = "CE", Name = "" };
            _service.Update(state);
            _repo.Verify(r => r.Update(state), Times.Never);
        }

        [Test]
        public void When_Valid_Model_Call_Repository()
        {
            var state = new State { Code = "CE", Name = "CEARÁ" };
            _service.Update(state);
            _repo.Verify(r => r.Update(state), Times.Once);
        }
    }

    [TestFixture]
    public class StateService_Delete : StateService_Test
    {
        [Test]
        public void When_Valid_Call_Repository()
        {
            var state = new State();
            _service.Delete(state);
            _repo.Verify(r => r.Delete(state), Times.Once);
        }
    }
}