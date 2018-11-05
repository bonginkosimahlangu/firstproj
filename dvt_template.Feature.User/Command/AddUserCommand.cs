using System;
using System.Collections.Generic;
using System.Text;
using dvt_template.Shared.Core.Usecases.Data.General;
using dvt_template.Feature.User.ViewModel;
using MediatR;

namespace dvt_template.Feature.User.Command
{
    public class AddUserCommand: CommandResultBase, IRequest<UserViewModel>
    {
        public UserViewModel User { get; set; }
    }
}
