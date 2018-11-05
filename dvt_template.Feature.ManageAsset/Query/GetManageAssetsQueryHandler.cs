using dvt_template.Feature.ManageAsset.Service;
using dvt_template.Feature.ManageAsset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.ManageAsset.Query
{
    public class GetManageAssetsQueryHandler : QueryHandlerBase, IRequestHandler<GetManageAssetsQuery, List<ManageAssetViewModel>>
    {
        public Task<List<ManageAssetViewModel>> Handle(GetManageAssetsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null, bad request" : request.ValidateModel();
                var queryService = new ServiceQuery();

                var result = queryService.GetManageAssets();

                return Task.FromResult<List<ManageAssetViewModel>>(result.Select(ManageAsset => new ManageAssetViewModel
                {
                    AllocationID = ManageAsset.AllocationId,
                    AssetStatusID = ManageAsset.AssetStatusId,
                    DateAllocated = ManageAsset.DateAllocated,
                    UserID = ManageAsset.UserId,
                    SerialNumber = ManageAsset.SerialNumber
                }).ToList());

            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}

