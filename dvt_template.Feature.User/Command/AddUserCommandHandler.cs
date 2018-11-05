using dvt_template.Shared.Core.Usecases.Data.General;
using System;
using System.Collections.Generic;
using System.Text;
using dvt_template.Feature.User.ViewModel;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using dvt_template.Feature.User.Service;


namespace dvt_template.Feature.User.Command
{
    public class AddUserCommandHandler : CommandHandlerBase, IRequestHandler<AddUserCommand, UserViewModel>
    {
        public Task<UserViewModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null, bad request" : request.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var commandService = new ServiceCommand();
                    var User = commandService.CreateUser(request.User);
                    commandService.SaveChanges();


                    return Task.FromResult<UserViewModel>(new UserViewModel
                    {
                        Id = User.UserId,
                        FirstName = User.FirstName,
                        LastName = User.LastName
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
