using dvt_template.Feature.Asset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.Asset.Command
{
    public class DeleteAssetCommand : CommandResultBase, IRequest<AssetViewModel>
    {
        public int SerialNumber { get; set; }
    }
}
