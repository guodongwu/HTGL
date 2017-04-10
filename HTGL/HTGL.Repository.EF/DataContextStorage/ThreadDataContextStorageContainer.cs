using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace HTGL.Repository.EF
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable DbContexts = new Hashtable();

        public DefaultDbContext GetDataContext()
        {
            DefaultDbContext _defaultDbContext = null;
            if (DbContexts.Contains(GetThreadName()))
                _defaultDbContext =
                (DefaultDbContext)DbContexts[GetThreadName()];
            return _defaultDbContext;
        }

        public void Store(DefaultDbContext sharpCMSDataContext)
        {
            if (DbContexts.Contains(GetThreadName()))
                DbContexts[GetThreadName()] = sharpCMSDataContext;
            else
                DbContexts.Add(GetThreadName(), sharpCMSDataContext);
        }

        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
