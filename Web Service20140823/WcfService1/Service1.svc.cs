using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
//using Microsoft.Phone.Data.Linq;
//using Microsoft.Phone.Data.Linq.Mapping;
using MySql.Data.MySqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    //public class Service1 : IService1
    //{
    //    public SqlConnection connectToDB() { 
    //    static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
    //    static MySqlConnection cn = new MySqlConnection(ConnectionString);
    //    MySqlCommand command = cn.CreateCommand();
    //    MySqlCommand command2 = cn.CreateCommand();
    //    return dbConn;
    //    }mysql://b6a420c297a691:3118a3a8@us-cdbr-azure-east-a.cloudapp.net/MyFYPDatabase
    //}
    public class Service1 : IService1
    {
        //static string ConnectionString = "@Data Source=us-cdbr-azure-east-a.cloudapp.net;Database=myfypdatabase;User Id=b6a420c297a691;Password=3118a3a8";
        //static string ConnectionString2 = "@Data Source=us-cdbr-azure-east-a.cloudapp.net;Database=myfypdatabase;User Id=b6a420c297a691;Password=3118a3a8";
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        //static string ConnectionString2 = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static string ConnectionString2 = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn7 = new MySqlConnection(ConnectionString2);
        static MySqlConnection cn8 = new MySqlConnection(ConnectionString);
        static MySqlConnection cn9 = new MySqlConnection(ConnectionString);
        
       
        static MySqlConnection cnUserType = new MySqlConnection(ConnectionString);
        MySqlCommand command = cn7.CreateCommand();
        MySqlCommand command2 = cnUserType.CreateCommand();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string GetString(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        //public string GetUserType(string username, string password)
        //{
        //    string UserType = "";
        //    command2.Parameters.Clear();
        //    command2.CommandText = "select UserType from userinfo where UserName=@UserName and Password=@Password";
        //    //command2.CommandText = "select * from attendance.userinfo where UserName='zhimeng1991@gmail.com'";
        //    command2.Parameters.AddWithValue("UserName", username);
        //    command2.Parameters.AddWithValue("Password", MD5Hash(password));
        //    cnUserType.Open();
        //    UserType = Convert.ToString(command2.ExecuteScalar());
        //    cnUserType.Close();

        //    return UserType;
        //}

        public int CheckLogin(string username, string password, string usertype)
        {
            
            command.CommandText = "select * from userinfo where UserName=@UserName and Password=@Password and UserType=@UserType";
            //command2.CommandText = "select * from attendance.userinfo where UserName='zhimeng1991@gmail.com'";
            command.Parameters.AddWithValue("UserName", username);
            command.Parameters.AddWithValue("Password", MD5Hash(password));
            command.Parameters.AddWithValue("UserType", usertype);
            cn7.Open();
            MySqlDataReader rd = command.ExecuteReader();
            //UserType = rd["UserType"].ToString();

            if (rd.HasRows && usertype == "Lecturer")
            {
                cn7.Close();
                    return 1;

            }
            else if (rd.HasRows && usertype == "Student")
            {
                cn7.Close();
                    return 2;

            }
            
            else
            {
                cn7.Close();
                return 3;
            }        
        }

//forget password
        public int ForgetPassword(string username, string usernumber)
        {
            string ErrorMessage="";
            bool hasEmailAddress, hasMatricNumber, hasStaffNumber;
            string emailaddress = "select UserName from userinfo where UserName=@UserName";
            string matricnumber = "select MatricNumber from student where MatricNumber=@MatricNumber";
            string StaffNumber = "select StaffNumber from staff where StaffNumber=@StaffNumber";

            MySqlCommand emailaddressCom = new MySqlCommand(emailaddress, cn7);
            MySqlCommand matricnumberCom = new MySqlCommand(matricnumber, cn7);
            MySqlCommand StaffNumberCom = new MySqlCommand(StaffNumber, cn7);

            emailaddressCom.Parameters.AddWithValue("@UserName", username);
            matricnumberCom.Parameters.AddWithValue("@MatricNumber", usernumber);
            StaffNumberCom.Parameters.AddWithValue("@StaffNumber", usernumber);
            cn7.Open();
            MySqlDataReader rd = emailaddressCom.ExecuteReader();
 
            hasEmailAddress = rd.HasRows;
            //Response.Write(rd2.HasRows);
            cn7.Close();

            cn7.Open();
            //MySqlDataReader rd = sqlcom.ExecuteReader();
            MySqlDataReader rd2 = matricnumberCom.ExecuteReader();
            hasMatricNumber = rd2.HasRows;
            cn7.Close();

            cn7.Open();
            //MySqlDataReader rd = sqlcom.ExecuteReader();
            MySqlDataReader rd3 = StaffNumberCom.ExecuteReader();
            hasStaffNumber = rd3.HasRows;
            cn7.Close();

            if ((hasMatricNumber == true && hasEmailAddress == true) || (hasStaffNumber == true && hasEmailAddress == true))
            {

                string password = RandomString(6);


                try
                {
                    MailMessage mMailMessage = new MailMessage();
                    // address of sender 
                    mMailMessage.From = new MailAddress("fypzhimeng@hotmail.com");
                    mMailMessage.To.Add(new MailAddress(username));
                    mMailMessage.Subject = "New Pasword for Your Account";
                    mMailMessage.Body = "Your new password is: " + password + ". Please change your own password.";
                    SmtpClient sc = new SmtpClient("smtp.live.com");
                    sc.Port = 587;
                    sc.Credentials = new NetworkCredential("fypzhimeng@hotmail.com", "zhimeng123");

                    sc.EnableSsl = true;
                    sc.Send(mMailMessage);
                    //ErrorMessage = "Sent Successful";

                    string changePassword = "UPDATE userinfo SET Password=@Password where UserName=@UserName;";
                    MySqlCommand changePasswordcom = new MySqlCommand(changePassword, cn7);
                    changePasswordcom.Parameters.AddWithValue("@Password", MD5Hash(password));
                    changePasswordcom.Parameters.AddWithValue("@UserName", username);
                    cn7.Open();
                    MySqlDataReader changePasswordR = changePasswordcom.ExecuteReader();
                    cn7.Close();
                    return 1;
                }

                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    return 2;
                }
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "checkResult()", true);

            }
            else //if (hasMatricNumber != true || hasEmailAddress != true)
            {
                ErrorMessage = "Your matric/stuff number and/or E-mail address have error.";
                return 2;
            }
        }
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

