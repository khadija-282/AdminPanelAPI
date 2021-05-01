
using AdminPanel.DataLayer;
using AdminPanelAPI.DTO;
using AdminPanelAPI.Repository.Interface;
using AdminPanelAPI.Service.Interface;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace AdminPanelAPI.Service.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository _repo;
        private EmailService _email;
       public UserService(IUserRepository repo)
        {
            _repo = repo;
            _email = new EmailService();
        }
        public UserDTO GetUser(string username, string password)
        {
            try
            {
                var u= _repo.GetUser(username, password);
                var user = new UserDTO()
                {
                    Email = u.Email,
                    isActive = true,
                    isDeleted = false,
                    Password=u.Password
                };
                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool RegisterUser(UserDTO u,EmailDTO e)
        {
            try
            {
                var us = new User()
                {
                    Email = u.Email,
                    isActive = true,
                    isDeleted = false,
                    Password=u.Password,
                    isVerified=true
                };
                var result =_repo.RegisterUser(us);
                if(result.Id>0)
                { 
                    //var isSent= _email.SendEmail(u.Email, e.Body, e.Subject);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public UserDTO UpdatePassword(UserDTO u)
        {
            try
            {
                var us = new User()
                {
                    Email = u.Email,
                    isActive = true,
                    isDeleted = false,
                    Password=u.Password
                };
                var result = _repo.UpdatePassword(us);
                if (result > 0)
                {
                    return u;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}