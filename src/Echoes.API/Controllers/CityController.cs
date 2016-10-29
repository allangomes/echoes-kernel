using Echoes.Core;

namespace Echoes.API.Controllers
{
    public class CityController : CrudController<City>
    {
        private readonly CityService _cityService;
        public CityController(CityService cityService) : base(cityService)
        {
            _cityService = cityService;
        }
    }
}