﻿using Microsoft.Extensions.Configuration;
using Persistence.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementation
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IAccessVerifier> _accessVerifier;
        private readonly Lazy<INoteService> _noteService;

        public ServiceWrapper(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repository, configuration));
            _accessVerifier = new Lazy<IAccessVerifier>(() => new AccessVerifier(repository));
            _noteService = new Lazy<INoteService>(() => new NoteService(repository));
        }
        public IUserService UserService => _userService.Value;

        public IAccessVerifier AccessVerifier => _accessVerifier.Value;

        public INoteService NoteService => _noteService.Value;  
    }
}
