using AdminPanel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanelAPI.DTO
{
    public class UserRegisterationDTO
    {
        public UserDTO User { get; set; }
        public EmailDTO Email { get; set; }
        public ProfileDTO Profile { get; set; }
    }
}