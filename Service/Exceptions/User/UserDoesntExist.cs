using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions.User
{
    [Serializable]
    public class UserDoesntExist : Exception
    {
        public UserDoesntExist() : base("User doesn't exists.") { }
    }
}
