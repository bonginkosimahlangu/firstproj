using dvt_template.Feature.User.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.User.Query
{
    public class GetUserByIdQuery:QueryBase, IRequest <UserViewModel>
    {
        public int UserId { get; set; }
    }
}
