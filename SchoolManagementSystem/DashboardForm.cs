using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SchoolManagementSystem
{
    public partial class DashboardForm : UserControl
    {

    

        public DashboardForm()
        {
            InitializeComponent();


        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    displayTotalES(connection);
                    displayTotalTT(connection);
                    displayTotalGS(connection);
                    ShowTodayEnrolledStudents(connection);



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void displayTotalES(MySqlConnection connection)
        {
            try
            {
                string selectData = "SELECT COUNT(id) FROM students WHERE student_status = 'Entrolled' AND date_delete IS NULL";

                using (MySqlCommand cmd = new MySqlCommand(selectData, connection))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int tempES = 0;
                    if (reader.Read())
                    {
                        tempES = Convert.ToInt32(reader[0]);
                        total_ES.Text = tempES.ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to connect Database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayTotalTT(MySqlConnection connection)
        {
            try
            {
                string selectData = "SELECT COUNT(id) FROM teachers WHERE teacher_status = 'Active' AND date_delete IS NULL";

                using (MySqlCommand cmd = new MySqlCommand(selectData, connection))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int tempTT = 0;
                    if (reader.Read())
                    {
                        tempTT = Convert.ToInt32(reader[0]);
                        total_TT.Text = tempTT.ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to connect Database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayTotalGS(MySqlConnection connection)
        {
            try
            {
                string selectData = "SELECT COUNT(id) FROM students WHERE student_status = 'Graduated' AND date_delete IS NULL";

                using (MySqlCommand cmd = new MySqlCommand(selectData, connection))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int tempGS = 0;
                    if (reader.Read())
                    {
                        tempGS = Convert.ToInt32(reader[0]);
                        total_GS.Text = tempGS.ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to connect Database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayEntrolledStudentToday()
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowTodayEnrolledStudents(MySqlConnection connection)
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
                date_insert 
            FROM students 
            WHERE DATE(date_insert) = CURDATE();";

                DataTable todayStudentsTable = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(todayStudentsTable);
                    }
                }

                enrollTodayStudents.DataSource = todayStudentsTable;

               
                enrollTodayStudents.Columns["id"].HeaderText = "ID";
                enrollTodayStudents.Columns["student_id"].HeaderText = "Student ID";
                enrollTodayStudents.Columns["student_name"].HeaderText = "Name";
                enrollTodayStudents.Columns["student_gender"].HeaderText = "Gender";
                enrollTodayStudents.Columns["student_address"].HeaderText = "Address";
                enrollTodayStudents.Columns["student_grade"].HeaderText = "Grade";
                enrollTodayStudents.Columns["student_section"].HeaderText = "Section";
                enrollTodayStudents.Columns["student_status"].HeaderText = "Status";
                enrollTodayStudents.Columns["date_insert"].HeaderText = "Enrollment Date";

                CustomizeEnrollTodayGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching today's enrolled students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeEnrollTodayGridView()
        {
            enrollTodayStudents.EnableHeadersVisualStyles = false;
            enrollTodayStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            enrollTodayStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            enrollTodayStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            enrollTodayStudents.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            enrollTodayStudents.DefaultCellStyle.SelectionForeColor = Color.Black;

            enrollTodayStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            enrollTodayStudents.RowHeadersVisible = false;
            enrollTodayStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            enrollTodayStudents.AllowUserToAddRows = false;
        }

    }
}
