using FluentValidation;

namespace Week1_Patika.CakeShopOperations.UpdateCake
{
    public class UpdateCakeValidation : AbstractValidator<UpdateCakeCommand>
    {
        public UpdateCakeValidation()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model.CategoryId).GreaterThan(0);
            RuleFor(command => command.Model.CakeName).NotEmpty().MinimumLength(5);
        }
    }
}



