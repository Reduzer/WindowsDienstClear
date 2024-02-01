using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    public enum exceptionEnums
    {
        none = 0,
        needsAdminPing = 1,
        needsDevPing = 2,
        needsHelpNow = 3,
        
    }
}
