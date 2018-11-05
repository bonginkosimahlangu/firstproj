using dvt_template.Feature.ManageAsset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.ManageAsset.Command
{
    public class UpdateManageAssetCommand : CommandResultBase, IRequest<ManageAssetViewModel>
    {
        public ManageAssetViewModel ManageAssets { get; set; }
    }
}
