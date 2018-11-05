using System;
using System.Collections.Generic;

namespace dvt_template.Shared.Core.DB
{
    public partial class Department
    {
        public Department()
        {
            User = new HashSet<User>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentLocation { get; set; }

        public ICollection<User> User { get; set; }
    }
}
