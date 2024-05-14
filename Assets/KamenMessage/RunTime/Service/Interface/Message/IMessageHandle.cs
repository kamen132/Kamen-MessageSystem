using System;

namespace KamenMessage.RunTime.Service.Interface.Message
{
    public interface IMessageHandle
    {
        Type MessageType { get; }

        void Handle(object msg);
    }

}