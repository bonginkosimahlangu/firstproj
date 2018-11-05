using dvt_template.Feature.User.Service;
using dvt_template.Feature.User.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.User.Query
{
    public class GetAllUsersQueryHandler : QueryHandlerBase, IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        public Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null, bad request" : request.ValidateModel();
                var queryService = new ServiceQuery();
                var result = queryService.GetAllUsers();

                return Task.FromResult<List<UserViewModel>>(result.Select(User => new UserViewModel
                {
                    Id = User.UserId,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    DepartmentId =User.DepartmentId
                }).ToList());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
