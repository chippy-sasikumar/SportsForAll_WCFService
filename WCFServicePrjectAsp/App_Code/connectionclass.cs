using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for connectionclass
/// </summary>
public class connectionclass
{
    SqlConnection con;
    SqlCommand cmd;
    public connectionclass()
    {
        con = new SqlConnection(@"server=DESKTOP-P8NIB7B\SQLEXPRESS;database=projectasp;Integrated security=true");
    }
    public SqlDataReader fnReader(string sqlquery)
    {
        if(con.State==ConnectionState.Open)
        {
            con.Close();
        }
        cmd = new SqlCommand(sqlquery, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        return dr;
    }
}