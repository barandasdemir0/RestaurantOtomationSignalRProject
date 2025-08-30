using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        List<Basket> TGetBasketsByMenuTableNumber(int id);
    }
}
