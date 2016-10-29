using Auxo.Data;
using Auxo.Services;
using Auxo.Validation;
using FluentValidation;

namespace Echoes.Core
{
    public class CityService : CrudService<City>
    {
        public CityService(IRepository<City> repository) : base(repository)
        {
        }

        public override bool Validate(City model)
        {
            var v = new Validator<City>();
            v.RuleFor(c => c.Name).NotEmpty().Length(5, 40);
            v.RuleFor(c => c.StateId).NotEmpty();
            return v.Validate(model);
        }
    }
}