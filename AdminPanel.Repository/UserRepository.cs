using AdminPanelAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AdminPanel.DataLayer;

namespace AdminPanelAPI.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AdminPanelEntities _context = new AdminPanelEntities();

        public UserRepository()
        {
        }
        public User GetUser(string username, string password)
        {
            try
            {
                var user = _context.Users.Where(x => x.Email.Trim() == username && x.Password.Trim() == password && x.isVerified == true && x.isDeleted==false).ToList().FirstOrDefault();
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User RegisterUser(User u)
        {
            try
            {
                var userExists = _context.Users.Where(x => x.Email.Trim() == u.Email).ToList().Count();
                if (userExists > 0)
                {
                    return _context.Users.Where(x => x.Email.Trim() == u.Email).ToList().FirstOrDefault();
                }
                var isInserted = _context.Users.Add(u);
                _context.Entry(u).State = EntityState.Added;
                _context.SaveChanges();
                if (isInserted.Id > 0)
                {
                    return isInserted;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePassword(User u)
        {
            try
            {
                var user = _context.Users.Where(x => x.Email == u.Email).ToList().SingleOrDefault();
                if (user == null)
                {
                    return 0;
                }
                else
                {
                    user.Password = u.Password;
                    user.isVerified = true;
                    _context.Entry(user).State = EntityState.Modified;
                    var isUpdated = _context.SaveChanges();
                    return isUpdated;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}