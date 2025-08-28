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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCasesDal
    {
        public EfMoneyCaseDal(SignalRContext context) : base(context)
        {
        }

        public decimal TotalMoneyCaseAmount()
        {
           using var context = new SignalRContext();
            return context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();
        }
    }
}
