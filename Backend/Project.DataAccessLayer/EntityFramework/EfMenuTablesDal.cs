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
    public class EfMenuTablesDal : GenericRepository<MenuTable>, IMenuTablesDal
    {
        public EfMenuTablesDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeMenuTableStatusToFalse(int id)
        {
            using var context = new SignalRContext();
            var value =  context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
            value!.Status = false;
            context.SaveChanges();
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefault();
            value!.Status = true;
            context.SaveChanges();
        }

        public int MenuTableCount()
        {
            using var context = new SignalRContext();
            return context.MenuTables.Count();
        }
    }
}
