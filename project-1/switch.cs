using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_1
{
    public partial class @switch : Form
    {
        public @switch()
        {
            InitializeComponent();
        }

        private void B_Enter_Click(object sender, EventArgs e)
        {
            if (CB_STUDENT.Checked) 
            {
                this.Hide();
                F_STUDENT_R studentForm = new F_STUDENT_R();
                studentForm.Show();
               
            }
            else if (CB_TEACHER.Checked)
            {
                this.Hide();
                Instructor_Registration F1 = new Instructor_Registration();
                F1.Show();
               
            }
            else
            {
                MessageBox.Show("Please select STUDENT or TEACHER before continuing.");
            }
        }

        private void switch_Load(object sender, EventArgs e)
        {

        }
    }
}
