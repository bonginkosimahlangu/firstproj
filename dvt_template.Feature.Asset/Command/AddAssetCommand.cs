using dvt_template.Feature.Asset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.Asset.Command
{
    public class AddAssetCommand : CommandResultBase, IRequest<AssetViewModel>
    {
        public AssetViewModel Asset { get; set; }
    }
}
