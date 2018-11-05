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
	public class UpdateUserHandler : CommandHandlerBase, IRequestHandler<UpdateUserCommand, UserViewModel>
	{
		public Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			try
			{
				string validateModel = request == null ? "Command model is null,bad request" : request.ValidateModel();
				if (string.IsNullOrEmpty(validateModel))
				{
					var commandService = new ServiceCommand();
					var User = commandService.UpdateUser(request.User);
					commandService.SaveChanges();

					return Task.FromResult<UserViewModel>(new UserViewModel
					{
						Id = User.UserId,
						FirstName = User.FirstName,
						LastName = User.LastName,
						DepartmentId=User.DepartmentId
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
