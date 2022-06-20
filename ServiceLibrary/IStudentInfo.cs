using System.ServiceModel;

namespace ServiceLibrary
{
    
    [ServiceContract]
    public interface IStudentInfo
    {
        [OperationContract]
        Student GetStudent(int id);
        [OperationContract]
        void SaveStudent(Student student);
    }
}
