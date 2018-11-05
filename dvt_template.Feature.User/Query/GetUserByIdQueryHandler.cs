using dvt_template.Feature.User.Service;
using dvt_template.Feature.User.ViewModel;
using dvt_template.Shared.Core.Usecases.Data.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dvt_template.Feature.User.Query
{
    public class GetUserByIdQueryHandler : QueryHandlerBase, IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        public Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string validateModel = request == null ? "Command model is null, bad request" : request.ValidateModel();

                var queryService = new ServiceQuery();
                var user = queryService.GetUserByID(request.UserId);

                return Task.FromResult<UserViewModel>(new UserViewModel
                {

                    Id = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName


                });


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
