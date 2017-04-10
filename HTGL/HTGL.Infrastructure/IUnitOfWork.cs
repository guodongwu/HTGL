using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTGL.Infrastructure
{
    public interface IUnitOfWork : IDependency,IDisposable
    {
        void Commit();
    }
}
