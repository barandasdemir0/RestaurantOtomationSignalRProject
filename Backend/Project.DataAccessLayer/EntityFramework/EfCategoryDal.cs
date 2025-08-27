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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int CategoryActiveCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count(x => x.CategoryStatus == true);
            
        }

        public int CategoryCount()
        {
            using var context = new SignalRContext(); //--> kod bittiğinde yani scope dışına çıktısında dispose yapılır ve sistem yorumaz
            //var context = new SignalRContext();  --> bunu kullanmamamızın  sebebi dispose etmezsek hala enerji tükertir
            return context.Categories.Count();
            
    }

        public int CategoryPassiveCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count(x => x.CategoryStatus == false);
            
        }
    }
}
