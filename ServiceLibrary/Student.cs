using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServiceLibrary
{
    [MessageContract(IsWrapped = true)]
    public class StudentRequest
    {
        [MessageHeader]
        public string StudentKey { get; set; }
        [MessageBodyMember]
        public int StudentId { get; set; }
    }

    [MessageContract(IsWrapped = true)]
    public class StudentResponse
    {
        public StudentResponse()
        {

        }
        public StudentResponse(Student student)
        {
            this.Id = student.Id;
            this.Name = student.Name;
            this.Gender = student.Gender;
            this.City = student.City;
            if (student.Type == StudentType.Regular)
            {
                this.RegularFees = ((RegularStudent)student).RegularFees;
                this.Type = StudentType.Regular;
            }
            if (student.Type == StudentType.Open)
            {
                this.CourseHours = ((OpenStudent)student).CourseHours;
                this.HourlyRate = ((OpenStudent)student).HourlyRate;
                this.Type = StudentType.Open;
            }
        }
        [MessageBodyMember(Order = 1)]
        public int Id { get; set; }
        [MessageBodyMember(Order = 2)]
        public string Name { get; set; }
        [MessageBodyMember(Order = 3)]
        public string Gender { get; set; }
        [MessageBodyMember(Order = 4)]
        public string City { get; set; }
        [MessageBodyMember(Order = 5)]
        public StudentType Type { get; set; }
        [MessageBodyMember(Order = 6)]
        public int RegularFees { get; set; }
        [MessageBodyMember(Order = 7)]
        public int CourseHours { get; set; }
        [MessageBodyMember(Order = 8)]
        public int HourlyRate { get; set; }
    }
    [DataContract]
    [KnownType(typeof(RegularStudent)) ]
    [KnownType(typeof(OpenStudent)) ]
    public class Student
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public string Gender { get; set; }
        [DataMember(Order = 4)]
        public string City { get; set; }
        [DataMember(Order = 5)]
        public StudentType Type { get; set; }
    }
    [DataContract]
    public enum StudentType
    {
        [EnumMember]
        Regular=1, 
        [EnumMember]
        Open=2
    }
}
