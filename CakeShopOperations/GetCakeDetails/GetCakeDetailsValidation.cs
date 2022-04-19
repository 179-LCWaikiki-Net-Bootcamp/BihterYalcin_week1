using FluentValidation;

namespace Week1_Patika.CakeShopOperations.GetCakeDetails
{
    public class GetCakeDetailsValidation : AbstractValidator<GetCakeDetailsQuery>
    {
        public GetCakeDetailsValidation()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}


