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

                    displayEntrolledStudentToday();

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
            AddStudentData asData = new AddStudentData();

            dataGridView1.DataSource = asData.dashboardStudentData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
