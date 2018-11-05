using dvt_template.Feature.ManageAsset.ViewModel;
using dvt_template.Shared.Core.Usecases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.ManageAsset.Service
{
    public class ServiceCommand : ServiceCommandBase
    {
        public dvt_template.Shared.Core.DB.AssetAllocation NewManageAsset(ManageAssetViewModel manageasset)
        {
            var manageAsset = new dvt_template.Shared.Core.DB.AssetAllocation
            {
                AssetStatusId = manageasset.AssetStatusID,
                DateAllocated = manageasset.DateAllocated,
                SerialNumber = manageasset.SerialNumber,
                UserId = manageasset.UserID
            };
            dbcontext.AssetAllocation.Add(manageAsset);
            dbcontext.SaveChanges();

            return manageAsset;
        }


        public dvt_template.Shared.Core.DB.AssetAllocation ManageAsset(ManageAssetViewModel manageasset)
        {

            var manageAsset = dbcontext.AssetAllocation.Find(manageasset.AllocationID);
            dbcontext.Entry(manageAsset).State = EntityState.Detached;

            manageAsset = new dvt_template.Shared.Core.DB.AssetAllocation
            {
               AllocationId = manageasset.AllocationID,
                AssetStatusId = manageasset.AssetStatusID,
                DateAllocated = manageasset.DateAllocated,
                SerialNumber = manageasset.SerialNumber,
                UserId = manageasset.UserID
            };
            dbcontext.Entry(manageAsset).State = EntityState.Modified;
            dbcontext.SaveChanges();

            return manageAsset;
        }

        public Shared.Core.DB.AssetAllocation DeleteManageAsset(int manageAsset)
        {
            var toDelete = dbcontext.AssetAllocation.Find(manageAsset);           
            dbcontext.Remove(toDelete);
            return toDelete;
            
        }

    }
}
