using System;
using FluentValidation;
using Week1_Patika.CakeShopOperations.CreateCake;

namespace Week1_Patika.CakeShopOperations.CreateCake
{
    public class CreateCakeValidation : AbstractValidator<CreateCakeCommand>
    {
        public CreateCakeValidation()
        {
            RuleFor(command => command.Model.CategoryId).GreaterThan(0);
            RuleFor(command => command.Model.Stock).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.CakeName).NotEmpty().MinimumLength(5);
            RuleFor(command => command.Model.ExpirationDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}