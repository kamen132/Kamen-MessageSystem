using KamenMessage.RunTime.Basic.Message;
using KamenMessage.RunTime.Interface.Message;

namespace KamenMessage.RunTime.Service.RunTime.Basic.Controller
{
    public abstract class AutoController<TMsg> : IController<TMsg> where TMsg : MessageModel
    {
        protected IMessageService MessageService => KamenMessage.RunTime.Basic.Message.MessageService.Instance;

        public abstract void Handle(TMsg msg);
    }

}