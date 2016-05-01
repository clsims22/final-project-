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
    public partial class AdminPage : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\taryn\Documents\Visual Studio 2015\Projects\final-project-\StudentAttendance\StudentAttendance\App_Data\Database1.mdf;Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
        }

        //Logout Button Routes to Main Page 
        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainLoginPage.aspx");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (logIDTBox.Text != "" & insIDTBox.Text != "" & insNmTBox.Text != "" & staffLogPwdTBx.Text != "" & subCodeTBox.Text != "" & subNmTBox.Text != "") 
            {
                cn.Open();
                cmd.CommandText = "INSERT into LoginTable (ID,InstructorID,Name,Password) Values ('" + logIDTBox.Text + "','" + insIDTBox.Text + "','" + insNmTBox.Text + "','" + staffLogPwdTBx.Text + "')"; 
                cmd.CommandText = "INSERT into SubjectTable (sCode,sSname) Values ('"+subCodeTBox+"','"+subNmTBox+"')"; 
                cmd.CommandText = "INSERT into InstructorTable (InstructorID,sCode) Values ('"+ insIDTBox +"','"+ subCodeTBox +"')"; 

                cmd.ExecuteNonQuery();
                cmd.Clone();
                cn.Close();

                logIDTBox.Text = ""; 
                insIDTBox.Text = ""; 
                insNmTBox.Text = ""; 
                staffLogPwdTBx.Text = ""; 
                subCodeTBox.Text = ""; 
                subNmTBox.Text = ""; 
            }
        }

        protected void delBtn_Click(object sender, EventArgs e)
        {
            if (insIDTBox.Text != "")
            {
                cn.Open();
                cmd.CommandText = "DELETE from InstructorTable WHERE InstructorID='" + insIDTBox.Text + "'";
                cmd.CommandText = "DELETE from LoginTable WHERE InstructorID='" + insIDTBox.Text + "'"; 
                cmd.ExecuteNonQuery(); 
                cn.Close(); 
            }
        }

        protected void updBtn_Click(object sender, EventArgs e)
        {
            if (insIDTBox.Text != "")
            {
                cn.Open();
                cmd.CommandText = "UPDATE InstructorTable SET sCode= '" + subCodeTBox.Text + "' WHERE InstructorID='" + insIDTBox.Text + "'";
                cmd.CommandText = "UPDATE LoginTable SET ID= '" + logIDTBox.Text + "', Name='"+ insNmTBox.Text +"', Password='"+ staffLogPwdTBx.Text+"' WHERE InstructorID='" + insIDTBox.Text + "'";
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        //Filling in the Grids 
        protected void loginGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "SELECT * FROM LoginTable";
            cn.Close();
        }

        protected void subjectGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "SELECT * FROM SubjectTable";
            cn.Close();
        }

        protected void instructorGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "SELECT * FROM InstructorTable";
            cn.Close();
        }
    }
}