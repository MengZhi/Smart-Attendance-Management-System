using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class LVAShowAllClasses : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        static MySqlConnection cn2 = new MySqlConnection(ConnectionString);
        string courseid = "";
        string classid = "";
        List<string> array = new List<string>();
        string[] StudentId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
                //Session["AuthorizedLecturer"] = "Yes";
            }
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

        public void GetStudentId()
        {
            string sqlStudentId = "select StudentId from registerinformation where TeachingYear=@TeachingTear and Semester=@Semester and CourseId=@CourseId";           
            MySqlCommand sqlCommand = new MySqlCommand(sqlStudentId, cn);

            cn.Open();
            sqlCommand.Parameters.AddWithValue("@TeachingTear", Session["TeachingYear"].ToString());
            sqlCommand.Parameters.AddWithValue("@Semester", Session["Semester"].ToString());
            sqlCommand.Parameters.AddWithValue("@CourseId", courseid);

            MySqlDataReader objDataReader = sqlCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                array.Add(objDataReader[0].ToString());
            }
            StudentId = array.ToArray();
            
            cn.Close();           
        }

        //public int StudentNumberOfOneCourse()
        //{
        //    int studentnumber = 0;
            
        //    string sqlStudentNumber = "SELECT COUNT(*) FROM registerinformation where CourseId=@CourseId and TeachingYear=@TeachingYear and Semester=@Semester;";

        //    MySqlCommand sqlStudentNumberCommand = new MySqlCommand(sqlStudentNumber, cn);

        //    //sqlCheckCommand.Parameters.Clear();
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@CourseId", courseid);
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@TeachingYear", Session["TeachingYear"].ToString());
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@Semester", Session["Semester"].ToString());
        //    cn.Open();

        //    studentnumber = Convert.ToInt32(sqlStudentNumberCommand.ExecuteScalar());
            
        //    cn.Close();

        //    return studentnumber;        
        //}

        //public int StudentNumberOfAttend(string classid)
        //{
        //    int studentnumber = 0;
        //    string sqlStudentNumber = "SELECT COUNT(*) FROM studentattendance where CourseId=@CourseId and ClassId=@ClassId and AttendanceStatus='Attend' ;";

        //    MySqlCommand sqlStudentNumberCommand = new MySqlCommand(sqlStudentNumber, cn);

        //    //sqlCheckCommand.Parameters.Clear();
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@CourseId", courseid);
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@ClassId", classid);
            
        //    cn.Open();
        //    studentnumber = Convert.ToInt32(sqlStudentNumberCommand.ExecuteScalar());
        //    cn.Close();

        //    return studentnumber;
        //}
        //public int StudentNumberOfAbsent(string classid)
        //{
        //    int studentnumber = 0;
        //    string sqlStudentNumber = "SELECT COUNT(*) FROM studentattendance where CourseId=@CourseId and ClassId=@ClassId and AttendanceStatus='Absent' ;";

        //    MySqlCommand sqlStudentNumberCommand = new MySqlCommand(sqlStudentNumber, cn);

        //    //sqlCheckCommand.Parameters.Clear();
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@CourseId", courseid);
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@ClassId", classid);

        //    cn.Open();
        //    studentnumber = Convert.ToInt32(sqlStudentNumberCommand.ExecuteScalar());
        //    cn.Close();

        //    return studentnumber;
        //}
        //public int StudentNumberOfIncomplete(string classid)
        //{
        //    int studentnumber = 0;
        //    string sqlStudentNumber = "SELECT COUNT(*) FROM studentattendance where CourseId=@CourseId and ClassId=@ClassId and AttendanceStatus='Incomplete' ;";

        //    MySqlCommand sqlStudentNumberCommand = new MySqlCommand(sqlStudentNumber, cn);

        //    //sqlCheckCommand.Parameters.Clear();
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@CourseId", courseid);
        //    sqlStudentNumberCommand.Parameters.AddWithValue("@ClassId", classid);

        //    cn.Open();
        //    studentnumber = Convert.ToInt32(sqlStudentNumberCommand.ExecuteScalar());
        //    cn.Close();

        //    return studentnumber;
        //}

        public bool CheckRoll(string studentid)
        {
            bool result = false;
            string sqlCheck = "select * from studentattendance where StudentId=@StudentId and ClassId=@ClassId;";
            MySqlCommand sqlCheckCommand = new MySqlCommand(sqlCheck, cn);

            //sqlCheckCommand.Parameters.Clear();
            sqlCheckCommand.Parameters.AddWithValue("@StudentId", studentid);
            sqlCheckCommand.Parameters.AddWithValue("@ClassId", classid);
            cn.Open();

            MySqlDataReader rd = sqlCheckCommand.ExecuteReader();
            result = rd.HasRows;
            cn.Close();

            return result;

        }
        


        public void InsertValue()
        {
             
            string sqlInsert = "INSERT into studentattendance (StudentId,ClassId,CourseId,TeachingYear,Semester) values (@StudentId,@ClassId,@CourseId,@TeachingYear,@Semester);";
            

            MySqlCommand sqlInsertCommand = new MySqlCommand(sqlInsert, cn2);
           

            for (int i = 0; i < StudentId.Length; i++)
            {

                if (!CheckRoll(StudentId[i]))
                {                   
                    cn2.Open();
                    sqlInsertCommand.Parameters.Clear();
                    sqlInsertCommand.Parameters.AddWithValue("@StudentId", StudentId[i].ToString());
                    sqlInsertCommand.Parameters.AddWithValue("@ClassId", classid);
                    sqlInsertCommand.Parameters.AddWithValue("@CourseId", courseid);
                    sqlInsertCommand.Parameters.AddWithValue("@TeachingYear", Session["TeachingYear"].ToString());
                    sqlInsertCommand.Parameters.AddWithValue("@Semester", Session["Semester"].ToString());
                    sqlInsertCommand.ExecuteReader();
                    cn2.Close();
                }
                
            }
            
        }


        protected void CheckAttendance_Click(object sender, EventArgs e)
        {
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            Session["ClassDate"] = (grdRow.FindControl("lblClassDate") as Label).Text;
            classid = (grdRow.FindControl("lblClassId") as Label).Text;
            Session["ClassId"] = classid;
            GetCourseId();
            GetStudentId();
            InsertValue();






            Response.Redirect("LVAOneClass.aspx");
        }

        public void bind()
        {
            try
            {
                MySqlCommand dataCommand4 = new MySqlCommand();
                dataCommand4.Connection = cn;
                dataCommand4.CommandText = "SELECT ClassId, BuildingNumber, RoomNumber,ClassDate,StartTime,EndTime from classinfo where Semester=@Semester and TeachingYear=@TeachingYear and CourseCode=@CourseCode ;";
                //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                dataCommand4.Parameters.AddWithValue("@Semester", Session["Semester"].ToString());
                dataCommand4.Parameters.AddWithValue("@TeachingYear", Session["TeachingYear"].ToString());
                dataCommand4.Parameters.AddWithValue("@CourseCode", Session["CourseCode"].ToString());
                

                MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                System.Data.DataTable my = new System.Data.DataTable();

                cn.Open();
                ada.Fill(my);
                GridView1.DataSource = my;
                //GridView1.
                GridView1.DataKeyNames = new string[] { "ClassId" };//主键
                GridView1.DataBind();
                cn.Close();
            }
            catch
            {
                Massege.Text = "Have no record!";

            }

        }

        protected void ChooseAnotherCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("LVAShowingCourse.aspx");
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }


    }
}