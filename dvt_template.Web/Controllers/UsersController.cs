using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Autofac;
using dvt_template.Feature.User.Command;
using dvt_template.Feature.User.Query;
using dvt_template.Feature.User.ViewModel;
using dvt_template.Shared.Core.Infrastructure;

namespace dvt_template.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static IMediator _mediator;

        public UserController()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(GetAllUsersQuery).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(GetUserByIdQuery).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AddUserCommand).Assembly).AsImplementedInterfaces();
            _mediator = BootstrapMediatr.BuildMediator(builder);
        }


        [HttpGet]
        [Route("GetAllUsers")]

        public List<UserViewModel> GetAllUsers()
        {
            return _mediator.Send(new GetAllUsersQuery()).Result;
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public UserViewModel GetUserById(int id)
        {
            return _mediator.Send(new GetUserByIdQuery { UserId = id }).Result;
        }

        [HttpPost]
        [Route("AddUser")]
        public void CreateUser([FromBody] UserViewModel user)
        {
            _mediator.Send(new AddUserCommand { User = user });
        }


		[HttpPut]
		[Route("UpdateUser")]
		public void UpdateUser([FromBody] UserViewModel user)
		{
			
			_mediator.Send(new UpdateUserCommand { User = user });
		}

		[HttpDelete]
		[Route("DeleteUser")]
		public void Delete(int id)
		{
			_mediator.Send(new DeleteUserCommand { id = id });
		}

	}
}
