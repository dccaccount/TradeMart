using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Profile;
using TradeMart.Model;

namespace TradeMart
{
    public class DBContextEntity
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        DataTable dt;

        public DBContextEntity()
        {
            con = new SqlConnection("initial catalog= Agent; data source=DESKTOP-JCP2IJ3; Integrated Security=True;");
        }

        public DataTable Insert_Agent_Details(List<RegisterModel> agent)
        {
            dt = new DataTable();
            foreach (var res in agent)
            {
                da = new SqlDataAdapter("SP_Insert_Agent_Details", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@agentname", SqlDbType.NVarChar).Value = res.AgentName;
                da.SelectCommand.Parameters.Add("@dob", SqlDbType.NVarChar).Value = res.DOB;
                da.SelectCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = res.Email;
                da.SelectCommand.Parameters.Add("@phone", SqlDbType.NVarChar).Value = res.Phone;
                da.SelectCommand.Parameters.Add("@location", SqlDbType.NVarChar).Value = res.Location;
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return dt;
        }

        public object Agent_email_validate(string email)
        {
            cmd = new SqlCommand("SP_Insert_Agent_email_Validate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            con.Open();
            var result = cmd.ExecuteScalar();
            con.Close();
            return result;
        }

        public DataTable Validte_Agent_Login(string aid, string password)
        {
            dt = new DataTable();
            
                da = new SqlDataAdapter("SP_Insert_Agent_Login_Validate", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@agentlogin", SqlDbType.NVarChar).Value = aid;
                da.SelectCommand.Parameters.Add("@agentpwd", SqlDbType.NVarChar).Value = password;
                con.Open();
                da.Fill(dt);
                con.Close();          
            return dt;
        }

        public DataTable GetLoggedIn_Agent_Details(string agentid)
        {
            dt = new DataTable();
            da = new SqlDataAdapter("SP_Insert_Agent_Profile_Details", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@agentid", SqlDbType.NVarChar).Value = agentid;
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}