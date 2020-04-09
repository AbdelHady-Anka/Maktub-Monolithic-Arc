using System;
using System.Collections.Generic;
using System.Text;

namespace maktoob.Application.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    class DatabaseRetryAttribute : Attribute
    {
    }
}
