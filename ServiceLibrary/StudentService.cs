using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ServiceLibrary
{
    public class StudentService : IStudentInfo
    {
        Student student = null;
        public Student GetStudent(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["CNX"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("spGetStudent", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter prmId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                };
                
                command.Parameters.Add(prmId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student = new Student()
                    {
                        Id = Convert.ToInt32(reader["StudentId"]),
                        Name = reader["Name"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        City = reader["City"].ToString()
                    };
                }
            }
            return student;
        }

        public void SaveStudent(Student student)
        {
            string cs = ConfigurationManager.ConnectionStrings["CNX"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("spSaveStudent", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter prmName = new SqlParameter()
                {
                    ParameterName = "@StudentName",
                    Value = student.Name
                };
                command.Parameters.Add(prmName);
                SqlParameter prmGender = new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = student.Gender
                };
                command.Parameters.Add(prmGender);
                SqlParameter prmCity = new SqlParameter()
                {
                    ParameterName = "@City",
                    Value = student.City
                };
                command.Parameters.Add(prmCity);
                connection.Open();
                int result = command.ExecuteNonQuery();

            }
        }
    }
}
