using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Abstract
{
    public interface IMenuTablesDal:IGenericDal<MenuTable>
    {
        int MenuTableCount();
        void ChangeMenuTableStatusToTrue(int id);
        void ChangeMenuTableStatusToFalse(int id);
    }
}