//Change Password
        public bool checkOldPassword(string oldpassword, string username)
        {
            string oldPassword = "", enterOldPassword = "";

            enterOldPassword = MD5Hash(oldpassword);

            string sqlAdminNumber = "select Password from userinfo where UserName=@UserName";
            MySqlCommand sqlAdminNumbercom = new MySqlCommand(sqlAdminNumber, cn7);
            sqlAdminNumbercom.Parameters.Add("@UserName", username);

            cn7.Open();
            oldPassword = sqlAdminNumbercom.ExecuteScalar().ToString();
            cn7.Close();
            if (oldPassword == enterOldPassword)
            {
                return true;
            }
            else
            {

                return false;
            }

        }

        public bool checkNewPasswordSame(string newpassword, string renewpassword)
        {
            if (newpassword == renewpassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int ChangePassword(string oldpassword, string newpassword, string renewpassword, string username)
        {
            if (checkOldPassword(oldpassword, username) == true)
            {
                if (checkNewPasswordSame(newpassword, renewpassword) == true)
                {
                    string changePassword = "update userinfo set Password=@Password where UserName=@UserName;";
                    MySqlCommand changePasswordcom = new MySqlCommand(changePassword, cn7);
                    changePasswordcom.Parameters.Add("@Password", MD5Hash(newpassword));
                    changePasswordcom.Parameters.Add("@UserName", username);
                    cn7.Open();
                    changePasswordcom.ExecuteNonQuery();
                    cn7.Close();
                    //message.Text = "Your password was changed successfully";
                    return 1;
                }
                else
                {
                    // password not matching
                    return 0;
                }
            }
            else
            {
                //wrong password
                return 2;
            }
        }

//get basic information of lecturer

        public string[] GetBasicInfoLec( string LecEmail)
        {
            string sqlstr = "SELECT FirstName,LastName,StaffNumber FROM staff WHERE EmailAddress=@EmailAddress ";
            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn7);
            sqlcom.Parameters.AddWithValue("@EmailAddress", LecEmail);


            cn7.Open();
            MySqlDataReader currentLoggedInUser = sqlcom.ExecuteReader();
            currentLoggedInUser.Read();
            string[] LecInfo = new string[2];
            LecInfo[0] = currentLoggedInUser.GetString(0) + " " + currentLoggedInUser.GetString(1);
            LecInfo[1] = currentLoggedInUser.GetString(2);

            cn7.Close();

            return LecInfo;
        
        }
//get basic information of student

        public string[] GetBasicInfoStu(string StuEmail)
        {
            string sqlstr = "SELECT FirstName,LastName,MatricNumber FROM student WHERE EmailAddress=@EmailAddress ";
            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn7);
            sqlcom.Parameters.AddWithValue("@EmailAddress", StuEmail);


            cn7.Open();
            MySqlDataReader currentLoggedInUser = sqlcom.ExecuteReader();
            currentLoggedInUser.Read();
            string[] StuInfo = new string[2];
            StuInfo[0] = currentLoggedInUser.GetString(0) + " " + currentLoggedInUser.GetString(1);
            StuInfo[1] = currentLoggedInUser.GetString(2);

            cn7.Close();

            return StuInfo;

        }      
