using System.Runtime.Serialization;

namespace ServiceLibrary
{
    //DataContract and DataMember attributes are used for the sake of data serialization
    //KnownTypeAttribute allows to consider all derived types of the Student class
    [DataContract(Namespace ="www.Shrishesh.com/Year2022")]
    [KnownType(typeof(RegularStudent))]
    [KnownType(typeof(OpenStudent))]
    public class Student
    {
        // We can set other attributes like Name=, IsRequired etc.
        [DataMember(Order =1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public string Gender { get; set; }
        [DataMember(Order = 4)]
        public string City { get; set; }
        public StudentType Type { get; set; }
    }

    public enum StudentType
    {
        Regular=1, Open=2
    }
}
