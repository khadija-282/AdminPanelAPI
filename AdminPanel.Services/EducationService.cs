using AdminPanel.DataLayer;
using AdminPanel.DTO;
using AdminPanel.IRepository;
using AdminPanel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Services
{
    public class EducationService : IEducationService
    {
        private IEducationRepository repo; 
        public EducationService(IEducationRepository _repo)
        {
            repo = _repo;
        }
        public List<EducationDTO> AddEducation(EducationDTO e)
        {
            try
            {
                var ed = new Education()
                {
                    TotalMarks = e.TotalMarks,
                    School = e.School,
                    Percentage = e.Percentage,
                    DegreeTitle = e.DegreeTitle,
                    MarksObtained = e.MarksObtained,
                    PassingYear = e.PassingYear,
                    isActive = e.isActive,
                    isDeleted = false,
                    ProfileId = e.ProfileId
                };
                var isadded = repo.AddEducation(ed);
                if (isadded)
                {
                    return GetEducationByProfileId(e.ProfileId);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<EducationDTO> DeleteEducation(long educationId)
        {
            try
            {
                var isdeleted = repo.DeleteEducation(educationId);
                if (isdeleted)
                {
                    var profile = GetEducationById(educationId);
                    return GetEducationByProfileId(profile.ProfileId);
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

        public EducationDTO GetEducationById(long edId)
        {
            try
            {
                var isfound = repo.GetEducationById(edId);
                if (isfound.Id>0)
                {
                    var ed = new EducationDTO()
                    {
                        TotalMarks = isfound.TotalMarks,
                        School = isfound.School,
                        Percentage = isfound.Percentage,
                        DegreeTitle = isfound.DegreeTitle,
                        MarksObtained = isfound.MarksObtained,
                        PassingYear = isfound.PassingYear,
                        isActive = isfound.isActive,
                        isDeleted = isfound.isDeleted,
                        ProfileId = isfound.ProfileId,
                        Id=isfound.Id
                    };
                    return ed;
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

        public List<EducationDTO> GetEducationByProfileId(long profileID)
        {
            try
            {
                var listeducation = new List<EducationDTO>();
                var educations= repo.GetEducationByProfileId(profileID);
                foreach(var e in educations)
                {
                    var ed = new EducationDTO()
                    {
                        TotalMarks = e.TotalMarks,
                        School = e.School,
                        Percentage = e.Percentage,
                        DegreeTitle = e.DegreeTitle,
                        MarksObtained = e.MarksObtained,
                        PassingYear = e.PassingYear,
                        isActive = e.isActive,
                        isDeleted = e.isDeleted,
                        ProfileId = e.ProfileId,
                        Id=e.Id
                    };
                    listeducation.Add(ed);
                }
                return listeducation;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<EducationDTO> UpdateEducation(EducationDTO e)
        {
            try
            {
                var ed = new Education()
                {
                    TotalMarks = e.TotalMarks,
                    School = e.School,
                    Percentage = e.Percentage,
                    DegreeTitle = e.DegreeTitle,
                    MarksObtained = e.MarksObtained,
                    PassingYear = e.PassingYear,
                    isActive = e.isActive,
                    isDeleted = false,
                    ProfileId = e.ProfileId,
                    Id=e.Id
                };
                var updated = repo.UpdateEducation(ed);
                if (updated)
                {
                    return GetEducationByProfileId(e.ProfileId);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }
    }
}
