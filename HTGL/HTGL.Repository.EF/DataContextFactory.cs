using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HTGL.Repository.EF;
using System.Runtime.Remoting.Messaging;

namespace HTGL.Repository.EF
{
    public class DataContextFactory
    {
        public static DefaultDbContext GetCurrentDbContext()
        {
            IDataContextStorageContainer _dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();
            DefaultDbContext _defaultDbContext = _dataContextStorageContainer.GetDataContext();
            if (_defaultDbContext == null)
            {
                _defaultDbContext = new DefaultDbContext();
                _dataContextStorageContainer.Store(_defaultDbContext);
            }
            return _defaultDbContext;




        }
     
    }
}
