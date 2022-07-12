using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories.Interfaces;
using Service.DTO.User;
using Service.Exceptions.User;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Service.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper repository;
        private readonly TokenService _tokenService;

        public UserService(IRepositoryWrapper repository, IConfiguration configuration)
        {
            this.repository = repository;
            this._tokenService = new TokenService(configuration);
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
            var userResult = this.repository.UserRepository.FindByCondition(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if(userResult is not null)
            {
                this.repository.UserRepository.Delete(userResult);
                this.repository.Save();
            }

        }

        public void Update(UserUpdateDto user)
        {
            var userOld = this.repository.UserRepository.FindByCondition(x => x.Email == user.Email && x.Password == user.CurrentPassword).FirstOrDefault();

            if(userOld is not null)
            {
                userOld.Email = user.Email;
                userOld.Password = user.NewPassword;
                userOld.ModifiedDate = DateTime.Now;

                this.repository.UserRepository.Update(userOld);
                this.repository.Save();
            }
        }

        public bool VerifyIfUserExists(UserDto user)
        {
            return this.repository.UserRepository.FindByCondition(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault() is not null;
        }

        public bool VerifyIfUserExists(Guid userId)
        {
            return this.repository.UserRepository.FindByCondition(x => x.Id == userId).FirstOrDefault() is not null;
        }

        public bool VerifyIfEmailIsInUse(string email)
        {
            return this.repository.UserRepository.FindByCondition(x => x.Email == email).FirstOrDefault() is not null;
        }

        public string GenerateToken(UserDto user)
        {
            var exists = this.repository.UserRepository.FindByCondition(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (exists is null)
            {
                throw new UserDoNotExist();
            }

            var token = _tokenService.GenerateToken(exists);

            return token;
        }
    }
}
