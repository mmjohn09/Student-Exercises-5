using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercisesFive.Models
{
    public class Cohort
    {
        public int Id { get; set; }
        public string Cohort_Name { get; set; }

        public List<Student> StudentList = new List<Student>();

        public List<Instructor> InstructorList = new List<Instructor>();
    }
}
