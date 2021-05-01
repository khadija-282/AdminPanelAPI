using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanelAPI.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isActive { get; set; }
        public bool isVerified { get; set; }
        public bool isDeleted { get; set; }
    }
}