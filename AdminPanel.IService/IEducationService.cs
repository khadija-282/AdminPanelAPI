using AdminPanel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.IService
{
    public interface IEducationService
    {
        List<EducationDTO> GetEducationByProfileId(long profileID);
        EducationDTO GetEducationById(long edId);
        List<EducationDTO> AddEducation(EducationDTO e);
        List<EducationDTO> UpdateEducation(EducationDTO e);
        List<EducationDTO> DeleteEducation(long educationId);
    }
}
