using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();
        List<Notification> TGetAllNotificationsByFalse();
        void TNotificationStatusChangeToTrue(int id);
        void TNotificationStatusChangeToFalse(int id);
    }
}
