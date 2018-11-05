using dvt_template.Shared.Core.Usecases;
using System;
using System.Collections.Generic;
using System.Text;
using dvt_template.Feature.User.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace dvt_template.Feature.User.Service
{
    public class ServiceCommand: ServiceCommandBase
    {
        public dvt_template.Shared.Core.DB.User CreateUser (UserViewModel user)
        {
            var User = new dvt_template.Shared.Core.DB.User
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            dbcontext.User.Add(User);
            dbcontext.SaveChanges();

            return User;
        }

		
		public Shared.Core.DB.User UpdateUser(UserViewModel user)
		{
			var User = dbcontext.User.Find(user.Id);
			dbcontext.Entry(User).State = EntityState.Detached;

			User = new dvt_template.Shared.Core.DB.User()
			{
				UserId = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				DepartmentId=user.DepartmentId,
			};
			dbcontext.Entry(User).State = EntityState.Modified;
			dbcontext.SaveChanges();

			return User;
		}

		
		public void DeleteUser(int id)
		{
			var user = dbcontext.User.Find(id);
			dbcontext.User.Remove(user);
			dbcontext.SaveChanges();
		}
	}
}
