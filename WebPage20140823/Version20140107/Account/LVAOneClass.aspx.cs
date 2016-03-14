using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class LVAOneCourse : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        //static string ConnectionString2 = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static string ConnectionString2 = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        static MySqlConnection cn2 = new MySqlConnection(ConnectionString2);
        static MySqlConnection cn3 = new MySqlConnection(ConnectionString);
        static MySqlConnection cn4 = new MySqlConnection(ConnectionString);
        static MySqlConnection cn5 = new MySqlConnection(ConnectionString);

        double studentnumber, attendancenumber, incompletenumber, absentnumber;
        string courseid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
                SummaryBind();
                //Session["AuthorizedStudent"] = "Yes";
            }
        }



        protected void CheckMovement_Click(object sender, EventArgs e)
        {
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            Session["MatricNumber"] = (grdRow.FindControl("lblMatricNumber") as Label).Text;
            Session["StudentName"] = (grdRow.FindControl("lblFirstName") as Label).Text + " "+(grdRow.FindControl("lblLastName") as Label).Text;
            Response.Redirect("LVAStudentMovement.aspx");
        }

        public void GetCourseId()
        {
            string SelectCourseId = "select CourseId from course where CourseCode=@CourseCode;";
            string CourseId = "";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectCourseId, cn);

            cn.Open();
            dataCommand1.Parameters.AddWithValue("@CourseCode", Session["CourseCode"].ToString());

            CourseId = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();

            courseid = CourseId;

        }

        public string GetClassId()
        {
            string SelectClassId = "select ClassId from classinfo where TeachingYear=@TeachingYear and Semester=@Semester and CourseCode=@CourseCode and ClassDate=@ClassDate;";
            string classId = "";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectClassId, cn);



            cn.Open();
            dataCommand1.Parameters.AddWithValue("@TeachingYear", Session["TeachingYear"].ToString());
            dataCommand1.Parameters.AddWithValue("@Semester", Session["Semester"].ToString());
            dataCommand1.Parameters.AddWithValue("@CourseCode", Session["CourseCode"].ToString());
            dataCommand1.Parameters.AddWithValue("@ClassDate", Session["ClassDate"].ToString());

            classId = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();

            return classId;
        }

        public void bind()
        {
            //try
            //{
                MySqlCommand dataCommand4 = new MySqlCommand();
                dataCommand4.Connection = cn;
                dataCommand4.CommandText = "select StudentAttendanceId, FirstName, LastName, MatricNumber, EmailAddress, AttendanceStatus, classinfo.ClassId from studentattendance join student join classinfo where studentattendance.StudentId=student.StudentId and classinfo.ClassId= studentattendance.ClassId and studentattendance.ClassId=@ClassId;";
                //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                dataCommand4.Parameters.AddWithValue("@ClassId", GetClassId());


                MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                System.Data.DataTable my = new System.Data.DataTable();

                cn.Open();
                ada.Fill(my);
                GridView1.DataSource = my;
                //GridView1.
                GridView1.DataKeyNames = new string[] { "StudentAttendanceId" };//主键
                GridView1.DataBind();
                cn.Close();
            //}
            //catch
            //{
            //    Response.Write("Have no record!");

            //}

        }

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
        //    bind();
        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    bind();
        //}

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    string Status = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlAttendanceStatus")).Text;
        //    string AttendanceId = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblStudentAttendanceId")).Text;


        //    string sqlstr = "update studentattendance set AttendanceStatus=@AttendanceStatus where StudentAttendanceId=@StudentAttendanceId;";
        //    MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);

        //    sqlcom.Parameters.AddWithValue("@AttendanceStatus", Status);
        //    sqlcom.Parameters.AddWithValue("@StudentAttendanceId", AttendanceId);
            

        //    //sqlcom.Parameters.Add("@EPC", MySqlDbType.VarChar).Value = EPC;
        //    //sqlcom.Parameters.Add("@SchoolName", MySqlDbType.VarChar).Value = SchoolName;



        //    cn.Open();
        //    sqlcom.ExecuteNonQuery();
        //    cn.Close();
        //    GridView1.EditIndex = -1;
        //    bind();
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        protected void ChooseAnotherClass_Click(object sender, EventArgs e)
        {
            Response.Redirect("LVAShowAllClasses.aspx");
        }

        public string GetTimeFormat(int Seconds)
        {
            string timeformat = string.Empty;
            TimeSpan Mytimes = new TimeSpan(0, 0, Seconds);
            timeformat = new DateTime(Mytimes.Ticks).ToString("HH:mm:ss");
            return timeformat;
        }

        public int StudentNumberOfOneCourse()
        {
            int studentnumber = 0;
            GetCourseId();
            string sqlStudentNumber = "SELECT COUNT(*) FROM registerinformation where CourseId=@CourseId and TeachingYear=@TeachingYear and Semester=@Semester;";

            MySqlCommand sqlStudentNumberCommand = new MySqlCommand(sqlStudentNumber, cn);

            //sqlCheckCommand.Parameters.Clear();
            sqlStudentNumberCommand.Parameters.AddWithValue("@CourseId", courseid);
            sqlStudentNumberCommand.Parameters.AddWithValue("@TeachingYear", Session["TeachingYear"].ToString());
            sqlStudentNumberCommand.Parameters.AddWithValue("@Semester", Session["Semester"].ToString());
            cn.Open();

            studentnumber = Convert.ToInt32(sqlStudentNumberCommand.ExecuteScalar());

            cn.Close();

            return studentnumber;
        }

        public int StudentNumberOfAttend(string classid)
        {
            int studentnumber = 0;
            string sqlStudentNumber = "SELECT COUNT(*) FROM studentattendance where CourseId=@CourseId and ClassId=@ClassId and AttendanceStatus='Attend' ;";

            MySqlCommand sqlStudentNumberCommand = new MySqlCommand(sqlStudentNumber, cn);

            //sqlCheckCommand.Parameters.Clear();
            sqlStudentNumberCommand.Parameters.AddWithValue("@CourseId", courseid);
            sqlStudentNumberCommand.Parameters.AddWithValue("@ClassId", classid);

            cn.Open();
            studentnumber = Convert.ToInt32(sqlStudentNumberCommand.ExecuteScalar());
            cn.Close();

            return studentnumber;
        }
        public int StudentNumberOfAbsent(string classid)
        {
            int studentnumber = 0;
            string sqlStudentNumber = "SELECT COUNT(*) FROM studentattendance where CourseId=@CourseId and ClassId=@ClassId and AttendanceStatus='Absent' ;";

            MySqlCommand sqlStudentNumberCommand = new MySqlCommand(sqlStudentNumber, cn);

            //sqlCheckCommand.Parameters.Clear();
            sqlStudentNumberCommand.Parameters.AddWithValue("@CourseId", courseid);
            sqlStudentNumberCommand.Parameters.AddWithValue("@ClassId", classid);

            cn.Open();
            studentnumber = Convert.ToInt32(sqlStudentNumberCommand.ExecuteScalar());
            cn.Close();

            return studentnumber;
        }

        public bool checkMovementInHasRoll(string studentid, string classid)
        {
            bool flag;          
            string sqlIn = "select * from movement where StudentId=@StudentId and ClassId=@ClassId and MovementStatus='In'";
            MySqlCommand sqlInCommand = new MySqlCommand(sqlIn, cn3);
            sqlInCommand.Parameters.AddWithValue("@StudentId", studentid);
            sqlInCommand.Parameters.AddWithValue("@ClassId", classid);
            cn3.Open();
            MySqlDataReader rd = sqlInCommand.ExecuteReader();
            flag = rd.HasRows;
            cn3.Close();
            return flag;
        
        }

        public bool checkMovementOutHasRoll(string studentid, string classid)
        {
            bool flag;
            string sqlOut = "select * from movement where StudentId=@StudentId and ClassId=@ClassId and MovementStatus='Out'";
            MySqlCommand sqlOutCommand = new MySqlCommand(sqlOut, cn3);
            sqlOutCommand.Parameters.AddWithValue("@StudentId", studentid);
            sqlOutCommand.Parameters.AddWithValue("@ClassId", classid);
            cn3.Open();
            MySqlDataReader rd = sqlOutCommand.ExecuteReader();
            flag = rd.HasRows;
            cn3.Close();
            return flag;
        
        }

        public int StudentNumberOfIncomplete(string classid)
        {
            int studentnumber = 0;
            string sqlStudentNumber = "SELECT COUNT(*) FROM studentattendance where CourseId=@CourseId and ClassId=@ClassId and AttendanceStatus='Incomplete' ;";

            MySqlCommand sqlStudentNumberCommand = new MySqlCommand(sqlStudentNumber, cn);

            //sqlCheckCommand.Parameters.Clear();
            sqlStudentNumberCommand.Parameters.AddWithValue("@CourseId", courseid);
            sqlStudentNumberCommand.Parameters.AddWithValue("@ClassId", classid);

            cn.Open();
            studentnumber = Convert.ToInt32(sqlStudentNumberCommand.ExecuteScalar());
            cn.Close();

            return studentnumber;
        }

        public void InsertSummary()
        {
            string sqlInsertSummary = "UPDATE classinfo SET StudentNumber=@StudentNumber,AttendanceNumber=@AttendanceNumber, IncompleteNumber=@IncompleteNumber, AbsentNumber=@AbsentNumber WHERE ClassId=@ClassId;";
            MySqlCommand sqlInsertSummaryCommand = new MySqlCommand(sqlInsertSummary, cn2);
            cn2.Open();
            sqlInsertSummaryCommand.Parameters.AddWithValue("@StudentNumber", StudentNumberOfOneCourse());
            sqlInsertSummaryCommand.Parameters.AddWithValue("@AttendanceNumber", StudentNumberOfAttend(GetClassId()));
            sqlInsertSummaryCommand.Parameters.AddWithValue("@IncompleteNumber", StudentNumberOfIncomplete(GetClassId()));
            sqlInsertSummaryCommand.Parameters.AddWithValue("@AbsentNumber", StudentNumberOfAbsent(GetClassId()));
            sqlInsertSummaryCommand.Parameters.AddWithValue("@ClassId", GetClassId());
            sqlInsertSummaryCommand.ExecuteReader();
            cn2.Close();
        
        }

        public void LastRollIsIn(string studentid, string classid, int ClassTimeDifferent)
        {
            int InRollNumber = 0, TimeDifferent=0;
            string RollNumberL = "select count(*) from movement where StudentId=@StudentId and ClassId=@ClassId";
            string SelectInTimeL = "select TIME_TO_SEC(TimeRecord) from movement where StudentId=@StudentId and ClassId=@ClassId and MovementStatus='In'";
            string SelectOutTimeL = "select TIME_TO_SEC(TimeRecord) from movement where StudentId=@StudentId and ClassId=@ClassId and MovementStatus='Out'";
            string InsertStatusL = "UPDATE studentattendance SET AttendanceStatus=@AttendanceStatus,StayInClassTime=@StayInClassTime WHERE StudentId=@StudentId and ClassId=@ClassId;";

            MySqlCommand RollNumberLCommand = new MySqlCommand(RollNumberL, cn4);
            MySqlCommand SelectInTimeLCommand = new MySqlCommand(SelectInTimeL, cn4);
            MySqlCommand SelectOutTimeLCommand = new MySqlCommand(SelectOutTimeL, cn5);
            MySqlCommand InsertStatusLCommand = new MySqlCommand(InsertStatusL, cn4);

            cn4.Open();
            RollNumberLCommand.Parameters.AddWithValue("@StudentId", studentid);
            RollNumberLCommand.Parameters.AddWithValue("@ClassId", classid);
            InRollNumber = Convert.ToInt32(RollNumberLCommand.ExecuteScalar());
            cn4.Close();

            cn4.Open();
            cn5.Open();
            SelectInTimeLCommand.Parameters.AddWithValue("@StudentId", studentid);
            SelectInTimeLCommand.Parameters.AddWithValue("@ClassId", classid);
            SelectOutTimeLCommand.Parameters.AddWithValue("@StudentId", studentid);
            SelectOutTimeLCommand.Parameters.AddWithValue("@ClassId", classid);
            MySqlDataReader objDataReaderIn = SelectInTimeLCommand.ExecuteReader();
            MySqlDataReader objDataReaderOut = SelectOutTimeLCommand.ExecuteReader();

            while (objDataReaderIn.Read() && objDataReaderOut.Read() && (InRollNumber-1)>0)
            {

                TimeDifferent += Convert.ToInt32(objDataReaderOut[0].ToString()) - Convert.ToInt32(objDataReaderIn[0].ToString());
                InRollNumber = InRollNumber - 1;
            }
            cn4.Close();
            cn5.Close();

            cn4.Open();
            InsertStatusLCommand.Parameters.AddWithValue("@AttendanceStatus", "Incomplete");
            InsertStatusLCommand.Parameters.AddWithValue("@StudentId", studentid);
            InsertStatusLCommand.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
            InsertStatusLCommand.Parameters.AddWithValue("@StayInClassTime", GetTimeFormat(TimeDifferent) + "/" + GetTimeFormat(ClassTimeDifferent));
            InsertStatusLCommand.ExecuteNonQuery();
            cn4.Close();       
        }


        protected void Refresh_Click(object sender, EventArgs e)
        {
                       
            string SelectStudentId = "select StudentId from studentattendance where ClassId=@ClassId;";
            Int32 SumOutTime=0, SumInTime=0;

            MySqlCommand SelectStudentIdCommand = new MySqlCommand(SelectStudentId, cn);
            

            cn.Open();
            SelectStudentIdCommand.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
            MySqlDataReader objDataReader = SelectStudentIdCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                string SelectOutTime = "select SUM(TIME_TO_SEC(TimeRecord)) from attendance.movement where StudentId=@StudentId and ClassId=@ClassId and MovementStatus='Out';";
                string SelectInTime = "select SUM(TIME_TO_SEC(TimeRecord))  from attendance.movement where StudentId=@StudentId and ClassId=@ClassId and MovementStatus='In';";
                string InsertStatus = "UPDATE studentattendance SET AttendanceStatus=@AttendanceStatus,StayInClassTime=@StayInClassTime WHERE StudentId=@StudentId and ClassId=@ClassId;";
                string GetClassTime = "select TIME_TO_SEC(EndTime)-TIME_TO_SEC(StartTime) from classinfo where ClassId=@ClassId";
                

                MySqlCommand SelectOutTimeCommand = new MySqlCommand(SelectOutTime, cn2);
                MySqlCommand SelectInTimeCommand = new MySqlCommand(SelectInTime, cn2);
                MySqlCommand InsertStatusCommand = new MySqlCommand(InsertStatus, cn2);
                MySqlCommand GetClassTimeCommand = new MySqlCommand(GetClassTime, cn2);
               

                SelectOutTimeCommand.Parameters.Clear();
                SelectInTimeCommand.Parameters.Clear();
                InsertStatusCommand.Parameters.Clear();
                GetClassTimeCommand.Parameters.Clear();

                if (checkMovementOutHasRoll(objDataReader[0].ToString(), Session["ClassId"].ToString()) == true)
                {
                    cn2.Open();
                    SelectOutTimeCommand.Parameters.AddWithValue("@StudentId", objDataReader[0].ToString());
                    SelectOutTimeCommand.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
                    SumOutTime = Convert.ToInt32(SelectOutTimeCommand.ExecuteScalar());
                    cn2.Close();
                }
                else if (checkMovementOutHasRoll(objDataReader[0].ToString(), Session["ClassId"].ToString()) == false)
                {
                    SumOutTime = 0;
                }


                if (checkMovementInHasRoll(objDataReader[0].ToString(), Session["ClassId"].ToString()) == true)
                {
                    cn2.Open();
                    SelectInTimeCommand.Parameters.AddWithValue("@StudentId", objDataReader[0].ToString());
                    SelectInTimeCommand.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
                    SumInTime = Convert.ToInt32(SelectInTimeCommand.ExecuteScalar());
                    cn2.Close();
                }
                else if (checkMovementInHasRoll(objDataReader[0].ToString(), Session["ClassId"].ToString()) == false)
                {
                    SumInTime = 0;
                }

                Int32 StudentTimeDifferent = SumOutTime - SumInTime;

                cn2.Open();
                GetClassTimeCommand.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
                Int32 ClassTimeDifferent = Convert.ToInt32(GetClassTimeCommand.ExecuteScalar());
                cn2.Close();

                cn2.Open();
                if (StudentTimeDifferent >= ClassTimeDifferent * 0.75)
                {
                    InsertStatusCommand.Parameters.AddWithValue("@AttendanceStatus", "Attend");
                    InsertStatusCommand.Parameters.AddWithValue("@StudentId", objDataReader[0].ToString());
                    InsertStatusCommand.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
                    InsertStatusCommand.Parameters.AddWithValue("@StayInClassTime", GetTimeFormat(StudentTimeDifferent) + "/" + GetTimeFormat(ClassTimeDifferent));
                    InsertStatusCommand.ExecuteNonQuery();
                    
                    //Response.Write("Finished1");
                }
                else if (StudentTimeDifferent < (ClassTimeDifferent * 0.75) && StudentTimeDifferent > 0)
                {
                    
                    InsertStatusCommand.Parameters.AddWithValue("@AttendanceStatus", "Incomplete");
                    InsertStatusCommand.Parameters.AddWithValue("@StudentId", objDataReader[0].ToString());
                    InsertStatusCommand.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
                    InsertStatusCommand.Parameters.AddWithValue("@StayInClassTime", GetTimeFormat(StudentTimeDifferent) + "/" + GetTimeFormat(ClassTimeDifferent));
                    InsertStatusCommand.ExecuteNonQuery();                    
                }

                else if (StudentTimeDifferent == 0)
                {
                    StudentTimeDifferent = 0;
                    InsertStatusCommand.Parameters.AddWithValue("@AttendanceStatus", "Absent");
                    InsertStatusCommand.Parameters.AddWithValue("@StudentId", objDataReader[0].ToString());
                    InsertStatusCommand.Parameters.AddWithValue("@ClassId", Session["ClassId"].ToString());
                    InsertStatusCommand.Parameters.AddWithValue("@StayInClassTime", GetTimeFormat(StudentTimeDifferent) + "/" + GetTimeFormat(ClassTimeDifferent));
                    InsertStatusCommand.ExecuteNonQuery();                    
                }
                else if (StudentTimeDifferent < 0)
                {
                    LastRollIsIn(objDataReader[0].ToString(), Session["ClassId"].ToString(), ClassTimeDifferent);
                
                }
                
                cn2.Close();                
            }
            cn.Close();            
            bind();
            InsertSummary();
            SummaryBind();
        }


        public void SummaryBind()
        {
            string Summarysql = "select StudentNumber,AttendanceNumber,IncompleteNumber,AbsentNumber from classinfo WHERE ClassId=@ClassId";
            MySqlCommand SummarysqlCommand = new MySqlCommand(Summarysql, cn2);
            cn2.Open();
            SummarysqlCommand.Parameters.AddWithValue("@ClassId", GetClassId());
            MySqlDataReader summaryinfo = SummarysqlCommand.ExecuteReader();

            summaryinfo.Read();
            studentnumber = Convert.ToInt16(summaryinfo[0]);
            
            summaryinfo.Read();
            attendancenumber = Convert.ToInt16(summaryinfo[1]);
           
            summaryinfo.Read();
            incompletenumber = Convert.ToInt16(summaryinfo[2]);
            
            summaryinfo.Read();
            absentnumber = Convert.ToInt16(summaryinfo[3]);
            
            cn2.Close();
           


          
            if (studentnumber != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("StudentNumberInfo", typeof(string));
                dt.Columns.Add("Persentage", typeof(string));
                DataRow dtrow = dt.NewRow();    // Create New Row
                dtrow["Status"] = "Attend";            //Bind Data to Columns
                dtrow["StudentNumberInfo"] = attendancenumber;
                dtrow["Persentage"] = ((double)attendancenumber / studentnumber).ToString("0.0%");

                dt.Rows.Add(dtrow);
                dtrow = dt.NewRow();               // Create New Row
                dtrow["Status"] = "Incomplete";               //Bind Data to Columns
                dtrow["StudentNumberInfo"] = incompletenumber;
                dtrow["Persentage"] = ((double)incompletenumber / studentnumber).ToString("0.0%");

                dt.Rows.Add(dtrow);
                dtrow = dt.NewRow();              // Create New Row
                dtrow["Status"] = "Absent";              //Bind Data to Columns
                dtrow["StudentNumberInfo"] = absentnumber;
                dtrow["Persentage"] = ((double)absentnumber / studentnumber).ToString("0.0%");

                dt.Rows.Add(dtrow);
                GridView2.DataSource = dt;
                GridView2.DataBind();


                StudentNumberInfo.Text = "Total students number in this class: " + studentnumber;
            }
                    
        }

        

        
    }
}