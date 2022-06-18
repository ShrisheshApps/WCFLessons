using System;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ServiceLibrary
{
    public class StudentService : IStudentInfo
    {
        public Student GetStudent(int id)
        {
            Student student = null;
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
            throw new NotImplementedException();
        }
    }
}
