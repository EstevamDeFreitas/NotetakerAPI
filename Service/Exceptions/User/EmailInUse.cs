using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions.User
{
    [Serializable]
    public class EmailInUse : Exception
    {
        public EmailInUse() { }

        public EmailInUse(string email) : base(String.Format("Email already in use: {0}", email)) { } 
    }
}
