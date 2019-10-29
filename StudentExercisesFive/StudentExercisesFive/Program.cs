using System;
using StudentExercisesFive.Data;
using System.Collections.Generic;
using StudentExercisesFive.Models;

namespace StudentExercisesFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            List<Exercise> exercises = repository.GetAllExercises();

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"{exercise.Exercise_Name}");
            }

            exercises = repository.GetAllExercisesByLanguage("Javascript");

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"{exercise.Exercise_Name}");
            }

            Exercise newExercise = new Exercise { Exercise_Name = "Welcome to Nashville", Language = "Javascript" };
        
            repository.AddExercise(newExercise);
        }
    }
}
