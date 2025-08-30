using Microsoft.EntityFrameworkCore;
using Project.DataAccessLayer.Abstract;
using Project.DataAccessLayer.Concrete;
using Project.DataAccessLayer.Repositories;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketsByMenuTableNumber(int id)
        {
            using var context = new SignalRContext();
            return context.Baskets.Where(x=>x.MenuTableID == id).Include(y=>y.Product).ToList();
        }
    }
}
