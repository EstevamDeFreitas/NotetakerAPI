using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IServiceWrapper
    {
        IUserService UserService { get; }
        IAccessVerifier AccessVerifier { get; }
        INoteService NoteService { get; }
    }
}
