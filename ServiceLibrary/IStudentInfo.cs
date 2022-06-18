using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
