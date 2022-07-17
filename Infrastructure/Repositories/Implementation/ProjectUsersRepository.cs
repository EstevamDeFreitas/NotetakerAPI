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
    public class ProjectUsersRepository : RepositoryBase<ProjectUsers>, IProjectUsersRepository
    {
        public ProjectUsersRepository(NotetakerContext dbContext) : base(dbContext)
        {
        }
    }
}
