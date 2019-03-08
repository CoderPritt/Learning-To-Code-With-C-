using System;
namespace StudentLogic
{
    public class StudentGenerator
    {
        public Student Generate(string first, string last, int grade)
        {
            string id = new IdGenerator().GenerateID();

            Student s = new Student
            {
                StudentID = id,
                FirstName = first,
                LastName = last,
                GradeLevel = grade
            };

            return s;
        }
    }
}