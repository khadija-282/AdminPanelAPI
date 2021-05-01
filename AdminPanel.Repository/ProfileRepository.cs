using AdminPanel.DataLayer;
using AdminPanel.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Repository
{
   public class ProfileRepository: IProfileRepository
    {
        private readonly AdminPanelEntities _context = new AdminPanelEntities();
        public Profile GetProfileByEmail(string email)
        {
            return _context.Profiles.Where(x => x.Email == email && x.isDeleted==false).ToList().FirstOrDefault();
        }
        public Profile GetProfileById(long id)
        {
            return _context.Profiles.Where(x => x.Id == id).ToList().FirstOrDefault();
        }
        public Profile AddProfile(Profile u)
        {
            try
            {
                var exists = _context.Profiles.Where(x => x.Email.Trim() == u.Email && x.isDeleted==false).ToList().Count();
                if (exists > 0)
                {
                    return GetProfileByEmail(u.Email);
                }
                var isInserted = _context.Profiles.Add(u);
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
        public Profile UpdateProfile(Profile u)
        {
            try
            {
                var exists = _context.Profiles.Where(x => x.Email.Trim() == u.Email.Trim()).ToList().FirstOrDefault();
                if (exists!=null && exists.Id > 0)
                {
                    exists.MobileNumber = u.MobileNumber;
                    exists.FullName = u.FullName;
                    exists.FatherName = u.FatherName;
                    exists.Gender = u.Gender;
                    exists.Address = u.Address;
                    exists.Email = u.Email;
                    exists.NIC = u.NIC;
                    _context.Entry(exists).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return exists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteProfile(Profile u)
        {
            try
            {
                var exists = _context.Profiles.Where(x => x.Email.Trim() == u.Email).ToList().FirstOrDefault();
                if (exists!=null && exists.Id > 0)
                {
                    exists.isDeleted = true;
                    _context.Entry(exists).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
