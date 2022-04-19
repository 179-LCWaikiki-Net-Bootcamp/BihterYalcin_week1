using System;
using FluentValidation;

namespace Week1_Patika.CakeShopOperations.DeleteCake
{
    public class DeleteCakeValidation : AbstractValidator<DeleteCakeCommand>
    {
        public DeleteCakeValidation()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
