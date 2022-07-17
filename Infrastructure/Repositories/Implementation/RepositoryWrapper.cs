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
        private IUserNoteRepository _userNoteRepository;
        private IProjectUsersRepository _projectUsersRepository;
        private IProjectRepository _projectRepository;
        private IProjectNotesRepository _projectNotesRepository;
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

        public IUserNoteRepository UserNoteRepository
        {
            get
            {
                if(_userNoteRepository is null)
                {
                    _userNoteRepository = new UserNoteRepository(_dbContext);
                }
                return _userNoteRepository;
            }
        }

        public IProjectNotesRepository ProjectNotesRepository
        {
            get
            {
                if(_projectNotesRepository is null)
                {
                    _projectNotesRepository = new ProjectNotesRepository(_dbContext);
                }
                return _projectNotesRepository;
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                if(_projectRepository is null)
                {
                    _projectRepository = new ProjectRepository(_dbContext);
                }
                return _projectRepository;
            }
        }

        public IProjectUsersRepository ProjectUsersRepository
        {
            get
            {
                if(_projectUsersRepository is null)
                {
                    _projectUsersRepository = new ProjectUsersRepository(_dbContext);
                }
                return _projectUsersRepository;
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
