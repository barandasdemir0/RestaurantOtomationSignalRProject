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
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int TCategoryActiveCount()
        {
            return _categoryDal.CategoryActiveCount();
        }

        public int TCategoryCount()
        {
          return  _categoryDal.CategoryCount();
        }

        public int TCategoryPassiveCount()
        {
            return _categoryDal.CategoryPassiveCount();
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category? TGetByID(int id)
        {
           return _categoryDal.GetByID(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();   
        }

        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
