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
    public class MenuTableManager:IMenuTablesService
    {
        private readonly IMenuTablesDal _menuTablesDal;

        public MenuTableManager(IMenuTablesDal menuTablesDal)
        {
            _menuTablesDal = menuTablesDal;
        }

        public void TChangeMenuTableStatusToFalse(int id)
        {
            _menuTablesDal.ChangeMenuTableStatusToFalse(id);
        }

        public void TChangeMenuTableStatusToTrue(int id)
        {
            _menuTablesDal.ChangeMenuTableStatusToTrue(id);
        }

        public void TDelete(MenuTable entity)
        {
            _menuTablesDal.Delete(entity);
        }

        public MenuTable? TGetByID(int id)
        {
            return _menuTablesDal.GetByID(id);
        }

        public List<MenuTable> TGetListAll()
        {
           return _menuTablesDal.GetListAll();
        }

        public void TInsert(MenuTable entity)
        {
            _menuTablesDal.Insert(entity);
        }

        public int TMenuTableCount()
        {
            return _menuTablesDal.MenuTableCount();
        }

        public void TUpdate(MenuTable entity)
        {
            _menuTablesDal.Update(entity);
        }
    }
}
