using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_New
{
    public partial class Form1 : Form
    {
        SerialPort port2 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
        string hex = "", value = "";
        DateTime t1, t2, t3, t4;
        int getDecNumber = 0;
        string FinalCardID="", RealCardID="";

        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123";
        MySqlConnection cn = new MySqlConnection(ConnectionString);
        MySqlConnection cn2 = new MySqlConnection(ConnectionString);

        public Form1()
        {
            InitializeComponent();
            fillTeachingYear();
            port2.Encoding = System.Text.Encoding.GetEncoding("windows-1252");
            SerialPortProgram();
        }
        private void SerialPortProgram()
        {
            Console.WriteLine("Incoming Data:");
            port2.Open();
            port2.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        public void SendSampleData()
        {
            Byte[] Bytes = { 0x0F, 0xA2, 0x52, 0x09, 0x01, 0x01, 0x60, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x69, 0x03 };
            Byte[] Bytes2 = { 0x0F, 0x42, 0x52, 0x09, 0x02, 0x01, 0x60, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x8A, 0x03 };
            port2.Write(Bytes, 0, 15);
            Thread.Sleep(100);
            port2.Write(Bytes2, 0, 15);
        }

        public bool CheckFakeCard(string EPC)
        {
            string selectCardId = "select CardID from student where EPC=@EPC;";
            MySqlCommand selectCardIdCommand = new MySqlCommand(selectCardId, cn);

            cn.Open();
            selectCardIdCommand.Parameters.AddWithValue("@EPC", EPC);
            //MySqlDataReader objDataReader = selectCardIdCommand.ExecuteReader();
            //objDataReader.Read();
            RealCardID = Convert.ToString(selectCardIdCommand.ExecuteScalar());
            cn.Close();

            if (RealCardID == FinalCardID)
            {
                Console.WriteLine(RealCardID + " " + FinalCardID);
                return true;
            }
            else
            {
                Console.WriteLine(RealCardID + " # " + FinalCardID);
                return false;
            }
        }
        
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            value += port2.ReadExisting();
        }

        public void getData()
        {
            string getHexNumber = "";
            foreach (char c in value)
            {
                hex = hex + String.Format("{0:x2}", (byte)c);

            }

            char[] final = hex.ToCharArray();

            if (final.Length != 0 && hex.Length == 88)
                //&& hex.Length == 44
            //if (true)
            {
                for (int i = 33; i < 40; i++)
                {
                    getHexNumber = getHexNumber + final[i];
                }

                getDecNumber = Convert.ToInt32(getHexNumber, 16);
                Console.Write(getDecNumber+" ");

                for (int i = 76; i < 84; i++)
                {
                    FinalCardID = FinalCardID + final[i];
                }
                

                Console.Write(FinalCardID);

                if (CheckFakeCard(getDecNumber.ToString()))
                {
                    CheckStatus();
                }
                else {
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
                    SendDuplicateEmail(getDecNumber.ToString());
                }


            }
            value = "";
            hex = "";
            getHexNumber = "";
            FinalCardID = "";
        }
        public void SendDuplicateEmail(string EPC)
        {
            string Email = "";
            MySqlConnection duplicatecn = new MySqlConnection(ConnectionString);

            string duplicatecnsql = "select EmailAddress from student where EPC=@EPC;";
            MySqlCommand duplicatecnCommand = new MySqlCommand(duplicatecnsql, duplicatecn);

            duplicatecn.Open();
            duplicatecnCommand.Parameters.AddWithValue("@EPC", EPC);

            Email = Convert.ToString(duplicatecnCommand.ExecuteScalar());
            duplicatecn.Close();






            MailMessage mMailMessage = new MailMessage();
            // address of sender 
            mMailMessage.From = new MailAddress("fypzhimeng@hotmail.com");
            mMailMessage.To.Add(new MailAddress(Email));
            mMailMessage.Subject = "Smart Attendance System Information";
            mMailMessage.Body = "Your card has been duplicated, please contact will administrator as soon as posiable!";
            SmtpClient sc = new SmtpClient("smtp.live.com");
            sc.Port = 587;
            sc.Credentials = new NetworkCredential("fypzhimeng@hotmail.com", "zhimeng123");

            sc.EnableSsl = true;
            sc.Send(mMailMessage);
            Console.WriteLine("Send successful");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (; ; )
            {
                SendSampleData();
                Thread.Sleep(1000);
                getData();
                Thread.Sleep(1000);

            }
        }
        public void CheckStatus()
        {
            string status = "", StartTime = "", EndTime = "", LastStatus = "";

            string selectTime = "select StartTime, EndTime from classinfo where ClassId=@ClassId;";
            MySqlCommand selectTimeCommand = new MySqlCommand(selectTime, cn);

            cn.Open();
            selectTimeCommand.Parameters.AddWithValue("@ClassId", ClassID.Text);
            MySqlDataReader objDataReader = selectTimeCommand.ExecuteReader();
            objDataReader.Read();
            StartTime = objDataReader[0].ToString();
            EndTime = objDataReader[1].ToString();
            cn.Close();
            t1 = Convert.ToDateTime(StartTime);
            t3 = Convert.ToDateTime(EndTime);
            t2 = t1.AddMinutes(15);
            t4 = t3.AddMinutes(15);
            
            //first 15 minutes enter the class room
            if (DateTime.Now >= t1 && DateTime.Now < t2 && !CheckRoll(getDecNumber.ToString()))
            {
                
                SaveToDatabase("In");
                Console.Beep();
                Console.Beep();
                //SendEmail(GetEmailAddress(getDecNumber.ToString()), "You enter the classroom.");
            }
            else if (DateTime.Now >= t1 && DateTime.Now < t2 && CheckRoll(getDecNumber.ToString()))
            {

               SendEmail(GetEmailAddress(getDecNumber.ToString()), "You have already enter the classroom.");                
            }

            else if (DateTime.Now >= t2 && DateTime.Now < t3 && CheckOddEven() == true)
            {
                SaveToDatabase("Out");
                Console.Beep();
                //SendEmail(GetEmailAddress(getDecNumber.ToString()), "You leave the classroom.");              
            }
            else if (DateTime.Now >= t2 && DateTime.Now < t3 && CheckOddEven() == false)
            {
                SaveToDatabase("In");
                Console.Beep();
                Console.Beep();
               // SendEmail(GetEmailAddress(getDecNumber.ToString()), "You enter the classroom.");               
            }
            else if (DateTime.Now >= t3 && DateTime.Now <= t4 && CheckRoll(getDecNumber.ToString()))
            
            {
                string NumberOfRowsSQL = "SELECT MovementStatus FROM movement WHERE EPC = @EPC and ClassId=@ClassId ORDER BY MovementId DESC  LIMIT 1;";
                MySqlCommand NumberOfRowsSQLCommand = new MySqlCommand(NumberOfRowsSQL, cn);

                cn.Open();
                NumberOfRowsSQLCommand.Parameters.AddWithValue("@EPC", getDecNumber.ToString());
                NumberOfRowsSQLCommand.Parameters.AddWithValue("@ClassId", ClassID.Text);
                LastStatus = Convert.ToString(NumberOfRowsSQLCommand.ExecuteScalar());
                cn.Close();

                if (LastStatus == "In")
                {
                    SaveToDatabase("Out");
                    Console.Beep();
                    //SendEmail(GetEmailAddress(getDecNumber.ToString()), "You have leave the class.");
                }
                else if (LastStatus == "Out")
                {
                    SendEmail(GetEmailAddress(getDecNumber.ToString()), "Sorry, you have already sign out.");                  
                }
            }


        }

        public bool CheckOddEven()
        {
            bool result;
            int NumberOfRows = 0;
            string NumberOfRowsSQL = "SELECT COUNT(*) FROM movement where EPC =@EPC and ClassId=@ClassId ;";
            MySqlCommand NumberOfRowsSQLCommand = new MySqlCommand(NumberOfRowsSQL, cn);
            //and TimeRecord>@TimeRecord1 and TimeRecord<@TimeRecord2
            cn.Open();
            NumberOfRowsSQLCommand.Parameters.AddWithValue("@EPC", getDecNumber.ToString());
            NumberOfRowsSQLCommand.Parameters.AddWithValue("@ClassId", ClassID.Text);
            //NumberOfRowsSQLCommand.Parameters.AddWithValue("@TimeRecord1", t2.ToString("hh:mm:ss"));
            //NumberOfRowsSQLCommand.Parameters.AddWithValue("@TimeRecord2", t3.ToString("hh:mm:ss"));
            NumberOfRows = Convert.ToInt32(NumberOfRowsSQLCommand.ExecuteScalar());
            cn.Close();

            if (NumberOfRows % 2 == 1)
            {
                result = true;
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }


        public string GetEmailAddress(string epc)
        {
            string studentemail = "";
            string sqlStudentEmail = "select EmailAddress from student where EPC=@EPC";
            MySqlCommand sqlCommand = new MySqlCommand(sqlStudentEmail, cn);

            cn.Open();
            sqlCommand.Parameters.AddWithValue("@EPC", epc);
            studentemail = Convert.ToString(sqlCommand.ExecuteScalar());

            cn.Close();
            return studentemail;
        }


        public void SendEmail(string Email, string Message)
        {
            //try
            //{
            MailMessage mMailMessage = new MailMessage();
            // address of sender 
            mMailMessage.From = new MailAddress("fypzhimeng@hotmail.com");
            mMailMessage.To.Add(new MailAddress(Email));
            mMailMessage.Subject = "Smart Attendance System Information";
            mMailMessage.Body = Message;
            SmtpClient sc = new SmtpClient("smtp.live.com");
            sc.Port = 587;
            sc.Credentials = new NetworkCredential("fypzhimeng@hotmail.com", "zhimeng123");

            sc.EnableSsl = true;
            sc.Send(mMailMessage);
            Console.WriteLine("Send successful");
        }

        public bool CheckRoll(string epc)
        {
            bool result = false;
            string sqlCheck = "select * from movement where EPC=@EPC and ClassId=@ClassId;";
            MySqlCommand sqlCheckCommand = new MySqlCommand(sqlCheck, cn);

            //sqlCheckCommand.Parameters.Clear();
            sqlCheckCommand.Parameters.AddWithValue("@EPC", epc);
            sqlCheckCommand.Parameters.AddWithValue("@ClassId", ClassID.Text);
            cn.Open();

            MySqlDataReader rd = sqlCheckCommand.ExecuteReader();
            result = rd.HasRows;
            cn.Close();

            return result;

        }
        public string GetStudentId(string epc)
        {
            string studentid = "";
            string sqlStudentId = "select StudentId from student where EPC=@EPC";
            MySqlCommand sqlCommand = new MySqlCommand(sqlStudentId, cn);

            cn.Open();
            sqlCommand.Parameters.AddWithValue("@EPC", getDecNumber.ToString());
            studentid = Convert.ToString(sqlCommand.ExecuteScalar());

            cn.Close();
            return studentid;
        }

        public void SaveToDatabase(string MovementStatus)
        {

            string sqlstr = "insert into movement (StudentId,MovementDate,TimeRecord,EPC,ClassId,MovementStatus)  values (@StudentId, @MovementDate, @TimeRecord, @EPC, @ClassId, @MovementStatus)";
            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);

            sqlcom.Parameters.AddWithValue("@StudentId", GetStudentId(getDecNumber.ToString()));
            sqlcom.Parameters.AddWithValue("@EPC", getDecNumber.ToString());
            sqlcom.Parameters.AddWithValue("@ClassId", ClassID.Text);
            sqlcom.Parameters.AddWithValue("@MovementDate", DateTime.Now.ToString("yyyyMMdd"));
            sqlcom.Parameters.AddWithValue("@TimeRecord", DateTime.Now.ToString("hhmmss"));
            sqlcom.Parameters.AddWithValue("@MovementStatus", MovementStatus);
            //sqlcom.Parameters.AddWithValue("@MovementStatus", CheckStatus());

            cn.Open();
            sqlcom.ExecuteNonQuery();
            cn.Close();

        }

        public void fillTeachingYear()
        {
            string sqlstr = "SELECT TeachingYear FROM attendance.classinfo group by TeachingYear";
            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);
            cn.Open();
            MySqlDataReader objDataReader = sqlcom.ExecuteReader();
            while (objDataReader.Read())
            {
                string CID = objDataReader.GetString("TeachingYear");
                TeachingYear.Items.Add(CID);
            }
            cn.Close();



        }

        private void TeachingYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeachingYear.Text != "")
            {
                string sqlstrSemester = "SELECT Semester FROM attendance.classinfo where TeachingYear=@TeachingYear group by Semester";
                Semester.Items.Clear();
                CourseCode.Items.Clear();
                ClassDate.Items.Clear();
                Semester.Text = "";
                CourseCode.Text = null;
                CourseName.Text = null;
                ClassDate.Text = null;
                ErrorMessage.Text = null;
                ClassID.Text = null;
                ClassTime.Text = "";
                MySqlCommand sqlstrSemestercom = new MySqlCommand(sqlstrSemester, cn);
                sqlstrSemestercom.Parameters.AddWithValue("@TeachingYear", TeachingYear.Text);
                cn.Open();
                MySqlDataReader sqlstrSemesterReader = sqlstrSemestercom.ExecuteReader();
                while (sqlstrSemesterReader.Read())
                {
                    string CID = sqlstrSemesterReader.GetString("Semester");
                    Semester.Items.Add(CID);
                }
                cn.Close();

            }
        }

        private void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Semester.Text != "")
            {
                string sqlstrCourseCode = "SELECT CourseCode FROM attendance.classinfo where TeachingYear=@TeachingYear and Semester=@Semester group by CourseCode";
                CourseCode.Items.Clear();
                //Semester.Text = null;
                CourseCode.Text = null;
                CourseName.Text = null;
                ClassDate.Text = null;
                ErrorMessage.Text = null;
                ClassID.Text = null;
                ClassTime.Text = "";
                MySqlCommand sqlstrCourseCodecom = new MySqlCommand(sqlstrCourseCode, cn);
                sqlstrCourseCodecom.Parameters.AddWithValue("@TeachingYear", TeachingYear.Text);
                sqlstrCourseCodecom.Parameters.AddWithValue("@Semester", Semester.Text);
                cn.Open();
                MySqlDataReader sqlstrCourseCodeReader = sqlstrCourseCodecom.ExecuteReader();
                while (sqlstrCourseCodeReader.Read())
                {
                    string CID = sqlstrCourseCodeReader.GetString("CourseCode");
                    CourseCode.Items.Add(CID);
                }
                cn.Close();


            }
        }

        private void CourseCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassDate.Items.Clear();
            //Semester.Text = null;          
            CourseName.Text = null;
            ClassDate.Text = null;
            ErrorMessage.Text = null;
            ClassID.Text = null;
            ClassTime.Text = "";
            string CourseNamesql = "SELECT CourseName FROM attendance.course where CourseCode=@CourseCode";
            MySqlCommand CourseNamecom = new MySqlCommand(CourseNamesql, cn);
            CourseNamecom.Parameters.AddWithValue("@CourseCode", CourseCode.Text);
            cn.Open();
            MySqlDataReader CourseNamesqlReader = CourseNamecom.ExecuteReader();
            CourseNamesqlReader.Read();
            CourseName.Text = CourseNamesqlReader.GetString("CourseName");
            cn.Close();


            string sqlstrClassDate = "SELECT ClassDate FROM attendance.classinfo where TeachingYear=@TeachingYear and Semester=@Semester and CourseCode=@CourseCode group by ClassDate";          
            MySqlCommand sqlstrClassDatecom = new MySqlCommand(sqlstrClassDate, cn);
            sqlstrClassDatecom.Parameters.AddWithValue("@TeachingYear", TeachingYear.Text);
            sqlstrClassDatecom.Parameters.AddWithValue("@Semester", Semester.Text);
            sqlstrClassDatecom.Parameters.AddWithValue("@CourseCode", CourseCode.Text);
            cn.Open();
            MySqlDataReader sqlstrClassDateReader = sqlstrClassDatecom.ExecuteReader();
            while (sqlstrClassDateReader.Read())
            {
                string CID = Convert.ToDateTime(sqlstrClassDateReader.GetString("ClassDate")).ToString("yyyy/MM/dd");

                ClassDate.Items.Add(CID);
            }
            cn.Close();
        }

        private void ClassDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlClassID = "SELECT ClassId FROM attendance.classinfo where TeachingYear=@TeachingYear and Semester=@Semester and CourseCode=@CourseCode and ClassDate=@ClassDate";
            MySqlCommand sqlClassIDcom = new MySqlCommand(sqlClassID, cn);
            sqlClassIDcom.Parameters.AddWithValue("@TeachingYear", TeachingYear.Text);
            sqlClassIDcom.Parameters.AddWithValue("@Semester", Semester.Text);
            sqlClassIDcom.Parameters.AddWithValue("@CourseCode", CourseCode.Text);
            sqlClassIDcom.Parameters.AddWithValue("@ClassDate", ClassDate.Text);
            cn.Open();
            MySqlDataReader sqlClassIDReader = sqlClassIDcom.ExecuteReader();
            sqlClassIDReader.Read();
            string CID2 = sqlClassIDReader.GetString("ClassId");
            ClassID.Text = CID2;
            cn.Close();


            string sqlClassTime = "SELECT StartTime,EndTime FROM attendance.classinfo where TeachingYear=@TeachingYear and Semester=@Semester and CourseCode=@CourseCode and ClassDate=@ClassDate";
            MySqlCommand sqlClassTimecom = new MySqlCommand(sqlClassTime, cn);
            sqlClassTimecom.Parameters.AddWithValue("@TeachingYear", TeachingYear.Text);
            sqlClassTimecom.Parameters.AddWithValue("@Semester", Semester.Text);
            sqlClassTimecom.Parameters.AddWithValue("@CourseCode", CourseCode.Text);
            sqlClassTimecom.Parameters.AddWithValue("@ClassDate", ClassDate.Text);
            cn.Open();
            MySqlDataReader sqlClassTimeReader = sqlClassTimecom.ExecuteReader();
            sqlClassTimeReader.Read();
            string classtime = sqlClassTimeReader.GetString("StartTime") + "-" + sqlClassTimeReader.GetString("EndTime");
            ClassTime.Text = classtime;
            cn.Close();
        }
    }
}
