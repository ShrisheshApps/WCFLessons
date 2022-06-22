using System.ServiceModel;

namespace ServiceLibrary
{
    /*
     * A messaging-style operation has at most one parameter and one return value where both types are message types
     */
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        StudentResponse GetStudent(StudentRequest request);
    }
}
