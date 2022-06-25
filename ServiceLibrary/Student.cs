using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServiceLibrary
{
    [MessageContract]
    public class StudentRequest
    {
        [MessageHeader] 
        public int Id { get; set; } 
    }

    [MessageContract] 
    public class StudentResponse
    {
        [MessageBodyMember]
        public Student student { get; set; }
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
