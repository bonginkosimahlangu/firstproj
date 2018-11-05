using dvt_template.Feature.ManageAsset.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.ManageAsset.Query
{
    public class GetManageAssetByIdQuery : QueryBase, IRequest<ManageAssetViewModel>
    {
        public int AllocationID;
    }
}
