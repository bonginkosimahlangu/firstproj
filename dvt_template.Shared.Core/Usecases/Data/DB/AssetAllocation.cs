using System;
using System.Collections.Generic;

namespace dvt_template.Shared.Core.DB
{
    public partial class AssetAllocation
    {
        public int AllocationId { get; set; }
        public int? UserId { get; set; }
        public int? SerialNumber { get; set; }
        public DateTime? DateAllocated { get; set; }
        public int? AssetStatusId { get; set; }

        public AssetStatus AssetStatus { get; set; }
        public Asset SerialNumberNavigation { get; set; }
        public User User { get; set; }
    }
}
