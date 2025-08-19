using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_1
{
    public partial class Requerements : Form
    {
        private int _instructorId;
        public Requerements( int instructorId)
        {
            InitializeComponent();
            _instructorId = instructorId;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"
            SELECT TOP 1 c.course_id, c.Name, COUNT(e.enrollment_id) AS NumberOfStudents  
            FROM Course c LEFT JOIN Enrollment e ON c.course_id = e.course_id  
            GROUP BY c.course_id, c.Name  
            ORDER BY NumberOfStudents DESC; ";

            LoadReport(query);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"SELECT course_id, Name, semester, is_Active 
            FROM Course 
            WHERE is_Active = 0; ";
            LoadReport(query);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = @"WITH RankedStudents AS ( SELECT c.course_id, c.Name AS 
course_name, s.student_id, s.firstname, s.lastname, e.CourseGrade, 
ROW_NUMBER() OVER ( PARTITION BY c.course_id ORDER BY e.CourseGrade 
DESC )  
AS rank  
FROM Enrollment e JOIN Course c  
ON e.course_id = c.course_id  
JOIN Student s  
ON e.student_id = s.student_id WHERE c.StudyingYear = 
'2025' )  
SELECT course_id, course_name, student_id, firstname, 
lastname, CourseGrade FROM RankedStudents  
WHERE rank <= 5  
ORDER BY course_id, CourseGrade desc, rank; ";
            LoadReport(query);
        }

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    string query = @"
        //    SELECT TOP 1 Category, COUNT(*) AS CourseCount
        //    FROM Course
        //    GROUP BY Category
        //    ORDER BY CourseCount ASC";

        //    LoadReport(query);
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            string query = @"
            SELECT TOP 1 c.Category, COUNT(e.enrollment_id) AS NumberOfStudents  
            FROM Course c LEFT JOIN Enrollment e  
            ON c.course_id = e.course_id  
            GROUP BY c.Category  
            ORDER BY NumberOfStudents ASC; ";

            LoadReport(query);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = @"
            SELECT DISTINCT s.student_id, s.firstname, s.lastname  
FROM Student s INNER JOIN Enrollment e  
ON s.student_id = e.student_id  
WHERE e.course_id = 5 -- specify the course 
 and not exists (
 select 1 from 
 ExamScore es  
inner JOIN Exam ex on ex.exam_id = es.exam_id  
where s.student_id = es.student_id and e.course_id = ex.course_id)";

            LoadReport(query);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = @"
            SELECT c.Name AS CourseName, COUNT(DISTINCT ex.exam_id) 
            AS NumberOfExams, MAX(es.Grade) AS HighestGrade  
            FROM Course c LEFT JOIN Exam ex  
            ON c.course_id = ex.course_id  
            LEFT JOIN ExamScore es  
            ON ex.exam_id = es.exam_id  
            GROUP BY c.Name  
            ORDER BY c.Name; ";

            LoadReport(query);
        }
        private void LoadReport(string query)
        {
            string connectionString = @"Server=.; Database=CourseManagementSystem; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DGV_Requerements.DataSource = dt;
            }
        }

        private void B_Back_Click(object sender, EventArgs e)
        {
            TeacherHome F1 = new TeacherHome(_instructorId);
            F1.Show();
            this.Hide();
        }
    }
}
