namespace Achitecture.Domain.Common.InjectionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class ScopedDependencyAttribute : System.Attribute
    {
        public ScopedDependencyAttribute()
        {
            
        }
    }
}
