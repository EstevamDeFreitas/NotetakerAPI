using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions.User
{
    [Serializable]
    public class UserDoNotExist : Exception
    {
        public UserDoNotExist() : base("User doesn't exists.") { }
    }
}
