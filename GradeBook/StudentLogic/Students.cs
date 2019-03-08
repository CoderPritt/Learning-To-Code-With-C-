using System;
using System.Collections.Generic;

namespace StudentLogic
{
    /// <summary>
    /// Class to house all Students in a list.
    /// </summary>
    public static class Students
    {
        public static List<Student> StudentsList { get; set; }

        static Students()
        {
            StudentsList = new List<Student>();
        }
    }
}