//TEST Get bsic information 
        public List<string[]> GetBasicInformation()
        {
            string sql = "select * from student;";
            MySqlCommand sqlcom = new MySqlCommand(sql, cn7);
            cn7.Open();

            MySqlDataAdapter ada = new MySqlDataAdapter(sqlcom);
            System.Data.DataTable my = new System.Data.DataTable();


            ada.Fill(my);

            cn7.Close();
            //var query = (from FirstName in my select FirstName).ToList();

            List<string[]> lsdUserInfoDetails = new List<string[]>();
            string[] allUserList;

            foreach (DataRow dr in my.Rows)
            {
                allUserList = new string[2];
                allUserList[0] = dr["FirstName"].ToString();
                allUserList[1] = dr["LastName"].ToString();
               // allUserList[2] = dr["MatricNumber"].ToString();


                lsdUserInfoDetails.Add(allUserList);
            }


            return lsdUserInfoDetails;
        }
//Get student course list

        public List<string[]> GetStudentCourseList(string StuEmail)
        {
            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = cn7;
            dataCommand4.CommandText = "SELECT RIId, CourseCode, CourseName,TeachingYear,Semester from registerinformation join student join course where student.StudentId=registerinformation.StudentId and registerinformation.StudentId=@StudentId and registerinformation.CourseId=course.CourseId;";
            //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
            dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(StuEmail));

            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            cn7.Open();
            ada.Fill(my);
            
            cn7.Close();
            List<string[]> CourseList = new List<string[]>();
            string[] allCourseList;

            foreach (DataRow dr in my.Rows)
            {
                allCourseList = new string[5];
                allCourseList[0] = dr["RIId"].ToString();
                allCourseList[1] = dr["CourseCode"].ToString();
                allCourseList[2] = dr["CourseName"].ToString();
                allCourseList[3] = dr["TeachingYear"].ToString();
                allCourseList[4] = dr["Semester"].ToString();
                // allUserList[2] = dr["MatricNumber"].ToString();


                CourseList.Add(allCourseList);
            }


            return CourseList;
        
        
        }

        public string GetStudentId(string userName)
        {
            string EmailAddress = "";
            string SelectStudentId = "select StudentId from student where EmailAddress=@EmailAddress;";
            MySqlConnection GetStudentIdCon = new MySqlConnection(ConnectionString);
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, GetStudentIdCon);
            try
            {
                GetStudentIdCon.Open();
                dataCommand1.Parameters.AddWithValue("@EmailAddress", userName);
                EmailAddress = Convert.ToString(dataCommand1.ExecuteScalar());
                GetStudentIdCon.Close();

                //Massege.Text = EmailAddress;
                return EmailAddress;
            }
            catch
            {
                EmailAddress = "";
                return EmailAddress;
            }
        }

