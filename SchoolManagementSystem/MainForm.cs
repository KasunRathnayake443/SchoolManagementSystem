using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(check == DialogResult.Yes)
            {
                LoginForm form1 = new LoginForm();
                form1.Show();
                this.Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DashboardForm dForm = new DashboardForm();
            dForm.displayEntrolledStudentToday();
          

           


            dashboardForm1.Visible = true;
            dashboardForm1.Update();
            addStudentForm1.Visible = false;
            addTeachersForm1.Visible = false;
        }

        private void AddStudent_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            addStudentForm1.Visible = true;
            addStudentForm1.Update();
            addTeachersForm1.Visible = false;
        }

        private void AddTeacher_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            addStudentForm1.Visible = false;
            addTeachersForm1.Visible = true;
            addTeachersForm1.Update();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboardForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
