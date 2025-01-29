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

   
        
    }
}
