﻿using DIContainer.Attributes;
using DIContainer.Modules;
using System;
using System.Reflection;

namespace DIContainer.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            Type classType = typeof(TClass);

            ConstructorInfo[] constructors = classType.GetConstructors();
            foreach (var constructor in constructors)
            {
                if (constructor.GetCustomAttribute(typeof(Inject)) == null)
                {
                    continue;
                };

                ParameterInfo[] constructorParams = constructor.GetParameters();
                object[] implementationsParams = new object[constructorParams.Length];
                int i = 0;

                foreach (var constructorParam in constructorParams)
                {
                    Type implementationType = module.GetMapping(constructorParam.ParameterType);

                    if (implementationType == null)
                    {
                        implementationsParams[i++] = null;
                    }
                    else
                    {
                        implementationsParams[i++] = Activator.CreateInstance(implementationType);
                    }
                }

                return (TClass)Activator.CreateInstance(classType, implementationsParams);
            }

            return default(TClass);
        }
    }
}
