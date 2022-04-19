using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Week1_Patika.DbOperations;

namespace Week1_Patika.CakeShopOperations.GetCakes
{
    public class GetCakesQuery
    {
        private readonly CakeShopDbContext _dbcontenxt;
        private readonly IMapper _mapper;

        public GetCakesQuery(CakeShopDbContext dbcontenxt, IMapper mapper)
        {
            _dbcontenxt = dbcontenxt;
            _mapper = mapper;
        }


        public List<CakeViewModel> Handle()
        {
            List<Cake> cakeList = _dbcontenxt.Cakes.OrderBy(x => x.Id).ToList<Cake>();
            List<CakeViewModel> viewModel = _mapper.Map<List<CakeViewModel>>(cakeList);


            return viewModel;
        }



        public class CakeViewModel
        {
            public string CakeName { get; set; }
            public string Category { get; set; }
            public int Stock { get; set; }
            public string ExpirationDate { get; set; }
        }
    }
}


