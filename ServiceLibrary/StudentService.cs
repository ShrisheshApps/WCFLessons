using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ServiceLibrary
{
    public class StudentService : IStudentService
    {
        public StudentResponse GetStudent(StudentRequest request)
        {
            Student student = null;
            string cs = ConfigurationManager.ConnectionStrings["CNX"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("spGetStudent", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter prmID = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = request.StudentId
                };
                command.Parameters.Add(prmID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //first read the StudentType
                    if ((StudentType)reader["StudentType"] == StudentType.Regular)
                    {
                        student = new RegularStudent()
                        {
                            Id = Convert.ToInt32(reader["StudentId"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            City = reader["City"].ToString(),
                            RegularFees = Convert.ToInt32(reader["RegularFees"]),
                            Type = StudentType.Regular
                            
                        };
                    }
                    if ((StudentType)reader["StudentType"] == StudentType.Open)
                    {
                        student = new OpenStudent()
                        {
                            Id = Convert.ToInt32(reader["StudentId"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            City = reader["City"].ToString(),
                            CourseHours = Convert.ToInt32(reader["CourseHours"]),
                            HourlyRate = Convert.ToInt32(reader["HourlyRate"]),
                            Type = StudentType.Open
                        };
                    }
                }
            }
            return new StudentResponse(student);
        }
    }
}
