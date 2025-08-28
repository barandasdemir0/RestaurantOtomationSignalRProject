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
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCasesDal _moneyCasesDal;

        public MoneyCaseManager(IMoneyCasesDal moneyCasesDal)
        {
            _moneyCasesDal = moneyCasesDal;
        }

        public void TDelete(MoneyCase entity)
        {
            _moneyCasesDal.Delete(entity);
        }

        public MoneyCase? TGetByID(int id)
        {
           return _moneyCasesDal.GetByID(id);
        }

        public List<MoneyCase> TGetListAll()
        {
            return _moneyCasesDal.GetListAll();
        }

        public void TInsert(MoneyCase entity)
        {
            _moneyCasesDal.Insert(entity);
        }

        public decimal TTotalMoneyCaseAmount()
        {
            return _moneyCasesDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(MoneyCase entity)
        {
            _moneyCasesDal.Update(entity);
        }
    }
}
