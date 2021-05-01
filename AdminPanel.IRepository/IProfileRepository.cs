using AdminPanel.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.IRepository
{
    public interface IProfileRepository
    {
        Profile GetProfileByEmail(string email);
        Profile GetProfileById(long id);
        Profile AddProfile(Profile u);
        Profile UpdateProfile(Profile u);
        bool DeleteProfile(Profile u);

    }
}
