using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercisesFive.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Slack_Handle { get; set; }
        public int Cohort_Id { get; set; }
        public int Exercise_Id { get; set; }
    }
}
