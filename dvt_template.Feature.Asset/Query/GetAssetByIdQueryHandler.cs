using dvt_template.Feature.Asset.Service;
using dvt_template.Feature.Asset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.Asset.Query
{
    public class GetAssetByIdQueryHandler : QueryHandlerBase, IRequestHandler<GetAssetByIdQuery, AssetViewModel>
    {
        public Task<AssetViewModel> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null, bad request" : request.ValidateModel();

                var queryService = new ServiceQuery();
                var Asset = queryService.GetAssetByID(request.SerialNumber);
                return Task.FromResult<AssetViewModel>(new AssetViewModel
                {
                    SerialNumber = Asset.SerialNumber,
                    AssetModel = Asset.AssetModel,
                    AssetTypeId = Asset.AssetTypeId
                });
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}
