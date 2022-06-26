using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class OpenStudent : Student
    {
        public int HourlyRate { get; set; }
        public int CourseHours { get; set; }
    }
}
