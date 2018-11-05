using dvt_template.Shared.Core.Usecases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace dvt_template.Feature.Asset.Service
{
    public class ServiceQuery : ServiceQueryBase
    {
        public dvt_template.Shared.Core.DB.Asset GetAssetByID(int id)
        {
            return DbContext.Asset.FirstOrDefault(x => x.SerialNumber == id);
        }

        public IQueryable<Shared.Core.DB.Asset> GetAllAssets()
        {
            return DbContext.Asset.AsQueryable();
        }
    }
}
