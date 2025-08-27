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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            using var context = new SignalRContext();
            return context.Products.Include(x=>x.Category).ToList();

        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products
               .Where(x => x.Category != null && x.Category.CategoryName == "Hamburger")
               .Count();

        }

        public int ProductCountByCategoryNamePizza()
        {
            using var context = new SignalRContext();
            return context.Products
              .Where(x => x.Category != null && x.Category.CategoryName == "Pizza")
              .Count();

        }
    }
}
