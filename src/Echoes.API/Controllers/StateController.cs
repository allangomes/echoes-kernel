using Echoes.Core;

namespace Echoes.API.Controllers
{
    public class StateController : CrudController<State>
    {
        private readonly StateService _states;
        public StateController(StateService stateService) : base(stateService)
        {
            _states = stateService;
        }
    }
}