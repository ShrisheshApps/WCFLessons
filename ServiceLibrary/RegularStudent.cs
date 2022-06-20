using System.Runtime.Serialization;
namespace ServiceLibrary
{
    [DataContract]
    class RegularStudent: Student
    {   [DataMember]
        public int TotalFees { get; set; }
    }
}
