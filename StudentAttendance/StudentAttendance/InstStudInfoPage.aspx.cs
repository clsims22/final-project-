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
    public partial class InstStudInfoPage : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\taryn\Documents\Visual Studio 2015\Projects\final-project-\StudentAttendance\StudentAttendance\App_Data\Database1.mdf;Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader dr;


        protected void Page_Load(object sender, EventArgs e)
        {
            //cmd.Connection = cn;
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainLoginPage.aspx");
        }

        //Save Attendendance 
        protected void saveAttBtn_Click(object sender, EventArgs e) 
        {
            if(rollNoTbox.Text != "" & subCodeTBox.Text != "" & instIDTBox.Text != "" & dtTBox.Text != "" & hrTBox.Text != "" & attTBox.Text != "")
            {
                cn.Open();
                cmd.CommandText = "INSERT into AttendanceTable (RollNo,sCode,ID,Date,Hour,Attendance) Values ('"+rollNoTbox.Text+"','"+subCodeTBox.Text+"','"+instIDTBox.Text+"','" + dtTBox.Text + "','" + hrTBox.Text + "','" + attTBox.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                cn.Close();

                rollNoTbox.Text = "";
                subCodeTBox.Text = "";
                instIDTBox.Text = "";
                dtTBox.Text = "";
                hrTBox.Text = "";
                attTBox.Text = "";

            }

            /*if (uNameTxtBox.Text != "" & pswdTxtBox.Text != "" & emailTxtBox.Text != "" & uTypeDropDown.SelectedItem.Text != "")
            {
                cn.Open();
                cmd.CommandText = "INSERT into UserTable (UserName,Password,Email,UserType) Values ('" + uNameTxtBox.Text + "','" + pswdTxtBox.Text + "','" + emailTxtBox.Text + "','" + uTypeDropDown.SelectedItem.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                cn.Close();

                uNameTxtBox.Text = "";
                pswdTxtBox.Text = "";
                emailTxtBox.Text = "";
                uTypeDropDown.SelectedItem.Text = "";
                loadlist();
            }*/

        }
    }
}