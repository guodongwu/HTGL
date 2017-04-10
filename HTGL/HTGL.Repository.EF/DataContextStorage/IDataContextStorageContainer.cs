using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTGL.Repository.EF
{
    public interface IDataContextStorageContainer
    {
        DefaultDbContext GetDataContext();
        void Store(DefaultDbContext _defaultDbContext);
    }
}
