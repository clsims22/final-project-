using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;

namespace StudentAttendance
{
    public partial class MainLoginPage : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\taryn\Documents\Visual Studio 2015\Projects\final-project-\StudentAttendance\StudentAttendance\App_Data\Database1.mdf;Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
        }
                
        //Login Button Needs to Validate Credentials in LoginTable 
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (iuNmTBox.Text != "" & staffpwdTBox.Text != "")
            {
                Response.Redirect("InstStudInfoPage.aspx");
            }
            /*cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM LoginTable WHERE Name= '" + iuNmTBox.Text + "' AND Password = '"+ staffpwdTBox.Text+"'";
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                Session["iuName"] = iuNmTBox.Text;
                Response.Redirect("InstStudInfoPage");
            }
            else
            {
                Response.Write("Login not correct, please try again... ");
            }
            cn.Close(); */

            /*try
            { 
                string iuName = iuNmTBox.Text;
                string staffPassword = staffpwdTBox.Text;

                cmd = new SqlCommand("SELECT ISNULL (Name, ' ') AS Name, ISNULL (Password, ' ') AS Password FROM LoginTable WHERE Name= @Name and Password = @Password", cn); // '" + iuNmTBox.Text + "' and Password= '" + staffpwdTBox.Text + "'";
                cmd.Parameters.Add(new SqlParameter("Name", iuName));
                cmd.Parameters.Add(new SqlParameter("Password", staffPassword));
                dr = cmd.ExecuteReader(); 

                try 
                {
                    dr.Read();
                    if (dr.["Name"].ToString().Trim() == iuName && dr["Password"].ToString().Trim() == staffPassword)
                    {
                        
                    }
                }
                catch
                {

                }
                dr.Close();
                cn.Close();
                
                Response.Redirect("InstStudInfoPage.aspx");
            }
            finally
            {
                //Response.Redirect.("InstStudInfoPage.aspx");
            }*/
        }

        //Register Button Routes to Admin Page 
        protected void regBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
} 