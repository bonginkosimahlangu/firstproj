using dvt_template.Feature.Asset.ViewModel;
using dvt_template.Shared.Core.Usecases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.Asset.Service
{
    public class ServiceCommand : ServiceCommandBase
    {
        public dvt_template.Shared.Core.DB.Asset CreateAsset(AssetViewModel asset)
        {
            var Asset = new dvt_template.Shared.Core.DB.Asset
            {
                SerialNumber = asset.SerialNumber,
                AssetModel = asset.AssetModel,
                AssetTypeId = asset.AssetTypeId
            };
            dbcontext.Asset.Add(Asset);
            dbcontext.SaveChanges();

            return Asset;
        }

        //Update
        public Shared.Core.DB.Asset UpdateAsset(AssetViewModel asset)
        {
            var Asset = dbcontext.Asset.Find(asset.SerialNumber);
            dbcontext.Entry(Asset).State = EntityState.Detached;

            Asset = new dvt_template.Shared.Core.DB.Asset()
            {
                SerialNumber = asset.SerialNumber,
                AssetModel = asset.AssetModel,
                AssetTypeId = asset.AssetTypeId
            };
            dbcontext.Entry(Asset).State = EntityState.Modified;
            dbcontext.SaveChanges();

            return Asset;
        }

        //Delete
        public void DeleteAsset(int id)
        {
            var asset = dbcontext.Asset.Find(id);
            dbcontext.Asset.Remove(asset);
            dbcontext.SaveChanges();
        }
    }
}
