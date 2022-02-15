using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    internal class EnrolledStudent
    {
        public int StudentId { get; set; }
        public int StudentAge { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }

        public EnrolledStudent(Student s, Course c)
        {
            StudentId = s.Id;
            StudentAge = s.Age;
            StudentName = s.Name;
            CourseName = c.Name;
            Credits = c.Credits;
        }
    }
}
