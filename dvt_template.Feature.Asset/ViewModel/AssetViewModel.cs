using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Feature.Asset.ViewModel
{
    public class AssetViewModel
    {
       
        public int SerialNumber { get; set; }
        public string AssetModel { get; set; }
        public int? AssetTypeId { get; set; }
    }
}
