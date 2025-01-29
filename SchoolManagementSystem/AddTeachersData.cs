using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    internal class AddTeachersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sac\Documents\school.mdf;Integrated Security=True;Connect Timeout=30");
        public int ID { set; get;  }
       
        public string TeacherID { set; get; }
       
        public string TeacherName { set; get; }

        public string TeacherGender { set; get; }

        public string TeacherAddress { set; get; }

        public string TeacherImage { set; get; }

        public string Status { set; get; }

        public string DateInsert { set; get; }

       


    }
}
