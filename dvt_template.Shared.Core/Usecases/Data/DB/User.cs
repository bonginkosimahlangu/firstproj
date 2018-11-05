using System;
using System.Collections.Generic;

namespace dvt_template.Shared.Core.DB
{
    public partial class User
    {
        public User()
        {
            AssetAllocation = new HashSet<AssetAllocation>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<AssetAllocation> AssetAllocation { get; set; }
    }
}
