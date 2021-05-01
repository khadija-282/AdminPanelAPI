using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.DTO
{
    public class ProfileDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string  Email { get; set; }
        public long?  MobileNumber { get; set; }
        public bool isDeleted { get; set; }
    }
}
