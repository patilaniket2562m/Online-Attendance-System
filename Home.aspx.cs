﻿using System;

public partial class Home : System.Web.UI.Page
{
    DS_STAFF.StaffMST_SELECTDataTable StaffDT = new DS_STAFF.StaffMST_SELECTDataTable();
    DS_STAFFTableAdapters.StaffMST_SELECTTableAdapter StaffAdapter = new DS_STAFFTableAdapters.StaffMST_SELECTTableAdapter();

    DS_STUDENT.StudentMst_SELECTDataTable StuDT = new DS_STUDENT.StudentMst_SELECTDataTable();
    DS_STUDENTTableAdapters.StudentMst_SELECTTableAdapter StuAdapter = new DS_STUDENTTableAdapters.StudentMst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblstafferror.Text = "";
        lblstuerror.Text = "";
    }
    protected void btnstafflogin_Click(object sender, EventArgs e)
    {
        StaffDT = StaffAdapter.Select_LOGIN(txtstaffuname.Text, txtstaffpass.Text);
        if (StaffDT.Rows.Count == 1)
        {
            Session["uname"] = txtstaffuname.Text;
            Response.Redirect("Staff/Default.aspx");


        }
        else
        {
            lblstafferror.Text = "Login Error !!";
        }

    }
    protected void btnstudenlogin_Click(object sender, EventArgs e)
    {
        StuDT = StuAdapter.Select_LOGIN(txtstuuname.Text, txtstupass.Text);
        if (StuDT.Rows.Count == 1)
        {
            Session["sname"] = txtstuuname.Text;
            Response.Redirect("Student/Main.aspx");
        }
        else
        {

            lblstuerror.Text = "Login Error !!";
        }
    }
}