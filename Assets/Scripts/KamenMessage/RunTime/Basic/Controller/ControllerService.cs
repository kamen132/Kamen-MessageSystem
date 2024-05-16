using System;
using System.Linq;
using System.Reflection;
using KamenMessage.RunTime.Basic.Message;
using UnityEngine;

namespace KamenMessage.RunTime.Service.RunTime.Basic.Controller
{
    public class ControllerService : MonoBehaviour
    {
        #region fortest

        public static ControllerService Instance;

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        private void Start()
        {
            string controllerName = "Game.Controller";
            foreach (Type item in (from type in AppDomain.CurrentDomain.GetAssemblies().First((Assembly a) => a.GetName().Name == controllerName).GetTypes()
                where type.GetInterfaces().Any((Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IController<>))
                select type).ToList())
            {
                Type controllerType = item;
                var controllerInstance = Activator.CreateInstance(controllerType);
                Type messageType = (from t in controllerType.GetInterfaces()
                    where t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IController<>)
                    select t.GetGenericArguments().FirstOrDefault()).FirstOrDefault();
                MethodInfo handleMethod = controllerType.GetMethod("Handle");
                if (!(handleMethod == null) && !(messageType == null))
                {
                    MessageService.Instance.Register(messageType, (msg) =>
                    {
                        handleMethod.Invoke(controllerInstance, new object[1] {msg});
                    });
                }
            }
        }
    }
}