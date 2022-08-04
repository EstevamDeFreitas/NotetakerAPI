using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IUserNoteRepository : IRepositoryBase<UserNote>
    {
        List<UserNote> GetUsersWithAccess(Guid noteId);
    }
}
