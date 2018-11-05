using dvt_template.Shared.Core.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace dvt_template.Shared.Core.Usecases
{
    public interface IDbFactory
    {
        DVTInventorySystemContext Init();
    }
}
