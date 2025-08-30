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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetBasketsByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketsByMenuTableNumber(id);

        }

        public Basket? TGetByID(int id)
        {
           return _basketDal.GetByID(id);
        }

        public List<Basket> TGetListAll()
        {
           return _basketDal.GetListAll();
        }

        public void TInsert(Basket entity)
        {
            _basketDal.Insert(entity);
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}
