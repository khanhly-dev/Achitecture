namespace Achitecture.Domain.Common.InjectionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class TransientDependencyAttribute : System.Attribute
    {
        public TransientDependencyAttribute()
        {
            
        }
    }
}
