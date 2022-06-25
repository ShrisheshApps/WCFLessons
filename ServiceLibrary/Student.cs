using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServiceLibrary
{
    [MessageContract(IsWrapped =true)]
    public class StudentRequest
    {
        [MessageHeader] 
        public int Id { get; set; } 
    }

    [MessageContract(IsWrapped = true)]
    public class StudentResponse
    {
        public StudentResponse()
        {

        }
        public StudentResponse(Student student)
        {
            this.Name = student.Name;
            this.Gender = student.Gender;
            this.City = student.City;
        }
        [MessageBodyMember(Order = 1)]
        public string Name { get; set; }
        [MessageBodyMember(Order = 2)]
        public string Gender { get; set; }
        [MessageBodyMember(Order = 3)]
        public string City { get; set; }
    }
    [DataContract]
    public class Student
    {
        [DataMember(Order =1)]
        public string Name { get; set; } 
        [DataMember(Order = 2)]
        public string Gender { get; set; }
        [DataMember(Order = 3)]
        public string City { get; set; } 
    }
}
