using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string GetString(string value);

      

        [OperationContract]
        int CheckLogin(string username, string password, string usertype);

        [OperationContract]
        int ForgetPassword(string username, string usernumber);

        [OperationContract]
        int ChangePassword(string oldpassword, string newpassword, string renewpassword, string username);
        //[OperationContract]
        //string GetBasicInformation();

        [OperationContract]
        List<string[]> GetBasicInformation();
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        string[] GetBasicInfoLec(string LecEmail);

        [OperationContract]
        string[] GetBasicInfoStu(string StuEmail);

        [OperationContract]
        List<string[]> GetStudentCourseList(string StuEmail);

        [OperationContract]
        List<string[]> GetStudentClassList(string StuEmail, string Semester, string TeachingYear, string CourseCode);

        [OperationContract]
        List<string[]> GetStudentMovement(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate);

        [OperationContract]
        string GetSummary(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate);

        [OperationContract]
        List<string[]> GetLecCourseList(string LecEmail);

        [OperationContract]
        List<string[]> GetLecturerClassList(string Semester, string TeachingYear, string CourseCode);

        [OperationContract]
        List<string[]> GetLecStudentAttendance(string teachingYear, string semester, string courseCode, string classDate);

        [OperationContract]
        string[] GetClassStatisticInfo(string Semester, string TeachingYear, string CourseCode, string ClassDate);

        [OperationContract]
        List<string[]> LecGetStudentMovement(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate);

        [OperationContract]
        string GetSummary2(string MatricNumber, string Semester, string TeachingYear, string CourseCode, string ClassDate);

        [OperationContract]
        string GreetingMessage(string name);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]//Makes the class available
    public class Suppliers //creates the objectet Suppliers, and defines its attributtes (properties).
    {

        int _ID;

        string _name;
        string _country;

        [DataMember]//makes the property available
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [DataMember]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
    }

}
