using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dvt_template.Web.Model
{
    public class AssetViewModel
    {
        public int SerialNumber { get; set; }
        public string AssetModel { get; set; }
        public int? AssetTypeId { get; set; }
    }
}
