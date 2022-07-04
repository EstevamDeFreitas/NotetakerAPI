using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO.User
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserCreateDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
