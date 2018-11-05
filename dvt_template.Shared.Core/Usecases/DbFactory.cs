using System;
using System.Collections.Generic;
using System.Text;
using dvt_template.Shared.Core.DB;

namespace dvt_template.Shared.Core.Usecases
{
    public class DbFactory : Disposable, IDbFactory
    {
        DVTInventorySystemContext _dbContext;

        public DVTInventorySystemContext Init()
        {
            return _dbContext ?? (_dbContext = new DVTInventorySystemContext());
        }
        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }

      
    }
}
