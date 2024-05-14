using System;
using KamenMessage.RunTime.Service.Basic.Message;

namespace KamenMessage.RunTime.Service.Interface.Message
{
    public interface IMessageService
    {
        IDisposable Register<T>(Action<T> callback) where T : MessageModel;

        void Register(Type type, Action<object> callback);

        void Dispatch<T>(T msg) where T : MessageModel;
    }
}