using System;
using System.Linq;
using AutoMapper;
using Week1_Patika.DbOperations;

namespace Week1_Patika.CakeShopOperations.CreateCake
{
    public class CreateCakeCommand
    {
        public CreateCakeModel Model {get; set;}
        private readonly CakeShopDbContext _dbcontext;
        private readonly IMapper _mapper;
        private CakeShopDbContext dbcontext;
        private IMapper mapper;

        public CreateCakeCommand(CakeShopDbContext dbcontext, IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }

        public void Handle()
        {
            var cake = _dbcontext.Cakes.SingleOrDefault(x => x.CakeName == Model.CakeName);

            if (cake != null) { throw new InvalidOperationException("This cake is already exist!"); }

            cake = _mapper.Map<Cake>(Model);
            _dbcontext.Add(cake);
            _dbcontext.SaveChanges();
        }




    }


    public class CreateCakeModel
    {
        public string CakeName { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
