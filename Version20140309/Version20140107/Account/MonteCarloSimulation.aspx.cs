using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class MonteCarloSimulation : System.Web.UI.Page
    {
        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        MySqlCommand command = cn.CreateCommand();
        MySqlCommand command2 = cn.CreateCommand();

        public Random timeRnd = new Random();
        public static Random nameRnd = new Random();
        Random dateRnd = new Random();
        Random genderRan = new Random();
        Random studyYearRan = new Random();

        string FirstName,LastName,Gender,Birthday,EmailAddress,YearOfStudy,SchoolName="Computer Science";
        //int EPC2 = 1000;
        string EPCH="101010",EPCFinal;
        Int64 EPC2 = 0;
        int MatricNumber = 100000;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
            }
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            
            Response.Write(DateTime.Now.ToString("yyyyMMdd hh:mm:ss"));
        }

        public string generateEmailAddress()
        {
            string emailadd = "";

            emailadd = LastName + FirstName + "@gmail.com";

            return emailadd;
        }

        
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1989, 1, 1);
            DateTime end = new DateTime(1992, 1, 1);

            int range = (end - start).Days;
            return start.AddDays(dateRnd.Next(range)).Date;
        }
        

        public string generateTime()
        {
            
            TimeSpan start = TimeSpan.FromHours(9);
            TimeSpan end = TimeSpan.FromHours(11);
            
            int maxMinutes = (int)((end - start).TotalMinutes);

            //for (int i = 0; i < 100; ++i)
            //{
                int minutes = timeRnd.Next(maxMinutes);
                TimeSpan t = start.Add(TimeSpan.FromMinutes(minutes));
                // Do something with t...
                //Response.Write(t+"\n");      
                return t.ToString();
            //}      
        }

     
        public static string GenRandomLastName()
        {
            List<string> lst = new List<string>();
            string str = string.Empty;
            lst.Add("Smith");
            lst.Add("Johnson");
            lst.Add("Williams");
            lst.Add("Jones");
            lst.Add("Brown");
            lst.Add("Davis");
            lst.Add("Miller");
            lst.Add("Wilson");
            lst.Add("Moore");
            lst.Add("Taylor");
            lst.Add("Anderson");
            lst.Add("Thomas");
            lst.Add("Jackson");
            lst.Add("White");
            lst.Add("Harris");
            lst.Add("Martin");
            lst.Add("Thompson");
            lst.Add("Garcia");
            lst.Add("Martinez");
            lst.Add("Robinson");
            lst.Add("Clark");
            lst.Add("Rodriguez");
            lst.Add("Lewis");
            lst.Add("Lee");
            lst.Add("Walker");
            lst.Add("Hall");
            lst.Add("Allen");
            lst.Add("Young");
            lst.Add("Hernandez");
            lst.Add("King");
            lst.Add("Wright");
            lst.Add("Lopez");
            lst.Add("Hill");
            lst.Add("Scott");
            lst.Add("Green");
            lst.Add("Adams");
            lst.Add("Baker");
            lst.Add("Gonzalez");
            lst.Add("Nelson");
            lst.Add("Carter");
            lst.Add("Mitchell");
            lst.Add("Perez");
            lst.Add("Roberts");
            lst.Add("Turner");
            lst.Add("Phillips");
            lst.Add("Campbell");
            lst.Add("Parker");
            lst.Add("Evans");
            lst.Add("Edwards");
            lst.Add("Collins");
            lst.Add("Stewart");
            lst.Add("Sanchez");
            lst.Add("Morris");
            lst.Add("Rogers");
            lst.Add("Reed");
            lst.Add("Cook");
            lst.Add("Morgan");
            lst.Add("Bell");
            lst.Add("Murphy");
            lst.Add("Bailey");
            lst.Add("Rivera");
            lst.Add("Cooper");
            lst.Add("Richardson");
            lst.Add("Cox");
            lst.Add("Howard");
            lst.Add("Ward");
            lst.Add("Torres");
            lst.Add("Peterson");
            lst.Add("Gray");
            lst.Add("Ramirez");
            lst.Add("James");
            lst.Add("Watson");
            lst.Add("Brooks");
            lst.Add("Kelly");
            lst.Add("Sanders");
            lst.Add("Price");
            lst.Add("Bennett");
            lst.Add("Wood");
            lst.Add("Barnes");
            lst.Add("Ross");
            lst.Add("Henderson");
            lst.Add("Coleman");
            lst.Add("Jenkins");
            lst.Add("Perry");
            lst.Add("Powell");
            lst.Add("Long");
            lst.Add("Patterson");
            lst.Add("Hughes");
            lst.Add("Flores");
            lst.Add("Washington");
            lst.Add("Butler");
            lst.Add("Simmons");
            lst.Add("Foster");
            lst.Add("Gonzales");
            lst.Add("Bryant");
            lst.Add("Alexander");
            lst.Add("Russell");
            lst.Add("Griffin");
            lst.Add("Diaz");
            lst.Add("Hayes");

            str = lst.OrderBy(xx => nameRnd.Next()).First();
            //Response.Write(str);
            return str;
        }
        public static string GenRandomFirstName()
            {
            List<string> lst = new List<string>();
            string str = string.Empty;
            lst.Add("Aiden");
            lst.Add("Jackson");
            lst.Add("Mason");
            lst.Add("Liam");
            lst.Add("Jacob");
            lst.Add("Jayden");
            lst.Add("Ethan");
            lst.Add("Noah");
            lst.Add("Lucas");
            lst.Add("Logan");
            lst.Add("Caleb");
            lst.Add("Caden");
            lst.Add("Jack");
            lst.Add("Ryan");
            lst.Add("Connor");
            lst.Add("Michael");
            lst.Add("Elijah");
            lst.Add("Brayden");
            lst.Add("Benjamin");
            lst.Add("Nicholas");
            lst.Add("Alexander");
            lst.Add("William");
            lst.Add("Matthew");
            lst.Add("James");
            lst.Add("Landon");
            lst.Add("Nathan");
            lst.Add("Dylan");
            lst.Add("Evan");
            lst.Add("Luke");
            lst.Add("Andrew");
            lst.Add("Gabriel");
            lst.Add("Gavin");
            lst.Add("Joshua");
            lst.Add("Owen");
            lst.Add("Daniel");
            lst.Add("Carter");
            lst.Add("Tyler");
            lst.Add("Cameron");
            lst.Add("Christian");
            lst.Add("Wyatt");
            lst.Add("Henry");
            lst.Add("Eli");
            lst.Add("Joseph");
            lst.Add("Max");
            lst.Add("Isaac");
            lst.Add("Samuel");
            lst.Add("Anthony");
            lst.Add("Grayson");
            lst.Add("Zachary");
            lst.Add("David");
            lst.Add("Christopher");
            lst.Add("John");
            lst.Add("Isaiah");
            lst.Add("Levi");
            lst.Add("Jonathan");
            lst.Add("Oliver");
            lst.Add("Chase");
            lst.Add("Cooper");
            lst.Add("Tristan");
            lst.Add("Colton");
            lst.Add("Austin");
            lst.Add("Colin");
            lst.Add("Charlie");
            lst.Add("Dominic");
            lst.Add("Parker");
            lst.Add("Hunter");
            lst.Add("Thomas");
            lst.Add("Alex");
            lst.Add("Ian");
            lst.Add("Jordan");
            lst.Add("Cole");
            lst.Add("Julian");
            lst.Add("Aaron");
            lst.Add("Carson");
            lst.Add("Miles");
            lst.Add("Blake");
            lst.Add("Brody");
            lst.Add("Adam");
            lst.Add("Sebastian");
            lst.Add("Adrian");
            lst.Add("Nolan");
            lst.Add("Sean");
            lst.Add("Riley");
            lst.Add("Bentley");
            lst.Add("Xavier");
            lst.Add("Hayden");
            lst.Add("Jeremiah");
            lst.Add("Jason");
            lst.Add("Jake");
            lst.Add("Asher");
            lst.Add("Micah");
            lst.Add("Jace");
            lst.Add("Brandon");
            lst.Add("Josiah");
            lst.Add("Hudson");
            lst.Add("Nathaniel");
            lst.Add("Bryson");
            lst.Add("Ryder");
            lst.Add("Justin");
            lst.Add("Bryce");

            //—————female

            lst.Add("Sophia");
            lst.Add("Emma");
            lst.Add("Isabella");
            lst.Add("Olivia");
            lst.Add("Ava");
            lst.Add("Lily");
            lst.Add("Chloe");
            lst.Add("Madison");
            lst.Add("Emily");
            lst.Add("Abigail");
            lst.Add("Addison");
            lst.Add("Mia");
            lst.Add("Madelyn");
            lst.Add("Ella");
            lst.Add("Hailey");
            lst.Add("Kaylee");
            lst.Add("Avery");
            lst.Add("Kaitlyn");
            lst.Add("Riley");
            lst.Add("Aubrey");
            lst.Add("Brooklyn");
            lst.Add("Peyton");
            lst.Add("Layla");
            lst.Add("Hannah");
            lst.Add("Charlotte");
            lst.Add("Bella");
            lst.Add("Natalie");
            lst.Add("Sarah");
            lst.Add("Grace");
            lst.Add("Amelia");
            lst.Add("Kylie");
            lst.Add("Arianna");
            lst.Add("Anna");
            lst.Add("Elizabeth");
            lst.Add("Sophie");
            lst.Add("Claire");
            lst.Add("Lila");
            lst.Add("Aaliyah");
            lst.Add("Gabriella");
            lst.Add("Elise");
            lst.Add("Lillian");
            lst.Add("Samantha");
            lst.Add("Makayla");
            lst.Add("Audrey");
            lst.Add("Alyssa");
            lst.Add("Ellie");
            lst.Add("Alexis");
            lst.Add("Isabelle");
            lst.Add("Savannah");
            lst.Add("Evelyn");
            lst.Add("Leah");
            lst.Add("Keira");
            lst.Add("Allison");
            lst.Add("Maya");
            lst.Add("Lucy");
            lst.Add("Sydney");
            lst.Add("Taylor");
            lst.Add("Molly");
            lst.Add("Lauren");
            lst.Add("Harper");
            lst.Add("Scarlett");
            lst.Add("Brianna");
            lst.Add("Victoria");
            lst.Add("Liliana");
            lst.Add("Aria");
            lst.Add("Kayla");
            lst.Add("Annabelle");
            lst.Add("Gianna");
            lst.Add("Kennedy");
            lst.Add("Stella");
            lst.Add("Reagan");
            lst.Add("Julia");
            lst.Add("Bailey");
            lst.Add("Alexandra");
            lst.Add("Jordyn");
            lst.Add("Nora");
            lst.Add("Carolin");
            lst.Add("Mackenzie");
            lst.Add("Jasmine");
            lst.Add("Jocelyn");
            lst.Add("Kendall");
            lst.Add("Morgan");
            lst.Add("Nevaeh");
            lst.Add("Maria");
            lst.Add("Eva");
            lst.Add("Juliana");
            lst.Add("Abby");
            lst.Add("Alexa");
            lst.Add("Summer");
            lst.Add("Brooke");
            lst.Add("Penelope");
            lst.Add("Violet");
            lst.Add("Kate");
            lst.Add("Hadley");
            lst.Add("Ashlyn");
            lst.Add("Sadie");
            lst.Add("Paige");
            lst.Add("Katherine");
            lst.Add("Sienna");
            lst.Add("Piper");

            str = lst.OrderBy(xx => nameRnd.Next()).First();
            return str;
                       
        }

        public void enrollStudents()
        {
            command.Parameters.Clear();
            command2.Parameters.Clear();
            command.CommandText = "INSERT INTO attendance.student (FirstName, LastName,MatricNumber,EmailAddress,Birthday,Gender,YearOfStudy,SchoolName,EPC) VALUES (@FirstName, @LastName,@MatricNumber,@EmailAddress,@Birthday,@Gender,@YearOfStudy,@SchoolName,@EPC);";
            //command2.CommandText = "select * from attendance.userinfo where UserName='zhimeng1991@gmail.com'";
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("MatricNumber", MatricNumber);
            command.Parameters.AddWithValue("EmailAddress", EmailAddress);
            command.Parameters.AddWithValue("Birthday", Birthday);
            command.Parameters.AddWithValue("Gender", Gender);
            command.Parameters.AddWithValue("YearOfStudy", YearOfStudy);
            command.Parameters.AddWithValue("SchoolName", SchoolName);
            command.Parameters.AddWithValue("EPC", EPCFinal);

            //command2.CommandText = "select * from attendance.student";
            cn.Open();
            MySqlDataReader rd = command.ExecuteReader();
            cn.Close();

            command2.CommandText = "INSERT INTO attendance.userinfo (UserName,Password,UserType,RegisterTime) values (@UserName,@Password,'Student',@RegisterTime);";
            command2.Parameters.AddWithValue("Password", MatricNumber);
            command2.Parameters.AddWithValue("UserName", EmailAddress);
            command2.Parameters.AddWithValue("RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
            cn.Open();
            MySqlDataReader rd2 = command2.ExecuteReader();
            cn.Close();
        
        }
        
        public string gender()
        {
            if (genderRan.Next(0, 2) == 0)
                return "Female";
            else //if (genderRan.Next(0, 2) == 1)
                return "Male";
           // else return gender();
        }

        public string studyYear()
        {
            if (studyYearRan.Next(0, 4) == 0)
                return "First Year";
            else if (studyYearRan.Next(0, 4) == 1)
                return "Second Year";
            else if (studyYearRan.Next(0, 4) == 2)
                return "Third Year";
            else //if (studyYearRan.Next(0, 4) == 3)
                return "Final Year";
            //else return "Error";
        
        }
        


        protected void CreateStudents_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                if (i < 5)
                {
                    FirstName = GenRandomLastName();
                    LastName = GenRandomFirstName();
                    MatricNumber = MatricNumber + 1;
                    EmailAddress = generateEmailAddress();
                    Birthday = RandomDay().ToString("yyyyMMdd");
                    Gender = gender();
                    YearOfStudy = "Second Year";
                    EPC2 = EPC2 + 1;
                    EPCFinal = EPCH + EPC2.ToString();
                    enrollStudents();
                }
                else if (i >= 5 && i < 75)
                {
                    FirstName = GenRandomLastName();
                    LastName = GenRandomFirstName();
                    MatricNumber = MatricNumber + 1;
                    EmailAddress = generateEmailAddress();
                    Birthday = RandomDay().ToString("yyyyMMdd");
                    Gender = gender();
                    YearOfStudy = "First Year";
                    EPC2 = EPC2 + 1;
                    EPCFinal = EPCH + EPC2.ToString();
                    enrollStudents();
                }
                else if (i >= 75 && i < 100)
                {
                    FirstName = GenRandomLastName();
                    LastName = GenRandomFirstName();
                    MatricNumber = MatricNumber + 1;
                    EmailAddress = generateEmailAddress();
                    Birthday = RandomDay().ToString("yyyyMMdd");
                    Gender = gender();
                    YearOfStudy = "Third Year";
                    EPC2 = EPC2 + 1;
                    EPCFinal = EPCH + EPC2.ToString();
                    enrollStudents();
                }
                else if (i >= 100 && i < 120)
                {
                    FirstName = GenRandomLastName();
                    LastName = GenRandomFirstName();
                    MatricNumber = MatricNumber + 1;
                    EmailAddress = generateEmailAddress();
                    Birthday = RandomDay().ToString("yyyyMMdd");
                    Gender = gender();
                    YearOfStudy = "Final Year";
                    EPC2 = EPC2 + 1;
                    EPCFinal = EPCH + EPC2.ToString();
                    enrollStudents();
                }
                else if (i >= 120 && i < 200)
                {
                    FirstName = GenRandomLastName();
                    LastName = GenRandomFirstName();
                    MatricNumber = MatricNumber + 1;
                    EmailAddress = generateEmailAddress();
                    Birthday = RandomDay().ToString("yyyyMMdd");
                    Gender = gender();
                    YearOfStudy = "Second Year";
                    EPC2 = EPC2 + 1;
                    EPCFinal = EPCH + EPC2.ToString();
                    enrollStudents();
                }
            }
            
                
            
        }

        protected void RegisterCourse_Click(object sender, EventArgs e)
        {
            string CourseId;
            int StudentId ;
            string selectStudentID = "select StudentId, FirstName from student where EPC='1010101'";
            MySqlCommand dataCommand4 = new MySqlCommand(selectStudentID, cn);
            
            cn.Open();
            StudentId = (Int32)dataCommand4.ExecuteScalar()-1;
           
            cn.Close();
           
            //Response.Write(StudentId);

            for (int i = 0; i < 200; i++)
            {
                if (i < 5)
                {
                    CourseId = "1";
                    StudentId = StudentId + 1;
                    string InsertRI = "INSERT INTO attendance.registerinformation (StudentId,CourseId,RegisterTime) VALUES (@StudentId,@CourseId,@RegisterTime);";
                    MySqlCommand dataCommand3 = new MySqlCommand(InsertRI, cn);

                    cn.Open();
                    dataCommand3.Parameters.AddWithValue("@StudentId", StudentId);
                    dataCommand3.Parameters.AddWithValue("@CourseId", CourseId);
                    dataCommand3.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                    dataCommand3.ExecuteNonQuery();
                    cn.Close();
                }
                else if (i >= 5 && i < 75)
                {

                    StudentId = StudentId + 1;
                    string InsertRI = "INSERT INTO attendance.registerinformation (StudentId,CourseId,RegisterTime) VALUES (@StudentId,@CourseId,@RegisterTime);";

                    MySqlCommand dataCommand1 = new MySqlCommand(InsertRI, cn);
                    MySqlCommand dataCommand2 = new MySqlCommand(InsertRI, cn);
                    MySqlCommand dataCommand3 = new MySqlCommand(InsertRI, cn);

                    cn.Open();
                    CourseId = "1";
                    dataCommand1.Parameters.AddWithValue("@StudentId", StudentId);
                    dataCommand1.Parameters.AddWithValue("@CourseId", CourseId);
                    dataCommand1.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                    dataCommand1.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    CourseId = "3";
                    dataCommand2.Parameters.AddWithValue("@StudentId", StudentId);
                    dataCommand2.Parameters.AddWithValue("@CourseId", CourseId);
                    dataCommand2.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                    dataCommand2.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    CourseId = "6";
                    dataCommand3.Parameters.AddWithValue("@StudentId", StudentId);
                    dataCommand3.Parameters.AddWithValue("@CourseId", CourseId);
                    dataCommand3.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                    dataCommand3.ExecuteNonQuery();
                    cn.Close();

                }
                else if (i >= 75 && i < 100)
                {
                    CourseId = "6";
                    StudentId = StudentId + 1;
                    string InsertRI = "INSERT INTO attendance.registerinformation (StudentId,CourseId,RegisterTime) VALUES (@StudentId,@CourseId,@RegisterTime);";
                    MySqlCommand dataCommand3 = new MySqlCommand(InsertRI, cn);

                    cn.Open();
                    dataCommand3.Parameters.AddWithValue("@StudentId", StudentId);
                    dataCommand3.Parameters.AddWithValue("@CourseId", CourseId);
                    dataCommand3.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                    dataCommand3.ExecuteNonQuery();
                    cn.Close();
                }
                else if (i >= 100 && i < 120)
                {
                    CourseId = "3";
                    StudentId = StudentId + 1;
                    string InsertRI = "INSERT INTO attendance.registerinformation (StudentId,CourseId,RegisterTime) VALUES (@StudentId,@CourseId,@RegisterTime);";
                    MySqlCommand dataCommand3 = new MySqlCommand(InsertRI, cn);

                    cn.Open();
                    dataCommand3.Parameters.AddWithValue("@StudentId", StudentId);
                    dataCommand3.Parameters.AddWithValue("@CourseId", CourseId);
                    dataCommand3.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                    dataCommand3.ExecuteNonQuery();
                    cn.Close();

                }
                else if (i >= 120 && i < 200)
                {
                    CourseId = "2";
                    StudentId = StudentId + 1;
                    string InsertRI = "INSERT INTO attendance.registerinformation (StudentId,CourseId,RegisterTime) VALUES (@StudentId,@CourseId,@RegisterTime);";
                    MySqlCommand dataCommand3 = new MySqlCommand(InsertRI, cn);

                    cn.Open();
                    dataCommand3.Parameters.AddWithValue("@StudentId", StudentId);
                    dataCommand3.Parameters.AddWithValue("@CourseId", CourseId);
                    dataCommand3.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                    dataCommand3.ExecuteNonQuery();
                    cn.Close();

                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            bind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            //    {
            //        ((LinkButton)e.Row.Cells[13].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('Are you want to delete the record of：\"" + e.Row.Cells[2].Text + " " + e.Row.Cells[3].Text + "\"?')");
            //    }
            //}

            //}   
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }
        public void bind()
        {
            //string sqlstr = "select StudentId,FirstName, MatricNumber from attendance.student;";
            string sqlstr = "select StudentId,MatricNumber,FirstName, LastName,EmailAddress,Birthday,Gender,YearOfStudy,SchoolName,EPC from attendance.student where EPC>='1010101' and EPC<=101010200;";
            //string sqlstr = "select StudentId,FirstName from attendance.student;";
            //sqlcon = new SqlConnection(strCon);
            MySqlDataAdapter myda = new MySqlDataAdapter(sqlstr, cn);
            //mysqlDataSet myds = new DataSet();
            System.Data.DataSet my = new System.Data.DataSet();

            cn.Open();
            myda.Fill(my, "attendance.student");
            GridView1.DataSource = my;
            //GridView1.
            GridView1.DataKeyNames = new string[] { "MatricNumber" };//主键
            GridView1.DataBind();
            cn.Close();
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            bind();
        }


    }
}