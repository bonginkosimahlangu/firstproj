using dvt_template.Shared.Core.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Shared.Core.Usecases
{
    public class ServiceCommandBase : Disposable, IDbFactory
    {
        protected DVTInventorySystemContext dbcontext;

        public DVTInventorySystemContext Init()
        {
            return dbcontext ?? (dbcontext = new DVTInventorySystemContext());
        }
        public ServiceCommandBase()
        {
            dbcontext = dbcontext ?? (dbcontext = new DVTInventorySystemContext());
        }
        protected override void DisposeCore()
        {
            if (dbcontext != null)
                dbcontext.Dispose();
        }
        public int SaveChanges()
        {
            return dbcontext.SaveChanges();
        }
    }
}
