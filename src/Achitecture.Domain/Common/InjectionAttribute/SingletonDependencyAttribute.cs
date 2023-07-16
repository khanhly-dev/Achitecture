namespace Achitecture.Domain.Common.InjectionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class SingletonDependencyAttribute : System.Attribute
    {
        public SingletonDependencyAttribute()
        {
            
        }
    }
}
