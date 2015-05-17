using DevQuiz.Core.Models.ViewModels;
using DevQuiz.Core.Services.Implementation;
using DevQuiz.Core.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevQuiz.Core
{
    public class ServiceContainer
    {
        private static object locker = new object();
        private volatile static ServiceContainer instance;
        private static readonly Dictionary<Type, Lazy<object>> services = new Dictionary<Type, Lazy<object>>();

        public static ServiceContainer Instance { get { return instance; } }

        public void Register<T>(Func<T> factory)
        {
            services[typeof(T)] = new Lazy<object>(() => factory());
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private static object Resolve(Type type)
        {
            Lazy<object> service;

            if (services.TryGetValue(type, out service))
                return service.Value;

            throw new Exception("Service not found!");
        }

        public static bool SetInstance(ServiceContainer sentInstance)
        {
            lock (locker)
                if (!HasInstance)
                {
                    instance = sentInstance;
                    return true;
                }

            return false;
        }

        public static bool SetInstance(string jsonSerializedInstance)
        {
            return SetInstance(JsonConvert.DeserializeObject<ServiceContainer>(jsonSerializedInstance));
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(Instance);
        }

        public static bool HasInstance { get { return instance != null; } }

        public static void Initialize()
        {
            instance = instance ?? (new ServiceContainer());

            // register services
            instance.Register<IGameWebService>(() => new LocalGameWebService());

            // register view models
            instance.Register<GameViewModel>(() => new GameViewModel());
            instance.Register<AboutViewModel>(() => new AboutViewModel());
            instance.Register<MainViewModel>(() => new MainViewModel());
        }
    }
}

