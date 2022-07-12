using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions.Note
{
    [Serializable]
    public class PermissionInsufficient : Exception
    {
        public PermissionInsufficient() : base("Permission Insufficient to Complete the Action.") { }
    }
}
