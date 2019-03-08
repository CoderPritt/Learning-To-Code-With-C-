using System;
using System.Collections.Generic;

namespace StudentLogic
{
    public class Student
    {
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeLevel { get; set; }
        public List<double> Grades { get; set; }
    }
}
