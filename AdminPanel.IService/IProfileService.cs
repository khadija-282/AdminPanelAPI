using AdminPanel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelAPI.Service.Interface
{
   public  interface IProfileService
    {
        ProfileDTO GetProfileByEmail(string email);
        ProfileDTO GetProfileById(long id);
        ProfileDTO AddProfile(ProfileDTO p);
        ProfileDTO UpdateProfile(ProfileDTO p);
        bool DeleteProfile(ProfileDTO p);

    }

}
