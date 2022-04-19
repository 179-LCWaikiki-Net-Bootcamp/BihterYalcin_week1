using AutoMapper;
using Week1_Patika.CakeShopOperations.CreateCake;
using Week1_Patika.CakeShopOperations.GetCakeDetails;
using static Week1_Patika.CakeShopOperations.GetCakes.GetCakesQuery;

namespace Week1_Patika.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCakeModel, Cake>();


            CreateMap<Cake, CakeViewModel>().ForMember(x => x.Category, opt => opt.MapFrom(src => (
                 (CategoryEnum)src.CategoryId).ToString()));
            CreateMap<Cake, CakeDetailsViewModel>().ForMember(x => x.Category, opt => opt.MapFrom(src => (
                (CategoryEnum)src.CategoryId).ToString()));
;
        }

    }
}
