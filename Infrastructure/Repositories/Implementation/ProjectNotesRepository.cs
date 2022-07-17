using Domain.Entities;
using Infrastructure.Database;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Implementation
{
    public class ProjectNotesRepository : RepositoryBase<ProjectNotes>, IProjectNotesRepository
    {
        public ProjectNotesRepository(NotetakerContext dbContext) : base(dbContext)
        {
        }
    }
}
