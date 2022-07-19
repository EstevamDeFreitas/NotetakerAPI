using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions.Note
{
    [Serializable]
    public class UserCantChangeHisAccessLevel : Exception
    {
        public UserCantChangeHisAccessLevel() : base("A user can't change his access for a note or project that he already owns.") { }
    }
}
