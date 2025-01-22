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
    public partial class AddStudentsForm : Form
    {

        private MySqlConnection connection;
        public AddStudentsForm()
        {
            InitializeComponent();
        }

        private void student_importBtn_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void AddStudentsForm_Load(object sender, EventArgs e)
        {

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();

                DisplayStudentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }


        private void DisplayStudentData()
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

                // DataTable to hold student data
                DataTable studentTable = new DataTable();

                // Create MySqlCommand with an open connection
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Use MySqlDataAdapter to fill DataTable
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(studentTable);
                    }
                }

                // Bind DataTable to DataGridView
                studentGridView.DataSource = studentTable;

                // Customize column headers
                studentGridView.Columns["id"].HeaderText = "ID";
                studentGridView.Columns["student_id"].HeaderText = "Student ID";
                studentGridView.Columns["student_name"].HeaderText = "Name";
                studentGridView.Columns["student_gender"].HeaderText = "Gender";
                studentGridView.Columns["student_address"].HeaderText = "Address";
                studentGridView.Columns["student_grade"].HeaderText = "Grade";
                studentGridView.Columns["student_section"].HeaderText = "Section";
                studentGridView.Columns["student_status"].HeaderText = "Status";
                studentGridView.Columns["date_insert"].HeaderText = "Inserted On";

                // Apply styling
                CustomizeStudentGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeStudentGridView()
        {
            // Header style
            studentGridView.EnableHeadersVisualStyles = false;
            studentGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(4, 87, 122);
            studentGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            studentGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            studentGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Rows style
            studentGridView.DefaultCellStyle.BackColor = Color.White;
            studentGridView.DefaultCellStyle.ForeColor = Color.Black;
            studentGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            studentGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            studentGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Grid style
            studentGridView.GridColor = Color.Gray;
            studentGridView.BorderStyle = BorderStyle.None;

            // Other settings
            studentGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            studentGridView.RowHeadersVisible = false;
            studentGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentGridView.AllowUserToAddRows = false;
        }

    }
}
