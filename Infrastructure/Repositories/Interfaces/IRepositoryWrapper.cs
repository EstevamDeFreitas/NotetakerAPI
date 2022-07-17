using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        INoteRepository NoteRepository { get; }
        IUserNoteRepository UserNoteRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IProjectNotesRepository ProjectNotesRepository { get; } 
        IProjectUsersRepository ProjectUsersRepository { get; }
        void Save();
    }
}
