using Newtonsoft.Json;
//  ServiceContainer.cs
//
//  Author:
//       Vedran Mandić <mandic.vedran@gmail.com>
//
//  Copyright (c) 2015 vmandic
//
using System;
using System.Collections.Generic;

namespace DevQuiz.Core
{
    public class ServiceContainer
    {
        private static object locker = new object();
        private volatile static ServiceContainer instance;
        private static readonly Dictionary<Type, Lazy<object>> services = new Dictionary<Type, Lazy<object>>();

        public static ServiceContainer Instance { get { return instance ?? (instance = new ServiceContainer()); } }

        public static void Register<T>(Func<T> factory)
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
            {
                if (!HasInstance)
                {
                    instance = sentInstance;
                    return true;
                }
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

        public static bool HasInstance { get { return instance == null; } }
    }
}

