using System;
using System.Collections.Generic;

namespace dvt_template.Shared.Core.DB
{
    public partial class AssetType
    {
        public AssetType()
        {
            Asset = new HashSet<Asset>();
        }

        public int AssetTypeId { get; set; }
        public string Description { get; set; }

        public ICollection<Asset> Asset { get; set; }
    }
}
