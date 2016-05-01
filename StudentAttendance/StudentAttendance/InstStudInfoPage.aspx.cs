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

        //Saves Attendance Record Successfully 
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
        }
        
        //Updates Attendance Record Successfully 
        protected void updAttBtn_Click(object sender, EventArgs e)
        {
            if (rollNoTbox.Text != "")
            {
                cn.Open();
                cmd.CommandText = "UPDATE AttendanceTable SET sCode= '" + subCodeTBox.Text + "', ID= '" + instIDTBox.Text + "', Date= '"+dtTBox.Text+"', Hour= '"+hrTBox.Text+"', Attendance= '"+attTBox.Text+"' WHERE RollNo = '" + rollNoTbox.Text + "'"; 
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        
        //Deletes Attendance Record Successfully 
        protected void delAttBtn_Click(object sender, EventArgs e)
        {
            if (rollNoTbox.Text != "")
            {
                cn.Open();
                cmd.CommandText = "DELETE from AttendanceTable WHERE RollNo='" + rollNoTbox.Text + "'"; 
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        
        //Needs to Calculate Attendance Requirements 
        protected void calcAttBtn_Click(object sender, EventArgs e)
        {
            //"Calculate method in ExtraCredit.cs 

            
        }

        //Saves Student Record Successfully 
        protected void addStuBtn_Click(object sender, EventArgs e)
        {
            if (stuRollNoTbox.Text != "" & stuNmTbox.Text != "" & stuDOBTBox.Text != "" & stuMobNoTBox.Text != "" & stuEmailTBox.Text != "" & stuAddrTBox.Text != "" & degTbox.Text != "" & notesTBox.Text != "")
            {
                cn.Open();
                cmd.CommandText = "INSERT into StudentInfoTable (RollNo,Name,DOB,MNo,EID,Address,Degree,Notes) Values ('" + stuRollNoTbox.Text + "','" + stuNmTbox.Text + "','" + stuDOBTBox.Text + "','" + stuMobNoTBox.Text + "', '" + stuEmailTBox.Text + "','"+stuAddrTBox.Text+"','"+ degTbox.Text+"','"+notesTBox.Text+"')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                cn.Close();

                stuRollNoTbox.Text = "";
                stuNmTbox.Text = "";
                stuDOBTBox.Text = "";
                stuMobNoTBox.Text = "";
                stuEmailTBox.Text = "";
                stuAddrTBox.Text = "";
                degTbox.Text = "";
                notesTBox.Text = "";
            }
        }
        
        //Updates Student Record Successfully 
        protected void updStuBtn_Click(object sender, EventArgs e)
        {
            if (stuRollNoTbox.Text != "") 
            {
                cn.Open();
                cmd.CommandText = "UPDATE StudentInfoTable SET Name= '" + stuNmTbox.Text + "', DOB= '" + stuDOBTBox.Text+ "', MNo='"+ stuMobNoTBox.Text +"', EID= '" + stuMobNoTBox.Text + "', Address= '" + stuAddrTBox.Text + "', Degree= '"+ degTbox.Text+"',  Notes='"+notesTBox.Text+"' WHERE RollNo='" + stuRollNoTbox.Text + "'"; 
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        //Deletes Student Record Successfully
        protected void delStuBtn_Click(object sender, EventArgs e)
        {
            if (stuRollNoTbox.Text != "") 
            {
                cn.Open();
                cmd.CommandText = "DELETE from StudentInfoTable WHERE RollNo='" + stuRollNoTbox.Text + "'"; 
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        //Filling in the stuInfoGrid 
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e) 
        {
            cn.Open();
            cmd.CommandText = "SELECT * FROM StudentInfoTable";
            cn.Close();
        }

        //Filling in the stuAttGrid 
        protected void stuAttGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            cmd.CommandText = "SELECT * FROM AttendanceTable";
            cn.Close();
        }
    }
} 

