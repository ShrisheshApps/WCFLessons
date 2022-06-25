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
            r.Name = "Shrishesh";
            r.Gender = "Male";
            r.City = "Agra";
            return r;
        }
        
    }
}
