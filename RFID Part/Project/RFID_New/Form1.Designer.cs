namespace RFID_New
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.ClassTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.ClassID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ClassDate = new System.Windows.Forms.ComboBox();
            this.Semester = new System.Windows.Forms.ComboBox();
            this.CourseName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TeachingYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CourseCode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClassTime
            // 
            this.ClassTime.AutoSize = true;
            this.ClassTime.Location = new System.Drawing.Point(327, 155);
            this.ClassTime.Name = "ClassTime";
            this.ClassTime.Size = new System.Drawing.Size(0, 13);
            this.ClassTime.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Course Time : ";
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.Location = new System.Drawing.Point(143, 188);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.ErrorMessage.TabIndex = 30;
            // 
            // ClassID
            // 
            this.ClassID.AutoSize = true;
            this.ClassID.Location = new System.Drawing.Point(324, 117);
            this.ClassID.Name = "ClassID";
            this.ClassID.Size = new System.Drawing.Size(0, 13);
            this.ClassID.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Class ID : ";
            // 
            // ClassDate
            // 
            this.ClassDate.FormattingEnabled = true;
            this.ClassDate.Location = new System.Drawing.Point(128, 153);
            this.ClassDate.Name = "ClassDate";
            this.ClassDate.Size = new System.Drawing.Size(121, 21);
            this.ClassDate.TabIndex = 27;
            this.ClassDate.SelectedIndexChanged += new System.EventHandler(this.ClassDate_SelectedIndexChanged);
            // 
            // Semester
            // 
            this.Semester.FormattingEnabled = true;
            this.Semester.Location = new System.Drawing.Point(128, 101);
            this.Semester.Name = "Semester";
            this.Semester.Size = new System.Drawing.Size(121, 21);
            this.Semester.TabIndex = 26;
            this.Semester.SelectedIndexChanged += new System.EventHandler(this.Semester_SelectedIndexChanged);
            // 
            // CourseName
            // 
            this.CourseName.AutoSize = true;
            this.CourseName.Location = new System.Drawing.Point(256, 93);
            this.CourseName.Name = "CourseName";
            this.CourseName.Size = new System.Drawing.Size(0, 13);
            this.CourseName.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Course Name : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Class Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Semester :";
            // 
            // TeachingYear
            // 
            this.TeachingYear.FormattingEnabled = true;
            this.TeachingYear.Location = new System.Drawing.Point(128, 76);
            this.TeachingYear.Name = "TeachingYear";
            this.TeachingYear.Size = new System.Drawing.Size(121, 21);
            this.TeachingYear.TabIndex = 21;
            this.TeachingYear.SelectedIndexChanged += new System.EventHandler(this.TeachingYear_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Teaching Year :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 48);
            this.label2.TabIndex = 19;
            this.label2.Text = "RFID-enabled Smart Attendance System\r\n                       RFID Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Course Code :";
            // 
            // CourseCode
            // 
            this.CourseCode.FormattingEnabled = true;
            this.CourseCode.Location = new System.Drawing.Point(128, 126);
            this.CourseCode.Name = "CourseCode";
            this.CourseCode.Size = new System.Drawing.Size(121, 21);
            this.CourseCode.TabIndex = 17;
            this.CourseCode.SelectedIndexChanged += new System.EventHandler(this.CourseCode_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 313);
            this.Controls.Add(this.ClassTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.ClassID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ClassDate);
            this.Controls.Add(this.Semester);
            this.Controls.Add(this.CourseName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TeachingYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CourseCode);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ClassTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ErrorMessage;
        private System.Windows.Forms.Label ClassID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ClassDate;
        private System.Windows.Forms.ComboBox Semester;
        private System.Windows.Forms.Label CourseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TeachingYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CourseCode;
    }
}

