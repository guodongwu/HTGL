using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.Web
{
    /// <summary>
    /// Action执行状态
    /// </summary>
    public enum EnumActionExecutedStatus
    {
        Success = 1,
        Error = -1,
        CanNotDelete = -2
    }
}
