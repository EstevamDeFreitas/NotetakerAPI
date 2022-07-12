using Persistence.Repositories.Interfaces;
using Service.Exceptions.User;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementation
{
    public class AccessVerifier : IAccessVerifier
    {
        private readonly IRepositoryWrapper _repository;

        public AccessVerifier(IRepositoryWrapper repository)
        {
            this._repository = repository;
        }

        public bool VerifyAccess(Guid bearerId, string ownerEmail)
        {
            var bearerEmail = _repository.UserRepository.FindByCondition(x => x.Id == bearerId).FirstOrDefault();

            if (bearerEmail is null)
            {
                throw new UserDoNotExist();
            }

            if(bearerEmail.Email != ownerEmail)
            {
                throw new UserDoNotExist();
            }

            return true;
        }
    }
}
