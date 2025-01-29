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
                // Query to fetch all student records where date_delete is null
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

                // Bind data to the DataGridView
                studentGrisss.DataSource = studentTable;

                // Set custom headers
                studentGrisss.Columns["id"].HeaderText = "ID";
                studentGrisss.Columns["student_id"].HeaderText = "Student ID";
                studentGrisss.Columns["student_name"].HeaderText = "Name";
                studentGrisss.Columns["student_gender"].HeaderText = "Gender";
                studentGrisss.Columns["student_address"].HeaderText = "Address";
                studentGrisss.Columns["student_grade"].HeaderText = "Grade";
                studentGrisss.Columns["student_section"].HeaderText = "Section";
                studentGrisss.Columns["student_status"].HeaderText = "Status";
                studentGrisss.Columns["date_insert"].HeaderText = "Inserted On";

                // Apply grid customization
                CustomizeStudentGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeStudentGridView()
        {
            studentGrisss.EnableHeadersVisualStyles = false;
            studentGrisss.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(4, 87, 122);
            studentGrisss.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            studentGrisss.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            studentGrisss.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            studentGrisss.DefaultCellStyle.BackColor = Color.White;
            studentGrisss.DefaultCellStyle.ForeColor = Color.Black;
            studentGrisss.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            studentGrisss.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            studentGrisss.DefaultCellStyle.SelectionForeColor = Color.Black;

            studentGrisss.GridColor = Color.Gray;
            studentGrisss.BorderStyle = BorderStyle.None;

            studentGrisss.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            studentGrisss.RowHeadersVisible = false;
            studentGrisss.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentGrisss.AllowUserToAddRows = false;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void studentGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