//Get student class list
        public List<string[]> GetStudentClassList(string StuEmail, string Semester, string TeachingYear, string CourseCode)
        {

            MySqlCommand dataCommand4 = new MySqlCommand();
            MySqlConnection cn8 = new MySqlConnection(ConnectionString);
            dataCommand4.Connection = cn8;
            dataCommand4.CommandText = "select StudentAttendanceId, ClassDate, AttendanceStatus,StartTime,EndTime from studentattendance join student join classinfo where studentattendance.StudentId=student.StudentId and studentattendance.StudentId=@StudentId and studentattendance.ClassId=classinfo.ClassId and classinfo.CourseCode=@CourseCode and classinfo.TeachingYear=@TeachingYear and classinfo.Semester=@Semester;";         
            dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(StuEmail));
            dataCommand4.Parameters.AddWithValue("@Semester", Semester);
            dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear);
            dataCommand4.Parameters.AddWithValue("@CourseCode", CourseCode);

            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            cn8.Open();
            ada.Fill(my);            
            cn8.Close();

            List<string[]> ClassList = new List<string[]>();
            string[] allClassList;

            foreach (DataRow dr in my.Rows)
            {
                allClassList = new string[5];
                allClassList[0] = dr["StudentAttendanceId"].ToString();
                allClassList[1] = Convert.ToDateTime(dr["ClassDate"].ToString()).ToString("yyyy/MM/dd");
                allClassList[2] = dr["AttendanceStatus"].ToString();
                allClassList[3] = dr["StartTime"].ToString();
                allClassList[4] = dr["EndTime"].ToString();                
                ClassList.Add(allClassList);
            }
            return ClassList;
        }
        
//Get student movement
        public List<string[]> GetStudentMovement(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate)
        {
            MySqlConnection StuCon = new MySqlConnection(ConnectionString);
            MySqlCommand dataCommand4 = new MySqlCommand();
            MySqlConnection cn9 = new MySqlConnection(ConnectionString);
            dataCommand4.Connection = StuCon;
            dataCommand4.CommandText = "select MovementId, MovementStatus, TimeRecord from movement join student join classinfo where movement.StudentId=student.StudentId and movement.StudentId=@StudentId and movement.ClassId=@ClassId group by MovementId;";
            dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(StuEmail));
            dataCommand4.Parameters.AddWithValue("@ClassId", GetClassId(Semester,TeachingYear,CourseCode,ClassDate));


            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            StuCon.Open();
            ada.Fill(my);          
            StuCon.Close();

            List<string[]> MovementList = new List<string[]>();
            string[] allMovementList;

            foreach (DataRow dr in my.Rows)
            {
                allMovementList = new string[2];
                allMovementList[0] = dr["MovementStatus"].ToString();
                allMovementList[1] = dr["TimeRecord"].ToString();                               
                MovementList.Add(allMovementList);
            }
            return MovementList;
        }

        public string GetClassId(string Semester, string TeachingYear, string CourseCode, string ClassDate)
        {
            string SelectStudentId = "select ClassId from classinfo where TeachingYear=@TeachingYear and Semester=@Semester and CourseCode=@CourseCode and ClassDate=@ClassDate;";
            string ClassId = "";
            MySqlConnection GetClassIdCon = new MySqlConnection(ConnectionString);
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, GetClassIdCon);



            GetClassIdCon.Open();
            dataCommand1.Parameters.AddWithValue("@TeachingYear", TeachingYear);
            dataCommand1.Parameters.AddWithValue("@Semester", Semester);
            dataCommand1.Parameters.AddWithValue("@CourseCode", CourseCode);
            dataCommand1.Parameters.AddWithValue("@ClassDate", ClassDate);

            ClassId = Convert.ToString(dataCommand1.ExecuteScalar());
            GetClassIdCon.Close();

            return ClassId;

        }
//Get student summary of one class
        public string GetSummary(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate)
        {
            string SelectStudentId = "select StayInClassTime from studentattendance where StudentId=@StudentId and ClassId=@ClassId;";
            string summary = "";
            MySqlConnection GetSumCon = new MySqlConnection(ConnectionString);
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, GetSumCon);

            GetSumCon.Open();
            dataCommand1.Parameters.AddWithValue("@StudentId", GetStudentId(StuEmail));
            dataCommand1.Parameters.AddWithValue("@ClassId", GetClassId(Semester, TeachingYear, CourseCode, ClassDate));
            summary = "Time of you staying in classroom: " + Convert.ToString(dataCommand1.ExecuteScalar());
            GetSumCon.Close();
            return summary;
        }


