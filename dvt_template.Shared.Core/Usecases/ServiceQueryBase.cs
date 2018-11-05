using dvt_template.Shared.Core.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Shared.Core.Usecases
{
    public class ServiceQueryBase : Disposable, IDbFactory
    {
        protected DVTInventorySystemContext DbContext;

        public DVTInventorySystemContext Init()
        {
            return DbContext ?? (DbContext = new DVTInventorySystemContext());
        }
        public ServiceQueryBase()
        {
            DbContext = DbContext ?? (DbContext = new DVTInventorySystemContext());
        }

        protected override void DisposeCore()
        {
            if (DbContext != null)
                DbContext.Dispose();
        }
    }
}
