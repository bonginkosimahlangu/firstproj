using dvt_template.Shared.Core.Usecases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dvt_template.Shared.Core.Usecases.Data.General;

namespace dvt_template.Feature.ManageAsset.Service
{
   public class ServiceQuery: ServiceQueryBase
    {

        public dvt_template.Shared.Core.DB.AssetAllocation GetMangeAssetByID(int id)
        {
            return DbContext.AssetAllocation.FirstOrDefault(x => x.AllocationId == id);
        }

        public IQueryable<Shared.Core.DB.AssetAllocation> GetManageAssets()
        {
            return DbContext.AssetAllocation.AsQueryable();
        }
    }
}
