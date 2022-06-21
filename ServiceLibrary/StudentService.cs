using System;
using System.Configuration;
using System.Data.SqlClient;
using System.ServiceModel;

namespace ServiceLibrary
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
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
                    if ((StudentType)reader["StudentType"] == StudentType.Regular)
                    {
                        student = new RegularStudent()
                        {
                            //Id = Convert.ToInt32(reader["StudentId"]),
                            Id = id,
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            City = reader["City"].ToString(),
                            TotalFees = Convert.ToInt32(reader["RegularFees"])
                        };
                    }
                    if ((StudentType)reader["StudentType"] == StudentType.Open)
                    {
                        student = new OpenStudent()
                        {
                            //Id = Convert.ToInt32(reader["StudentId"]),
                            Id = id,
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            City = reader["City"].ToString(),
                            HourlyRate = Convert.ToInt32(reader["HourlyRate"]),
                            Hours = Convert.ToInt32(reader["CourseHours"])
                        };
                    }
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

                if (student.GetType() == typeof(RegularStudent))
                {
                    SqlParameter prmRegularFee = new SqlParameter()
                    {
                        ParameterName = "@RegularFees",
                        Value = ((RegularStudent)student).TotalFees
                    };
                    command.Parameters.Add(prmRegularFee);

                    SqlParameter prmStudentType = new SqlParameter()
                    {
                        ParameterName = "@StudentType",
                        Value = ((RegularStudent)student).Type
                    };
                    command.Parameters.Add(prmStudentType);
                }

                if (student.GetType() == typeof(OpenStudent))
                {
                    SqlParameter prmHourlyRate = new SqlParameter()
                    {
                        ParameterName = "@HourlyRate",
                        Value = ((OpenStudent)student).HourlyRate
                    };
                    command.Parameters.Add(prmHourlyRate);
                    SqlParameter prmHours = new SqlParameter()
                    {
                        ParameterName = "@CourseHours",
                        Value = ((OpenStudent)student).Hours
                    };
                    command.Parameters.Add(prmHours);
                    SqlParameter prmStudentType = new SqlParameter()
                    {
                        ParameterName = "@StudentType",
                        Value = ((OpenStudent)student).Type
                    };
                    command.Parameters.Add(prmStudentType);

                }
                connection.Open();
                int result = command.ExecuteNonQuery();

            }
        }
    }
}

/*
 * 
ALTER PROCEDURE [dbo].[spSaveStudent]
@StudentName nvarchar(50),
@Gender nvarchar(50),
@City nvarchar(50),
@RegularFees int = null,
@CourseHours int = null,
@HourlyRate int = null,
@StudentType int
AS
BEGIN
	INSERT INTO tblStudent VALUES(@StudentName, @Gender, @City,@RegularFees, @CourseHours, @HourlyRate, @StudentType)
END
 * */

/*
 * 
ALTER PROCEDURE [dbo].[spGetStudent]
@Id int
AS
BEGIN
	SELECT StudentId, Name, Gender, City, RegularFees, CourseHours, HourlyRate, StudentType FROM tblStudent WHERE StudentId = @Id
END
* */