using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HTGL.Repository.EF
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private string _dataContextKey = "ef_DataContext";

        public DefaultDbContext GetDataContext()
        {
            DefaultDbContext objectContext = null;
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                objectContext = (DefaultDbContext)HttpContext.Current.Items[_dataContextKey];
            return objectContext;
        }

        public void Store(DefaultDbContext _defaultDbContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                HttpContext.Current.Items[_dataContextKey] = _defaultDbContext;
            else
                HttpContext.Current.Items.Add(_dataContextKey, _defaultDbContext);
        }
    }
}
