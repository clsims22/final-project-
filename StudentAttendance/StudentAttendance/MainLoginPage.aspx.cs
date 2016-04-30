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
        SqlCommand cmd;
        SqlDataReader dr;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (iuNmTBox.Text != "" & staffpwdTBox.Text != "")
            {
                //cn.Open();
                //cmd = new SqlCommand("SELECT * FROM LoginTable WHERE Name= '" + iuNmTBox.Text + "' and Password= '" + staffpwdTBox.Text + "')", cn); 
                //dr = cmd.ExecuteReader(); 
                Response.Redirect("InstStudInfoPage.aspx");
            }
        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            if (iuNmTBox.Text != "" & staffpwdTBox.Text != "")
            {
                Response.Redirect("AdminPage.aspx");
            }
        }
    }
} 