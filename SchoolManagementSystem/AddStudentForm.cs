using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SchoolManagementSystem
{
    public partial class AddStudentForm : UserControl
    {
        private MySqlConnection connection;

        public AddStudentForm()
        {
            InitializeComponent();

            displayStudentData();
        }

        public void displayStudentData()
        {
            
        }

      

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(student_id.Text) ||
       string.IsNullOrWhiteSpace(student_name.Text) ||
       student_gender.SelectedIndex == -1 ||
       string.IsNullOrWhiteSpace(student_address.Text) ||
       student_grade.SelectedIndex == -1 ||
       student_section.SelectedIndex == -1 ||
       student_status.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string studentID = student_id.Text.Trim();
            string studentName = student_name.Text.Trim();
            string studentGender = student_gender.SelectedItem.ToString();
            string studentAddress = student_address.Text.Trim();
            string studentGrade = student_grade.SelectedItem.ToString();
            string studentSection = student_section.SelectedItem.ToString();
            string studentStatus = student_status.SelectedItem.ToString();

            try
            {
               
                string checkQuery = "SELECT student_id FROM students WHERE student_id = @studentID";

                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@studentID", studentID);

                    using (MySqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Student ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            reader.Close();
                            return;
                        }
                        reader.Close();
                    }
                }

            
                string insertQuery = @"
            INSERT INTO students
            (student_id, student_name, student_gender, student_address, student_grade, student_section, student_status, date_insert)
            VALUES 
            (@studentID, @studentName, @studentGender, @studentAddress, @studentGrade, @studentSection, @studentStatus, @insertDate)
        ";

                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@studentID", studentID);
                    insertCmd.Parameters.AddWithValue("@studentName", studentName);
                    insertCmd.Parameters.AddWithValue("@studentGender", studentGender);
                    insertCmd.Parameters.AddWithValue("@studentAddress", studentAddress);
                    insertCmd.Parameters.AddWithValue("@studentGrade", studentGrade);
                    insertCmd.Parameters.AddWithValue("@studentSection", studentSection);
                    insertCmd.Parameters.AddWithValue("@studentStatus", studentStatus);
                    insertCmd.Parameters.AddWithValue("@insertDate", DateTime.Now);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 
                    studentDisplayData();
                    clearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        public void clearFields()
        {
            student_id.Text = "";
            student_name.Text = "";
            student_gender.SelectedIndex = -1;
            student_address.Text = "";
            student_grade.SelectedIndex = -1;
            student_section.SelectedIndex = -1;
            student_status.SelectedIndex = -1;
            
        }

        public string imagePath;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg; *.png)|*.jpg;*.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                imagePath = open.FileName;

                student_image.ImageLocation = imagePath;
            }
        }

        private void student_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void student_updateBtn_Click(object sender, EventArgs e)
        {
           
                
            
        }

        private void student_studentData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void student_deleteBtn_Click(object sender, EventArgs e)
        {
            if (studentGri.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = studentGri.SelectedRows[0];
                string studentID = selectedRow.Cells["student_id"].Value.ToString();

                DialogResult confirmDelete = MessageBox.Show(
                    $"Are you sure you want to delete the student with ID: {studentID}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmDelete == DialogResult.Yes)
                {
                    try
                    {
                       
                        string deleteQuery = "DELETE FROM students WHERE student_id = @studentID";

                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@studentID", studentID);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                         
                            studentDisplayData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();

                studentDisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void studentDisplayData()
        {
            try
            {
               
                string query = @"
            SELECT 
                id, 
                student_id, 
                student_name, 
                student_gender, 
                student_address, 
                student_grade, 
                student_section, 
                student_status, 
                IFNULL(date_insert, '') AS date_insert
            FROM students
            WHERE date_delete IS NULL;
        ";

                DataTable studentTable = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(studentTable);
                    }
                }

               
                studentGri.DataSource = studentTable;

             
                studentGri.Columns["id"].HeaderText = "ID";
                studentGri.Columns["student_id"].HeaderText = "Student ID";
                studentGri.Columns["student_name"].HeaderText = "Name";
                studentGri.Columns["student_gender"].HeaderText = "Gender";
                studentGri.Columns["student_address"].HeaderText = "Address";
                studentGri.Columns["student_grade"].HeaderText = "Grade";
                studentGri.Columns["student_section"].HeaderText = "Section";
                studentGri.Columns["student_status"].HeaderText = "Status";
                studentGri.Columns["date_insert"].HeaderText = "Inserted On";

                
                CustomizeStudentGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeStudentGridView()
        {
            studentGri.EnableHeadersVisualStyles = false;
            studentGri.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(4, 87, 122);
            studentGri.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            studentGri.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            studentGri.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            studentGri.DefaultCellStyle.BackColor = Color.White;
            studentGri.DefaultCellStyle.ForeColor = Color.Black;
            studentGri.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            studentGri.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            studentGri.DefaultCellStyle.SelectionForeColor = Color.Black;

            studentGri.GridColor = Color.Gray;
            studentGri.BorderStyle = BorderStyle.None;

            studentGri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            studentGri.RowHeadersVisible = false;
            studentGri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentGri.AllowUserToAddRows = false;
        }

    }
}
