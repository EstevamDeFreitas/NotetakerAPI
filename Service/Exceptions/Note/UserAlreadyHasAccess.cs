using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions.Note
{
    [Serializable]
    public class UserAlreadyHasAccess : Exception
    {
        public UserAlreadyHasAccess(string user) : base(String.Format("User {0} already has access.", user)) { }
    }
}
