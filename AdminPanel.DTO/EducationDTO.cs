using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.DTO
{
   public  class EducationDTO
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public string DegreeTitle { get; set; }
        public string School { get; set; }
        public string PassingYear { get; set; }
        public int? TotalMarks { get; set; }
        public int? MarksObtained { get; set; }
        public int? Percentage { get; set; }
        public bool? isActive { get; set; }
        public bool? isDeleted { get; set; }
    }
}
