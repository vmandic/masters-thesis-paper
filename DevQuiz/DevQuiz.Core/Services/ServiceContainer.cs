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
    public static class ServiceContainer
    {
        private static readonly Dictionary<Type, Lazy<object>> _services = new Dictionary<Type, Lazy<object>>();

        public static void Register<T>(Func<T> factory)
        {
            _services[typeof(T)] = new Lazy<object>(() => factory());    
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));    
        }

        private static object Resolve(Type type)
        {
            Lazy<object> service;

            if (_services.TryGetValue(type, out service))
                return service.Value;
            
            throw new Exception("Service not found!");
        }
    }
}
    
