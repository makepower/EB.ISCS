using System;

namespace EB.ISCS.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class NoLogAttribute : Attribute
    {
    }
}