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
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private NotetakerContext _dbContext;
        private IUserRepository _userRepository;
        private INoteRepository _noteRepository;
        public IUserRepository UserRepository
        {
            get 
            {
                if( _userRepository is null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }

                return _userRepository;
            }
        }

        public INoteRepository NoteRepository
        {
            get 
            { 
                if(_noteRepository is null)
                {
                    _noteRepository = new NoteRepository(_dbContext);
                }
                return _noteRepository; 
            }
        }

        public RepositoryWrapper(NotetakerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
