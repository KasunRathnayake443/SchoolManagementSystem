using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace SchoolManagementSystem
{
    internal class AddStudentData
    {
        private readonly MySqlConnection connect;

        public AddStudentData()
        {
         
            connect = new MySqlConnection("Server=localhost;Database=sms;Uid=root;Pwd=;");
        }

        public int ID { get; set; }
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentGender { get; set; }
        public string StudentAddress { get; set; }
        public string StudentGrade { get; set; }
        public string StudentSection { get; set; }
        public string StudentImage { get; set; }
        public string Status { get; set; }
        public string DateInsert { get; set; }

   
        public List<AddStudentData> studentData()
        {
            List<AddStudentData> listData = new List<AddStudentData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string sql = "SELECT * FROM students WHERE date_delete IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connect))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AddStudentData addSD = new AddStudentData
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                StudentID = reader["student_id"].ToString(),
                                StudentName = reader["student_name"].ToString(),
                                StudentGender = reader["student_gender"].ToString(),
                                StudentAddress = reader["student_address"].ToString(),
                                StudentGrade = reader["student_grade"].ToString(),
                                StudentSection = reader["student_section"].ToString(),
                                StudentImage = reader["student_image"].ToString(),
                                Status = reader["student_status"].ToString(),
                                DateInsert = reader["date_insert"].ToString()
                            };

                            listData.Add(addSD);
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting to Database: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }

            return listData;
        }

       
        public List<AddStudentData> dashboardStudentData()
        {
            List<AddStudentData> listData = new List<AddStudentData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    DateTime today = DateTime.Today;

                    string sql = "SELECT * FROM students WHERE date_insert = @dateInsert AND date_delete IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connect))
                    {
                        cmd.Parameters.AddWithValue("@dateInsert", today.ToString("yyyy-MM-dd"));

                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AddStudentData addSD = new AddStudentData
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                StudentID = reader["student_id"].ToString(),
                                StudentName = reader["student_name"].ToString(),
                                StudentGender = reader["student_gender"].ToString(),
                                StudentAddress = reader["student_address"].ToString(),
                                StudentGrade = reader["student_grade"].ToString(),
                                StudentSection = reader["student_section"].ToString(),
                                StudentImage = reader["student_image"].ToString(),
                                Status = reader["student_status"].ToString(),
                                DateInsert = reader["date_insert"].ToString()
                            };

                            listData.Add(addSD);
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }

            return listData;
        }
    }
}
