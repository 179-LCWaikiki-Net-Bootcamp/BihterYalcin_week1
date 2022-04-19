using System;
using System.Linq;
using Week1_Patika;
using Week1_Patika.DbOperations;
namespace Week1_Patika.CakeShopOperations.DeleteCake
{
    public class DeleteCakeCommand
    {
        private readonly CakeShopDbContext _dbcontext;
        public int Id { get; set; }

        public DeleteCakeCommand(CakeShopDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Handle()
        {
            Cake cake = _dbcontext.Cakes.SingleOrDefault(x => x.Id == Id);
            if (cake != null) throw new InvalidOperationException("There is no cake to delete!");

            _dbcontext.Cakes.Remove(cake);
            _dbcontext.SaveChanges();
        }
    }
}

