using StudentExercisesFive.Models;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace StudentExercisesFive.Data
{
    public class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Exercise> GetAllExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int exerciseNameColumnPosition = reader.GetOrdinal("Exercise_Name");

                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                        int languageColumnPosition = reader.GetOrdinal("Language");

                        string languageValue = reader.GetString(languageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Exercise_Name = exerciseNameValue,
                            Language = languageValue
                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        public List<Exercise> GetAllExercisesByLanguage(string Language)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT e.Id, e.Exercise_Name
                                          FROM Exercise e
                                         WHERE e.Language = @Language";
                    cmd.Parameters.Add(new SqlParameter("@Language", Language));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();
                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Exercise_Name = reader.GetString(reader.GetOrdinal("Exercise_Name"))
                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Exercise (Exercise_Name, Language) Values (@Exercise_Name, @Language)";
                    cmd.Parameters.Add(new SqlParameter("@Exercise_Name", exercise.Exercise_Name));
                    cmd.Parameters.Add(new SqlParameter("@Language", exercise.Language));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Instructor> GetAllInstructorsWithCohort()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT i.Id, i.First_Name, i.Last_Name, i.Slack_Handle, i.Cohort_id, c.Cohort_Name 
                                        FROM Instructor i INNER JOIN Cohort c ON i.Cohort_Id = c.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();
                    while (reader.Read())
                    {
                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Cohort_Name = reader.GetString(reader.GetOrdinal("Cohort_Name"))
                        };

                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            First_Name = reader.GetString(reader.GetOrdinal("First_Name")),
                            Last_Name = reader.GetString(reader.GetOrdinal("Last_Name")),
                            Slack_Handle = reader.GetString(reader.GetOrdinal("Slack_Handle")),
                            Cohort_Id = reader.GetInt32(reader.GetOrdinal("Cohort_Id"))
                        };

                        instructors.Add(instructor);
                    }

                    reader.Close();

                    return instructors;
                }
            }
        }
    }
}
