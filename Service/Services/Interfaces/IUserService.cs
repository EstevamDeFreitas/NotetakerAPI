﻿using Service.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        //List<UserDto> GetAllUsers();
        bool VerifyIfUserExists(UserDto user);
        void Create(UserCreateDto user);
        void Update(UserDto user);
        void Delete(UserDto user);
        bool VerifyIfEmailIsInUse(string email);
    }
}