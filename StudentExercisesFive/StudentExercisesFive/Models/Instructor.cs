using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercisesFive.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Slack_Handle { get; set; }
        public string Specialty { get; set; }
        public int Cohort_Id { get; set; }

    }
}
