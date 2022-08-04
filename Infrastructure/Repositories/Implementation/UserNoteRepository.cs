using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Implementation
{
    public class UserNoteRepository : RepositoryBase<UserNote>, IUserNoteRepository
    {
        public UserNoteRepository(NotetakerContext dbContext) : base(dbContext)
        {
        }

        public List<UserNote> GetUsersWithAccess(Guid noteId)
        {
            return this.DbContext.Set<UserNote>()
                                .Where(x => x.NoteId == noteId)
                                .Include(x => x.User).ToList();
        }
    }
}