//Get lecturer course list
        public List<string[]> GetLecCourseList(string LecEmail)
        {
            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = cn7;
            dataCommand4.CommandText = "SELECT SRId, CourseCode, CourseName,TeachingYear,Semester from staffregisterinformation join staff join course where staff.StaffId=staffregisterinformation.StaffId and staffregisterinformation.StaffId=@StaffId and staffregisterinformation.CourseId=course.CourseId;";
            //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
            dataCommand4.Parameters.AddWithValue("@StaffId", GetStaffId(LecEmail));

            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            cn7.Open();
            ada.Fill(my);
            
            cn7.Close();

            List<string[]> CourseList = new List<string[]>();
            string[] allCourseList;

            foreach (DataRow dr in my.Rows)
            {
                allCourseList = new string[5];
                allCourseList[0] = dr["SRId"].ToString();
                allCourseList[1] = dr["CourseCode"].ToString();
                allCourseList[2] = dr["CourseName"].ToString();
                allCourseList[3] = dr["TeachingYear"].ToString();
                allCourseList[4] = dr["Semester"].ToString();
                // allUserList[2] = dr["MatricNumber"].ToString();


                CourseList.Add(allCourseList);
            }


            return CourseList;


        }
        public string GetStaffId(string userName)
        {
            string EmailAddress = "";
            string SelectStaffId = "select StaffId from staff where EmailAddress=@EmailAddress;";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStaffId, cn8);
            try
            {
                cn8.Open();
                dataCommand1.Parameters.AddWithValue("@EmailAddress", userName);
                EmailAddress = Convert.ToString(dataCommand1.ExecuteScalar());
                cn8.Close();

                //Massege.Text = EmailAddress;
                return EmailAddress;
            }
            catch
            {
                EmailAddress = "";
                return EmailAddress;
            }
        }
//Get lecturer class list
        public List<string[]> GetLecturerClassList(string Semester, string TeachingYear, string CourseCode)
        {

            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = cn7;
            dataCommand4.CommandText = "SELECT ClassId, BuildingNumber, RoomNumber,ClassDate,StartTime,EndTime from classinfo where Semester=@Semester and TeachingYear=@TeachingYear and CourseCode=@CourseCode ;";
            //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
            dataCommand4.Parameters.AddWithValue("@Semester", Semester);
            dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear);
            dataCommand4.Parameters.AddWithValue("@CourseCode", CourseCode);


            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            cn7.Open();
            ada.Fill(my);           
            cn7.Close();

            List<string[]> ClassList = new List<string[]>();
            string[] allClassList;

            foreach (DataRow dr in my.Rows)
            {
                allClassList = new string[6];
                allClassList[0] = dr["ClassId"].ToString();
                allClassList[1] = dr["BuildingNumber"].ToString();
                allClassList[2] = dr["RoomNumber"].ToString();
                allClassList[3] = Convert.ToDateTime(dr["ClassDate"].ToString()).ToString("yyyy/MM/dd");               
                allClassList[4] = dr["StartTime"].ToString();
                allClassList[5] = dr["EndTime"].ToString();
                
                ClassList.Add(allClassList);
            }
            return ClassList;
        }

//Get student attendance list for one class
        public List<string[]> GetLecStudentAttendance(string teachingYear, string semester, string courseCode, string classDate)
        {
            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = cn8;
            dataCommand4.CommandText = "select StudentAttendanceId, FirstName, LastName, MatricNumber, EmailAddress, AttendanceStatus, classinfo.ClassId from studentattendance join student join classinfo where studentattendance.StudentId=student.StudentId and classinfo.ClassId= studentattendance.ClassId and studentattendance.ClassId=@ClassId;";
            //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
            dataCommand4.Parameters.AddWithValue("@ClassId", GetClassId(semester, teachingYear,courseCode, classDate));


            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            cn8.Open();
            ada.Fill(my);
            cn8.Close();

            List<string[]> StudentList = new List<string[]>();
            string[] allStudentList;

            foreach (DataRow dr in my.Rows)
            {
                allStudentList = new string[4];
                allStudentList[0] = dr["FirstName"].ToString();
                allStudentList[1] = dr["LastName"].ToString();
                allStudentList[2] = dr["MatricNumber"].ToString();
                allStudentList[3] = dr["AttendanceStatus"].ToString();


                StudentList.Add(allStudentList);
            }
            return StudentList;
        
        }
        

