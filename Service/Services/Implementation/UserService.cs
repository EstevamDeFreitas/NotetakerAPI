using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Service.DTO.User;
using Service.Exceptions.User;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper repository;

        public UserService(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        public void Create(UserCreateDto user)
        {
            if(VerifyIfEmailIsInUse(user.Email)){
                throw new EmailInUse(user.Email);
            }

            var newUser = new User()
            {
                Email = user.Email,
                Password = user.Password
            };

            newUser.Generate();

            this.repository.UserRepository.Create(newUser);
            this.repository.Save();
        }

        public void Delete(UserDto user)
        {
            var userResult = this.repository.UserRepository.FindByCondition(x => x.Id == user.Id).FirstOrDefault();

            if(userResult is not null)
            {
                this.repository.UserRepository.Delete(userResult);
            }

        }

        public void Update(UserDto user)
        {
            var userOld = this.repository.UserRepository.FindByCondition(x => x.Id == user.Id).FirstOrDefault();

            if(userOld is not null)
            {
                userOld.Email = user.Email;
                userOld.Password = user.Password;

                this.repository.UserRepository.Update(userOld);
                this.repository.Save();
            }
        }

        public bool VerifyIfUserExists(UserDto user)
        {
            return this.repository.UserRepository.FindByCondition(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault() is not null;
        }

        public bool VerifyIfEmailIsInUse(string email)
        {
            return this.repository.UserRepository.FindByCondition(x => x.Email == email).FirstOrDefault() is not null;
        }
    }
}
