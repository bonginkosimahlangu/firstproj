using dvt_template.Feature.Asset.Service;
using dvt_template.Feature.Asset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.Asset.Query
{
    public class GetAllAssetsQueryHandler : QueryHandlerBase, IRequestHandler<GetAllAssetsQuery, List<AssetViewModel>>
    {
        public Task<List<AssetViewModel>> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null, bad request" : request.ValidateModel();
                var queryService = new ServiceQuery();

                var result = queryService.GetAllAssets();

                return Task.FromResult<List<AssetViewModel>>(result.Select(Asset => new AssetViewModel
                {
                    SerialNumber = Asset.SerialNumber,
                    AssetModel = Asset.AssetModel,
                    AssetTypeId = Asset.AssetTypeId

                }).ToList());

            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}
