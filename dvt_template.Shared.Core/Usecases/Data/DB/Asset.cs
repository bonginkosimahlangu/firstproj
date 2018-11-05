using System;
using System.Collections.Generic;

namespace dvt_template.Shared.Core.DB
{
    public partial class Asset
    {
        public Asset()
        {
            AssetAllocation = new HashSet<AssetAllocation>();
        }

        public int SerialNumber { get; set; }
        public string AssetModel { get; set; }
        public int? AssetTypeId { get; set; }

        public AssetType AssetType { get; set; }
        public ICollection<AssetAllocation> AssetAllocation { get; set; }
    }
}
