using KamenMessage.RunTime.Basic.Message;

namespace KamenMessage.RunTime.Service.RunTime.Basic.Controller
{
    public interface IController<in T> where T : MessageModel
    {
        void Handle(T msg);
    }

}