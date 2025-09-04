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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public void BookingStatusApprove(int id)
        {
            using var context = new SignalRContext();
            var findData = context.Bookings.Find(id);
            findData!.BookingDescription = "Rezarvasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCanceled(int id)
        {
            using var context = new SignalRContext();
            var findData = context.Bookings.Find(id);
            findData!.BookingDescription = "Rezarvasyon İptal Edildi";
            context.SaveChanges();
        }
    }
}
