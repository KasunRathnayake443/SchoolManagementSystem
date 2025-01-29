using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem
{
    public partial class updateStudent : Form
    {
        private MySqlConnection connection;
        private string studentRowId;
        public updateStudent(string Id, string Studentid, string name, string gender,
        string address, string grade, string section,
        string status)
        {
            InitializeComponent();

            studentRowId = Id;
            student_id.Text = Studentid;
            student_name.Text = name;
            student_gender.Text = gender;
            student_address.Text = address;
            student_grade.Text = grade;
            student_section.Text = section;
            student_status.Text = status;
        }

        private void updateStudent_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void student_updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = @"
                UPDATE students 
                SET student_name = @name, 
                    student_gender = @gender, 
                    student_address = @address, 
                    student_grade = @grade, 
                    student_section = @section, 
                    student_status = @status 
                WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", studentRowId);
                    cmd.Parameters.AddWithValue("@name", student_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", student_gender.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", student_address.Text.Trim());
                    cmd.Parameters.AddWithValue("@grade", student_grade.Text.Trim());
                    cmd.Parameters.AddWithValue("@section", student_section.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", student_status.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
