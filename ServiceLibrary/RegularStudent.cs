using System.Runtime.Serialization;
namespace ServiceLibrary
{
    [DataContract]
    public class RegularStudent: Student
    {   [DataMember]
        public int TotalFees { get; set; }
    }
}
