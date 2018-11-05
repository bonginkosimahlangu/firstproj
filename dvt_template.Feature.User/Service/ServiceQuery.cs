using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dvt_template.Shared.Core.Usecases;

namespace dvt_template.Feature.User.Service
{
    public class ServiceQuery: ServiceQueryBase
    {
        public dvt_template.Shared.Core.DB.User GetUserByID (int id)
        {
            return DbContext.User.FirstOrDefault(_ => _.UserId == id);
        }

        public IQueryable <Shared.Core.DB.User> GetAllUsers()
        {
            return DbContext.User.AsQueryable();
        }
    }
}
