using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAttendance
{
    public class ExtraCredit
    {
        // variables or properties
        public string rollNoTbox { get; set; }
        public string subCodeTBox { get; set; }
        public string instIDTBox { get; set; }
        public string dtTBox { get; set; }
        public string hrTBox { get; set; }
        public string attTBox { get; set; }

        //constructor 
        public ExtraCredit(string roll, string sub, string instID, string dt, string hr, string att)
        {
            rollNoTbox = roll;
            subCodeTBox = sub;
            instIDTBox = instID;
            dtTBox = dt;
            hrTBox = hr;
            attTBox = att;
        }

        //method
        public void setCalc(string newRoll, string newSub, string newInstID, string newDt, string newHr, string newAtt)

        {
            rollNoTbox = newRoll;
            subCodeTBox = newSub;
            instIDTBox = newInstID;
            dtTBox = newDt;
            hrTBox = newHr;
            attTBox = newAtt;
        }

        /*The class has a method called Calculate which computes extra credit (bonus) for students based on their attendance, using the following rules:
        o If the student attendance percent >= 90% then the bonus =10 points
        o If the attendance >=70 and<90 then bonus =8
        o If the attendance >=60 and<70 then bonus =6
        o If the attendance>50 and<60 then bonus =2
        o Otherwise bonus =0
        The result should be stored in a new field in the student information table when the instructor uses the calculation button on student information page.*/

        public void Calculate()
        {
            /*http://forums.asp.net/t/1904370.aspx?How+to+calculate+attendance+percentage+ */

        }
    }
} 