using AdminPanelAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelAPI.Service.Interface
{
    public interface IUserService
    {
        bool RegisterUser(UserDTO u,EmailDTO e);
        UserDTO GetUser(string username, string password);
        UserDTO UpdatePassword(UserDTO u);
    }
}
