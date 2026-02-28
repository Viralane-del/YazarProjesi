using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;
        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }
        public Message GetByID(int id)
        {
            return _messageDAL.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string m)
        {
            return _messageDAL.List(x =>x.ReceiverMail == m);
        }

        public List<Message> GetListSendbox(string m)
        {
            return _messageDAL.List(x => x.SenderMail == m);
        }

        public List<Message> GetListTask()
        {
            return _messageDAL.List(x => x.MessageStatus == false);
        }

        public void MessageAdd(Message message)
        {
             _messageDAL.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
