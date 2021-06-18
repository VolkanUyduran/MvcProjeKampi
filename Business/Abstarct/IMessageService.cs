using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IMessageService
    {
        List<Message> GetAllRead();
        List<Message> IsDraft();
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        Message GetById(int id);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
