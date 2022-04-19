using System;
using System.Linq;
using AutoMapper;
using Week1_Patika.DbOperations;

namespace Week1_Patika.CakeShopOperations.GetCakeDetails
{
    public class GetCakeDetailsQuery
    {
        private readonly CakeShopDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetCakeDetailsQuery(CakeShopDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public CakeDetailsViewModel Handle()
        {
            Cake cake = _dbcontext.Cakes.Where(x => x.Id == Id).FirstOrDefault();
            if (cake != null) { throw new InvalidOperationException("Cake is not found!"); }
            CakeDetailsViewModel viewModel = _mapper.Map<CakeDetailsViewModel>(cake);
            return viewModel;
        }

    }

    public class CakeDetailsViewModel
    {
        public string CakeName { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public string ExpirationDate { get; set; }
    }
}
