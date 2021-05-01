using AdminPanel.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.IRepository
{
    public interface IEducationRepository
    {
        List<Education> GetEducationByProfileId(long profileID);
        Education GetEducationById(long edId);
        bool AddEducation (Education e);
        bool UpdateEducation(Education e);
        bool DeleteEducation(long educationId);

    }
}
