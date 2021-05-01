using AdminPanel.DataLayer;
using AdminPanel.DTO;
using AdminPanel.IRepository;
using AdminPanelAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelAPI.Service.Implementation
{
    public class ProfileService :IProfileService
    {
        private IProfileRepository _repo;
        public ProfileService(IProfileRepository repo)
        {
            _repo = repo;
        }
        public ProfileDTO GetProfileByEmail(string email)
        {
            try
            {
                var p = _repo.GetProfileByEmail(email);
                if (p == null)
                {
                    return null;
                }
                var profile = new ProfileDTO()
                {
                    Email = p.Email,
                    Address = p.Address,
                    FatherName = p.FatherName,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    Id = p.Id,
                    MobileNumber = p.MobileNumber,
                    NIC = p.NIC,
                    isDeleted = false,
                };
                return profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProfileDTO GetProfileById(long id)
        {
            try
            {
                var p = _repo.GetProfileById(id);
                var profile = new ProfileDTO()
                {
                    Email = p.Email,
                    Address = p.Address,
                    FatherName = p.FatherName,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    Id = p.Id,
                    MobileNumber = p.MobileNumber,
                    NIC = p.NIC,
                    isDeleted = false,
                };
                return profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProfileDTO AddProfile(ProfileDTO p)
        {
            try
            {
                var us = new Profile()
                {
                    Email = p.Email,
                    Address = p.Address,
                    NIC = p.NIC,
                    MobileNumber = p.MobileNumber,
                    Id = p.Id,
                    FatherName = p.FatherName,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    isDeleted = false
                };
                var result = _repo.AddProfile(us);
                if (result.Id > 0)
                {
                    return GetProfileById(result.Id);
                }
                return null; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProfileDTO UpdateProfile(ProfileDTO p)
        {
            try
            {
                var us = new Profile()
                {
                    Email = p.Email,
                    Address = p.Address,
                    NIC = p.NIC,
                    MobileNumber = p.MobileNumber,
                    Id = p.Id,
                    FatherName = p.FatherName,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    isDeleted = false
                };
                var result = _repo.UpdateProfile(us);
                if (result.Id > 0)
                {
                    return GetProfileById(result.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteProfile(ProfileDTO p)
        {
            try
            {
                var us = new Profile()
                {
                    Email = p.Email,
                    Address = p.Address,
                    NIC = p.NIC,
                    MobileNumber = p.MobileNumber,
                    Id = p.Id,
                    FatherName = p.FatherName,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    isDeleted = true
                };
                var result = _repo.DeleteProfile(us);
                if (result )
                {
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
