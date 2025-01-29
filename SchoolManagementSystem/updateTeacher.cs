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
    public partial class updateTeacher : Form
    {
        private MySqlConnection connection;
        private string teacherRowId;
        public updateTeacher(string id, string teacherId, string name, string gender, string address, string status)
        {
            InitializeComponent();

            teacherRowId = id;
            teacher_id.Text = teacherId;
            teacher_name.Text = name;
            teacher_gender.Text = gender;
            teacher_address.Text = address;
            teacher_status.Text = status;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateTeacher_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void tteacher_updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = @"
                UPDATE teachers 
                SET teacher_id = @teacherId,
                    teacher_name = @name, 
                    teacher_gender = @gender, 
                    teacher_address = @address, 
                    teacher_status = @status 
                WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", teacherRowId);
                    cmd.Parameters.AddWithValue("@teacherId", teacher_id.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", teacher_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", teacher_gender.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", teacher_address.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", teacher_status.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Teacher updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No teacher record updated. Please verify the ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating teacher: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
