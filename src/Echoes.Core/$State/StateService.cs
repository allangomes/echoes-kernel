using System;
using Auxo.Data;
using Auxo.Services;
using Auxo.Validation;
using FluentValidation;

namespace Echoes.Core
{
    public class StateService : CrudService<State>
    {
        public StateService(IRepository<State> repository) : base(repository)
        {
        }

        public override bool Validate(State model)
        {
            var v = new Validator<State>();
            v.RuleFor(c => c.Code).NotEmpty().Length(2);
            v.RuleFor(c => c.Name).NotEmpty().Length(5, 30);
            return v.Validate(model);
        }
    }
}