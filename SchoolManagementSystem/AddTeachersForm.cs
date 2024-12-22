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

            teacherDisplayData();
        }

        private void AddTeachersForm_Load(object sender, EventArgs e)
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

        public void teacherDisplayData()
        {
            AddTeachersData addTD = new AddTeachersData();

            teacher_gridData.DataSource = addTD.teacherData();
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

            if (teacher_id.Text == ""
                || teacher_name.Text == ""
                || teacher_gender.Text == ""
                || teacher_address.Text == ""
                || teacher_status.Text == ""
                || teacher_image.Image == null
                || imagePath == null)

            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //else
            //{
            //    if(connect.State != ConnectionState.Open)
            //    {
            //        try
            //        {
            //            connect.Open();

            //            DialogResult check = MessageBox.Show("Are you want to update Teacher ID: "
            //                + teacher_id.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //            if(check == DialogResult.Yes)
            //            {
            //                DateTime today = DateTime.Today;

            //                String updateData = "UPDATE teachers SET " +
            //                    "teacher_name = @teacherName, teacher_gender = @teacherGender" +
            //                    ", teacher_address = @teacherAddress" +
            //                    ", teacher_status = @teacherStatus" +
            //                    ",date_update = @dateUpdate WHERE teacher_id = @teacherID";

                      

            //                using (SqlCommand cmd = new SqlCommand(updateData, connect))
            //                {
            //                    cmd.Parameters.AddWithValue("@teacherName", teacher_name.Text.Trim());
            //                    cmd.Parameters.AddWithValue("@teacherGender", teacher_gender.Text.Trim());
            //                    cmd.Parameters.AddWithValue("@teacherAddress", teacher_address.Text.Trim());
            //                    cmd.Parameters.AddWithValue("@teacherStatus", teacher_status.Text.Trim());
            //                    cmd.Parameters.AddWithValue("@dateUpdate", today.ToString());
            //                    cmd.Parameters.AddWithValue("@teacherID", teacher_id.Text.Trim());


            //                    cmd.ExecuteNonQuery();

            //                    teacherDisplayData();


            //                    MessageBox.Show("Updated Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                    clearFields();
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Cancelled", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                clearFields();
            //            }

            //        }
            //        catch(Exception ex)
            //        {
            //            MessageBox.Show("Error connecting database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        }
            //        finally
            //        {
            //            connect.Close();

            //        }
            //    }
            //}
            }

        private void teacher_gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            if(e.RowIndex != -1)
            {
                DataGridViewRow row = teacher_gridData.Rows[e.RowIndex];
                teacher_id.Text = row.Cells[1].Value.ToString();
                teacher_name.Text = row.Cells[2].Value.ToString();
                teacher_gender.Text = row.Cells[3].Value.ToString();
                teacher_address.Text = row.Cells[4].Value.ToString();

                imagePath = row.Cells[5].Value.ToString();

                string imageData = row.Cells[5].Value.ToString();

                if(imageData != null && imageData.Length > 0)
                {
                    
                        teacher_image.Image = Image.FromFile(imageData);

                    
                }
                else
                {
                    teacher_image.Image = null;
                }

                teacher_status.Text = row.Cells[6].Value.ToString();
                




            }
        }

        private void teacher_deleteBtn_Click(object sender, EventArgs e)
        {
            if(teacher_id.Text == "")
            {
                MessageBox.Show("Please select item first", "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
            //    if(connect.State != ConnectionState.Open)
            //    {
            //        DialogResult check = MessageBox.Show("Are you want to Delete Teacher ID: "
            //            + teacher_id.Text + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //        if(check == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                connect.Open();
            //                DateTime today = DateTime.Today;


            //                string deleteData = "UPDATE teachers SET date_delete = @dateDelete" +
            //                    " WHERE teacher_id = @teacherID";

            //                using (SqlCommand cmd = new SqlCommand(deleteData, connect))
            //                {
            //                    cmd.Parameters.AddWithValue("@dateDelete", today.ToString());
            //                    cmd.Parameters.AddWithValue("@teacherID", teacher_id.Text.Trim());

            //                    cmd.ExecuteNonQuery();

            //                    teacherDisplayData();


            //                    MessageBox.Show("Deleted Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //                    clearFields();

            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Error connecting Database: " + ex, "Error Message"
            //          , MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            finally
            //            {
            //                connect.Close();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Cancelled", "Information Message"
            //        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

                    
            //    }
            }
        }

        private void teacher_gridData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