//lecturer get one student movement 
        public List<string[]> LecGetStudentMovement(string MatricNumber, string Semester, string TeachingYear, string CourseCode, string ClassDate)
        {
            
            MySqlConnection LecCon = new MySqlConnection(ConnectionString);
            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = LecCon;
            dataCommand4.CommandText = "select MovementId, MovementStatus, TimeRecord from attendance.movement join student join classinfo where attendance.movement.StudentId=student.StudentId and attendance.movement.StudentId=@StudentId and attendance.movement.ClassId=@ClassId group by MovementId;";
            //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
            dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentIdM(MatricNumber));
            dataCommand4.Parameters.AddWithValue("@ClassId", GetClassId(Semester, TeachingYear, CourseCode, ClassDate));

            //Response.Write(GetStudentId(Session["MatricNumber"].ToString()) + " " + GetClassId());

            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            LecCon.Open();
            ada.Fill(my);
            LecCon.Close();

            List<string[]> MovementList = new List<string[]>();
            string[] allMovementList;

            foreach (DataRow dr in my.Rows)
            {
                allMovementList = new string[2];
                allMovementList[0] = dr["MovementStatus"].ToString();
                allMovementList[1] = dr["TimeRecord"].ToString();
                MovementList.Add(allMovementList);
            }
            return MovementList;
        }
        public string GetStudentIdM(string matricNumber)
        {
            string SelectStudentId = "select StudentId from student where MatricNumber=@MatricNumber;";
            string studentId = "";
            MySqlConnection GetStuIdCon = new MySqlConnection(ConnectionString);
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, GetStuIdCon);



            GetStuIdCon.Open();
            dataCommand1.Parameters.AddWithValue("@MatricNumber", matricNumber);

            studentId = Convert.ToString(dataCommand1.ExecuteScalar());
            GetStuIdCon.Close();

            return studentId;

        }
//Get Lec check student movement summary
        public string GetSummary2(string MatricNumber, string Semester, string TeachingYear, string CourseCode, string ClassDate)
        {
            string SelectStudentId = "select StayInClassTime from studentattendance where StudentId=@StudentId and ClassId=@ClassId;";
            string summary = "";
            MySqlConnection cn11 = new MySqlConnection(ConnectionString);
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn11);

            cn11.Open();
            dataCommand1.Parameters.AddWithValue("@StudentId", GetStudentIdM(MatricNumber));
            dataCommand1.Parameters.AddWithValue("@ClassId", GetClassId(Semester, TeachingYear, CourseCode, ClassDate));
            summary = "Time of this student staying in classroom: " + Convert.ToString(dataCommand1.ExecuteScalar());
            cn11.Close();
            return summary;
        }
//lecturer get class statistic of one class
        public string[] GetClassStatisticInfo(string Semester, string TeachingYear, string CourseCode, string ClassDate)
        {
            int[] NumberOfStu = new int[4];
            string[] Persentage = new string[3];
            string[] summary = new string[7];
            string Summarysql = "select StudentNumber,AttendanceNumber,IncompleteNumber,AbsentNumber from classinfo WHERE ClassId=@ClassId";
            MySqlCommand SummarysqlCommand = new MySqlCommand(Summarysql, cn7);
            cn7.Open();
            SummarysqlCommand.Parameters.AddWithValue("@ClassId", GetClassId(Semester, TeachingYear, CourseCode, ClassDate));
            MySqlDataReader summaryinfo = SummarysqlCommand.ExecuteReader();

            summaryinfo.Read();
            NumberOfStu[0] = Convert.ToInt16(summaryinfo[0]);

            summaryinfo.Read();
            NumberOfStu[1] = Convert.ToInt16(summaryinfo[1]);

            summaryinfo.Read();
            NumberOfStu[2] = Convert.ToInt16(summaryinfo[2]);

            summaryinfo.Read();
            NumberOfStu[3] = Convert.ToInt16(summaryinfo[3]);

            cn7.Close();
        
            Persentage[0]=((double)NumberOfStu[1] / NumberOfStu[0]).ToString("0.0%");
            Persentage[1]=((double)NumberOfStu[2] / NumberOfStu[0]).ToString("0.0%");
            Persentage[2]=((double)NumberOfStu[3] / NumberOfStu[0]).ToString("0.0%");

            summary[0]=NumberOfStu[0].ToString();
            summary[1]=NumberOfStu[1].ToString();
            summary[2]=NumberOfStu[2].ToString();
            summary[3]=NumberOfStu[3].ToString();
            summary[4]=Persentage[0];
            summary[5]=Persentage[1];
            summary[6] = Persentage[2];
        return summary;
        }
        public string GreetingMessage(string name)
        {
            return "Welcome to Metro Word " + name;
        }

    }

}
