using dvt_template.Feature.User.Service;
using dvt_template.Feature.User.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.User.Command
{
	public class DeleteUserHandler : CommandHandlerBase, IRequestHandler<DeleteUserCommand, UserViewModel>
	{
		public Task<UserViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{

			try
			{
				string validateModel = request == null ? "Command model is null,bad request" : request.ValidateModel();
				if (string.IsNullOrEmpty(validateModel))
				{
					var commandService = new ServiceCommand();
					commandService.DeleteUser(request.id);
					commandService.SaveChanges();
				}
				return Task.FromResult<UserViewModel>(new UserViewModel { });

			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
