using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        List<Basket> GetBasketsByMenuTableNumber(int id);
    }
}
