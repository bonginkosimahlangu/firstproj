using dvt_template.Feature.ManageAsset.Service;
using dvt_template.Feature.ManageAsset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.ManageAsset.Query
{
    public class GetManageAssetByIdQueryHandler : QueryHandlerBase, IRequestHandler<GetManageAssetByIdQuery, ManageAssetViewModel>
    {
        public Task<ManageAssetViewModel> Handle(GetManageAssetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null, bad request" : request.ValidateModel();

                var queryService = new ServiceQuery();
                var manageAsset = queryService.GetMangeAssetByID(request.AllocationID);
                return Task.FromResult<ManageAssetViewModel>(new ManageAssetViewModel
                {
                   AllocationID = manageAsset.AllocationId,
                   AssetStatusID = manageAsset.AssetStatusId,
                   DateAllocated = manageAsset.DateAllocated,
                   SerialNumber = manageAsset.SerialNumber,
                   UserID = manageAsset.UserId
                });
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}
