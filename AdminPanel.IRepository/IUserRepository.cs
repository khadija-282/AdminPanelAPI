using AdminPanel.DataLayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelAPI.Repository.Interface
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);

        User RegisterUser(User u);
        int UpdatePassword(User u);

    }
}
