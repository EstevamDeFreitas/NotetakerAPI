using Microsoft.Extensions.Configuration;
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

        public ServiceWrapper(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repository, configuration));
        }
        public IUserService UserService => _userService.Value;
    }
}
