using System;
using System.Collections.Generic;
using KamenMessage.RunTime.Service.Basic.Message;
using KamenMessage.RunTime.Service.Interface.Message;

namespace KamenMessage.RunTime.Service.Basic.model
{
    public abstract class ManualModel : IModel
    {
        private readonly List<IDisposable> _entrustDisposables = new List<IDisposable>();

        ~ManualModel()
        {
            EntrustDisposablesClear();
        }

        protected void EntrustDisposable(IDisposable disposable)
        {
            _entrustDisposables.Add(disposable);
        }

        protected IDisposable Register<T>(Action<T> callback) where T : MessageModel
        {
            IDisposable disposable = MessageService.Instance.Register(callback);
            EntrustDisposable(disposable);
            return disposable;
        }

        public void EntrustDisposablesClear()
        {
            foreach (IDisposable entrustDisposable in _entrustDisposables)
            {
                entrustDisposable.Dispose();
            }
            _entrustDisposables.Clear();
        }
    }
}