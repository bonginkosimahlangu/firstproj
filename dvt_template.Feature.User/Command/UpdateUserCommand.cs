using dvt_template.Feature.User.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.User.Command
{
	public class UpdateUserCommand: CommandResultBase, IRequest<UserViewModel>
	{
		public UserViewModel User { get; set; }
	}
}
