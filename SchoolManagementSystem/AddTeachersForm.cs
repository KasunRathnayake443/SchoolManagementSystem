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
    public partial class AddTeachersForm : UserControl
    {
        private MySqlConnection connection;


        public AddTeachersForm()
        {
            InitializeComponent();

         
        }

        public void AddTeachersForm_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();

                teacherDisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void teacherDisplayData()
        {
            try
            {
                
                string query = @"
        SELECT 
            id, 
            teacher_id, 
            teacher_name, 
            teacher_gender, 
            teacher_address,  
            teacher_status, 
            IFNULL(date_insert, '') AS date_insert
           
        FROM teachers
        WHERE date_delete IS NULL;
        ";

                
                DataTable teacherTable = new DataTable();

              
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(teacherTable);
                    }
                }

               
                teacherDataGrid.DataSource = teacherTable;

              
                teacherDataGrid.Columns["id"].HeaderText = "ID";
                teacherDataGrid.Columns["teacher_id"].HeaderText = "Teacher ID";
                teacherDataGrid.Columns["teacher_name"].HeaderText = "Name";
                teacherDataGrid.Columns["teacher_gender"].HeaderText = "Gender";
                teacherDataGrid.Columns["teacher_address"].HeaderText = "Address";
                teacherDataGrid.Columns["teacher_status"].HeaderText = "Status";
                teacherDataGrid.Columns["date_insert"].HeaderText = "Inserted On";
                

               
                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching teacher data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
           
            teacherDataGrid.EnableHeadersVisualStyles = false;
            teacherDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(4, 87, 122);
            teacherDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            teacherDataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            teacherDataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           
            teacherDataGrid.DefaultCellStyle.BackColor = Color.White;
            teacherDataGrid.DefaultCellStyle.ForeColor = Color.Black;
            teacherDataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            teacherDataGrid.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            teacherDataGrid.DefaultCellStyle.SelectionForeColor = Color.Black;

         
            teacherDataGrid.GridColor = Color.Gray;
            teacherDataGrid.BorderStyle = BorderStyle.None;

            teacherDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            teacherDataGrid.RowHeadersVisible = false;
            teacherDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            teacherDataGrid.AllowUserToAddRows = false;
        }



        private void teacher_addBtn_Click(object sender, EventArgs e)
        {
           

            if (teacher_id.Text == ""
                || teacher_name.Text == ""
                || teacher_gender.Text == ""
                || teacher_address.Text == ""
                || teacher_status.Text == ""
                || teacher_image.Image == null
                || imagePath == null)

            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               string teacherID = teacher_id.Text.Trim();
                string teacherName = teacher_name.Text.Trim();
                string teacherGender = teacher_gender.Text.Trim();
                string teacherAddress = teacher_address.Text.Trim();
                string teacherStatus = teacher_status.Text.Trim();

                string checkid = "SELECT teacher_id FROM teachers WHERE teacher_id = @teacherID";

                using (MySqlCommand cmd = new MySqlCommand(checkid, connection))
                {
                    cmd.Parameters.AddWithValue("@teacherID", teacherID);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show("Teacher ID already exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reader.Close();
                    }
                    else
                    {
                        reader.Close();

                        try
                        {
                            DateTime today = DateTime.Today;

                            string insertData = "INSERT INTO teachers(teacher_id, teacher_name, teacher_gender, teacher_address, teacher_status, date_insert) VALUES (@teacherId, @teacherName, @teacherGender, @teacherAddress, @teacherStatus, @today)";

                            using (MySqlCommand cmd2 = new MySqlCommand(insertData, connection))
                            {
                                cmd2.Parameters.AddWithValue("@teacherId", teacherID);
                                cmd2.Parameters.AddWithValue("@teacherName", teacherName);
                                cmd2.Parameters.AddWithValue("@teacherGender", teacherGender);
                                cmd2.Parameters.AddWithValue("@teacherAddress", teacherAddress);
                                cmd2.Parameters.AddWithValue("@teacherStatus", teacherStatus);
                                cmd2.Parameters.AddWithValue("@today", today);

                                cmd2.ExecuteNonQuery();

                                teacherDisplayData();

                                MessageBox.Show("Teacher Added Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clearFields();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error connecting database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

       






        public void clearFields()
        {
            teacher_id.Text = "";
            teacher_name.Text = "";
            teacher_gender.SelectedIndex = -1;
            teacher_address.Text = "";
            teacher_status.SelectedIndex = -1;
            teacher_image.Image = null;
            imagePath = "";
        }

        private string imagePath;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg; *.png)|*.jpg;*.png";

            if(open.ShowDialog() == DialogResult.OK)
            {
                imagePath = open.FileName;

                teacher_image.ImageLocation = imagePath;
            }
        }

        private void teacher_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void tteacher_updateBtn_Click(object sender, EventArgs e)
        {

            
            }

        private void teacher_gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {



           
        }

        private void teacher_deleteBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void teacher_gridData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
