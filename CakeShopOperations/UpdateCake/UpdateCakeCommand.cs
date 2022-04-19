using System;
using System.Linq;
using Week1_Patika.DbOperations;

namespace Week1_Patika.CakeShopOperations.UpdateCake
{
    public class UpdateCakeCommand

    {

        private readonly CakeShopDbContext _dbContext;

        public int Id { get; set; }
        public UpdateCakeModel Model { get; set; }
        public UpdateCakeCommand(CakeShopDbContext _context)
        {
            _dbContext = _context;
        }

        public void Handle()
        {
            Cake cake = _dbContext.Cakes.SingleOrDefault(x => x.Id == Id);
            if (cake != null) { throw new InvalidOperationException("No cake to update!"); }

            cake.CategoryId = Model.CategoryId != default ? Model.CategoryId : cake.CategoryId;

            cake.CakeName = Model.CakeName != default ? Model.CakeName : cake.CakeName;
            
            _dbContext.SaveChanges();


        }

    }


    public class UpdateCakeModel
    {
        public string CakeName { get; set; }
        public int CategoryId { get; set; }
    }
}




