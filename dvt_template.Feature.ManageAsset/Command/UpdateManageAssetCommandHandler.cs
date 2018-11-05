using dvt_template.Feature.ManageAsset.Service;
using dvt_template.Feature.ManageAsset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.ManageAsset.Command
{
    public class UpdateManageAssetCommandHandler : CommandHandlerBase, IRequestHandler<UpdateManageAssetCommand, ManageAssetViewModel>
    {
        public Task<ManageAssetViewModel> Handle(UpdateManageAssetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null,bad request" : request.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var commandService = new ServiceCommand();
                    var manageAsset = commandService.ManageAsset(request.ManageAssets);
                    commandService.SaveChanges();

                    return Task.FromResult<ManageAssetViewModel>(new ManageAssetViewModel
                    {
                        AllocationID = manageAsset.AllocationId,
                        AssetStatusID = manageAsset.AssetStatusId,
                        DateAllocated = manageAsset.DateAllocated,
                        SerialNumber = manageAsset.SerialNumber,
                        UserID = manageAsset.UserId
                    });
                }
                throw new Exception(validateModel);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
