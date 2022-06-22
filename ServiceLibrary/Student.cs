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
        [DataMember]
        public string Name { get; set; } 
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string City { get; set; } 
    }
}
