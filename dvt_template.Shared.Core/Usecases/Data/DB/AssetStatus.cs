using System;
using System.Collections.Generic;

namespace dvt_template.Shared.Core.DB
{
    public partial class AssetStatus
    {
        public AssetStatus()
        {
            AssetAllocation = new HashSet<AssetAllocation>();
        }

        public int AssetStatusId { get; set; }
        public string Desscription { get; set; }

        public ICollection<AssetAllocation> AssetAllocation { get; set; }
    }
}
