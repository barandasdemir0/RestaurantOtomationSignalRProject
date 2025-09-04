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
    public class MessageManager:IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message? TGetByID(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<Message> TGetListAll()
        {
            return _messageDal.GetListAll();
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
