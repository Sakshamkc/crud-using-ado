using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace database
{
    class studentdb
    {
        public int InsertStudent(string name, string email, string phone)
        {
            SqlConnection con = new SqlConnection("Data Source =(LocalDB)\\MSSQLLocalDB;Integrated Security = True;Initial Catalog = Saksham");
            SqlCommand cmd = new SqlCommand("insert into tblstudent values(@name,@email,@phone)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int DeleteStudent(int studentId)
        {
            SqlConnection con = new SqlConnection("Data source =(LocalDB)\\MSSQLLocalDB;Integrated Security = True; Initial Catalog = Saksham");
            SqlCommand cmd = new SqlCommand("Delete from tblstudent where studentId=@studentId", con);
            cmd.Parameters.AddWithValue("@studentID", studentId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int UpdateStudent(string fullname,string email,string phone,int studentId)
        {
            SqlConnection con = new SqlConnection("Data source =(LocalDB)\\MSSQLLocalDB;Integrated Security = True; Initial Catalog = Saksham");
            SqlCommand cmd = new SqlCommand("update tblstudent set fullname=@fullname,email=@email,phone=@phone where studentId=@studentId", con);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@studentID", studentId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable GetAllStudent()
        {
            SqlConnection con = new SqlConnection("Data source =(LocalDB)\\MSSQLLocalDB;Integrated Security = True; Initial Catalog = Saksham");
            SqlCommand cmd = new SqlCommand("Select *from tblstudent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List <student> GetAllStudentDataReader()
        {
            List<student> lst = new List<student>();
            SqlConnection con = new SqlConnection("Data source =(LocalDB)\\MSSQLLocalDB;Integrated Security = True; Initial Catalog = Saksham");
            SqlCommand cmd = new SqlCommand("Select *from tblstudent", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                lst.Add(new student() { studentId = (int)dr["studentId"], fullname = (string)dr["fullname"], email = (string)dr["email"], phone = (string)dr["phone"] });
            }
            dr.Close();
            con.Close();
            return lst;
        }
    }
}
