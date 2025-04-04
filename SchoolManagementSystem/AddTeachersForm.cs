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
                LoadTeacherIDsToSearchBox();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTeacherIDsToSearchBox()
        {
            try
            {
                string query = "SELECT teacher_id FROM teachers WHERE date_delete IS NULL;";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

                while (reader.Read())
                {
                    autoComplete.Add(reader["teacher_id"].ToString());
                }

                reader.Close();

                searchBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                searchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                searchBox.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load teacher IDs: " + ex.Message);
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
                )

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
                                LoadTeacherIDsToSearchBox();


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
            if (teacherDataGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = teacherDataGrid.SelectedRows[0];

                string id = selectedRow.Cells["id"].Value.ToString();
                string teacherId = selectedRow.Cells["teacher_id"].Value.ToString();
                string name = selectedRow.Cells["teacher_name"].Value.ToString();
                string gender = selectedRow.Cells["teacher_gender"].Value.ToString();
                string address = selectedRow.Cells["teacher_address"].Value.ToString();
                string status = selectedRow.Cells["teacher_status"].Value.ToString();

                
                updateTeacher updateForm = new updateTeacher(id, teacherId, name, gender, address, status);
                updateForm.ShowDialog();

                
                teacherDisplayData();
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void teacher_gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {



           
        }

        private void teacher_deleteBtn_Click(object sender, EventArgs e)
        {
            if (teacherDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string selectedTeacherId = teacherDataGrid.SelectedRows[0].Cells["teacher_id"].Value.ToString();

         
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this teacher?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM teachers WHERE teacher_id = @teacherId";

                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@teacherId", selectedTeacherId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Teacher deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                        teacherDisplayData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting teacher: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void teacher_gridData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showAll_Click(object sender, EventArgs e)
        {
            teacherDisplayData();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string teacherId = searchBox.Text.Trim();

            if (string.IsNullOrEmpty(teacherId))
            {
                MessageBox.Show("Please enter a teacher ID to search.");
                return;
            }

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
        WHERE date_delete IS NULL AND teacher_id = @teacher_id;
        ";

                DataTable teacherTable = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@teacher_id", teacherId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(teacherTable);
                    }
                }

                teacherDataGrid.DataSource = teacherTable;

                if (teacherTable.Rows.Count > 0)
                {
                    teacherDataGrid.Columns["id"].HeaderText = "ID";
                    teacherDataGrid.Columns["teacher_id"].HeaderText = "Teacher ID";
                    teacherDataGrid.Columns["teacher_name"].HeaderText = "Name";
                    teacherDataGrid.Columns["teacher_gender"].HeaderText = "Gender";
                    teacherDataGrid.Columns["teacher_address"].HeaderText = "Address";
                    teacherDataGrid.Columns["teacher_status"].HeaderText = "Status";
                    teacherDataGrid.Columns["date_insert"].HeaderText = "Inserted On";
                }
                else
                {
                    MessageBox.Show("No teacher found with that ID.");
                }

                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message);
            }
        }
    }
}
