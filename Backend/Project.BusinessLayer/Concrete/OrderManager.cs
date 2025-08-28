using Project.BusinessLayer.Abstract;
using Project.DataAccessLayer.Abstract;
using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public decimal TLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public int TActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public Order? TGetByID(int id)
        {
            return _orderDal.GetByID(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void TInsert(Order entity)
        {
            _orderDal.Insert(entity);
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }
    }
}
