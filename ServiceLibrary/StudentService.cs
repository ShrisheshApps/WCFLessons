using System;

namespace ServiceLibrary
{
    public class StudentService : IStudentService
    {
        public StudentResponse GetStudent(StudentRequest request)
        {
            StudentRequest req = new StudentRequest();
            req.Id = request.Id;
            StudentResponse r = new StudentResponse();
            Student s = new Student();
            s.Name = "Shrishesh";
            s.Gender = "Male";
            s.City = "Agra";
            r.student = s;
            return r;
        }
        
    }
}
