using DependencyInjection.Caching;
using DependencyInjection.Core;

namespace DependencyInjection.Injectors
{
    /// <summary>
    /// Used for manual attribute injection of fields, properties and methods.
    /// </summary>
    public static class AttributeInjector
    {
        public static void Inject(object obj, Container container)
        {
            var info = TypeInfoCache.Get(obj.GetType());

            for (int i = 0; i < info.InjectableFields.Length; i++)
            {
                FieldInjector.Inject(info.InjectableFields[i], obj, container);
            }
            
            for (int i = 0; i < info.InjectableProperties.Length; i++)
            {
                PropertyInjector.Inject(info.InjectableProperties[i], obj, container);
            }

            for (int i = 0; i < info.InjectableMethods.Length; i++)
            {
                MethodInjector.Inject(info.InjectableMethods[i], obj, container);
            }
        }
    }
}