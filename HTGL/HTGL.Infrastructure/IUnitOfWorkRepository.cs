using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTGL.Infrastructure
{
    public interface IUnitOfWorkRepository:IDependency
    {
        void PersistCreationOf(IAggregateRoot entity);
        void PersistUpdateOf(IAggregateRoot entity);
        void PersistDeletionOf(IAggregateRoot entity);
    }
}
