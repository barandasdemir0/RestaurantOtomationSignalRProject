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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> TGetLast6Products()
        {
           return _productDal.GetLast6Products();
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product? TGetByID(int id)
        {
           return _productDal.GetByID(id);
        }

        public List<Product> TGetListAll()
        {
           return _productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public void TInsert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public int TProductCount()
        {
           return _productDal.ProductCount();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _productDal.ProductCountByCategoryNameHamburger();
        }

        public int TProductCountByCategoryNamePizza()
        {
           return _productDal.ProductCountByCategoryNamePizza();
        }

        public decimal TProductPriceAverage()
        {
            return _productDal.ProductPriceAverage();
        }

        public decimal TProductPriceByHamburger()
        {
            return _productDal.ProductPriceByHamburger();
        }

        public string TProductPriceByMax()
        {
            return _productDal.ProductPriceByMax();
        }

        public string TProductPriceByMin()
        {
            return _productDal.ProductPriceByMin();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
