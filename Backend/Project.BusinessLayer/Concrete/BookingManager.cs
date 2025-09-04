using Project.BusinessLayer.Abstract;
using Project.DataAccessLayer.Abstract;
using Project.DataAccessLayer.EntityFramework;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Concrete
{
    public class BookingManager:IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TBookingStatusApprove(int id)
        {
            _bookingDal.BookingStatusApprove(id);
        }

        public void TBookingStatusCanceled(int id)
        {
            _bookingDal.BookingStatusCanceled(id);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);  
        }

        public Booking? TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetListAll()
        {
            return _bookingDal.GetListAll();
        }

        public void TInsert(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
