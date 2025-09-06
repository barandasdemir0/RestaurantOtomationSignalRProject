using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        List<Product> GetLast6Products();
        int ProductCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNamePizza();
        decimal ProductPriceAverage();
        string ProductPriceByMax();
        string ProductPriceByMin();
        decimal ProductPriceByHamburger();

    }
}
