using dvt_template.Feature.Asset.Service;
using dvt_template.Feature.Asset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.Asset.Command
{
    public class DeleteAssetHandler : CommandHandlerBase, IRequestHandler<DeleteAssetCommand, AssetViewModel>
    {
        public Task<AssetViewModel> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null,bad request" : request.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var commandService = new ServiceCommand();
                    commandService.DeleteAsset(request.SerialNumber);
                    commandService.SaveChanges();                    
                }
                return Task.FromResult<AssetViewModel>(new AssetViewModel { });

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
