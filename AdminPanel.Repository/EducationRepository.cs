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
    public class EducationRepository : IEducationRepository
    {
        private readonly AdminPanelEntities _context = new AdminPanelEntities();
        public bool AddEducation(Education e)
        {
            try
            {
                var added = _context.Educations.Add(e);
                _context.Entry(added).State = EntityState.Added;
                _context.SaveChanges();
                if (added.Id > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }

        public bool DeleteEducation(long educationId)
        {
            try
            {
                var foundeducation = GetEducationById(educationId);
                if (foundeducation!=null && foundeducation.Id>0)
                {
                    foundeducation.isDeleted = true;
                    _context.Entry(foundeducation).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Education GetEducationById(long edId)
        {
            try
            {
                return _context.Educations.Where(x => x.Id == edId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public List<Education> GetEducationByProfileId(long profileID)
        {
            try
            {
                return _context.Educations.Where(x => x.ProfileId == profileID && x.isDeleted==false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateEducation(Education e)
        {
            try
            {
                var exists = GetEducationById(e.Id);
                if (exists !=null && exists.Id > 0)
                {
                    exists.MarksObtained = e.MarksObtained;
                    exists.PassingYear= e.PassingYear;
                    exists.Percentage = e.Percentage;
                    exists.School = e.School;
                    exists.TotalMarks= e.TotalMarks;
                    exists.isActive = e.isActive;
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
