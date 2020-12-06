using System;

namespace DIContainer.Modules
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type interfaceType);

        void CreateMapping<TInterface, TImplementation>();
    }
}
