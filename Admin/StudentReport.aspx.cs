using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_StudentReport : System.Web.UI.Page
{
    DS_STD.STDMST_SELECTDataTable StdDT = new DS_STD.STDMST_SELECTDataTable();
    DS_STDTableAdapters.STDMST_SELECTTableAdapter StdAdapter = new DS_STDTableAdapters.STDMST_SELECTTableAdapter();
    DS_DIV.DIVMST_SELECTDataTable DivDT = new DS_DIV.DIVMST_SELECTDataTable();
    DS_DIVTableAdapters.DIVMST_SELECTTableAdapter DivAdapter = new DS_DIVTableAdapters.DIVMST_SELECTTableAdapter();

    DS_STAFF.StaffMST_SELECTDataTable StaffDT = new DS_STAFF.StaffMST_SELECTDataTable();
    DS_STAFFTableAdapters.StaffMST_SELECTTableAdapter StaffAdapter = new DS_STAFFTableAdapters.StaffMST_SELECTTableAdapter();

    DS_STUDENT.StudentMst_SELECTDataTable StuDT = new DS_STUDENT.StudentMst_SELECTDataTable();
    DS_STUDENTTableAdapters.StudentMst_SELECTTableAdapter StuAdapter = new DS_STUDENTTableAdapters.StudentMst_SELECTTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            // Populate the dropdown for selecting standard
            StdDT = StdAdapter.SelectStd();
            drpstd.DataSource = StdDT;
            drpstd.DataTextField = "StdName";
            drpstd.DataValueField = "Sid";
            drpstd.DataBind();

            // Insert "SELECT" option at the top
            drpstd.Items.Insert(0, "SELECT");
            drpdiv.Items.Insert(0, "SELECT");
            drpstudent.Items.Insert(0, "SELECT");
        }
    }

    protected void drpstd_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Populate divisions based on selected standard
        DivDT = DivAdapter.Select_By_STD(drpstd.SelectedItem.Text);
        drpdiv.DataSource = DivDT;
        drpdiv.DataTextField = "DivName";
        drpdiv.DataValueField = "DID";
        drpdiv.DataBind();

        // Insert "SELECT" option
        drpdiv.Items.Insert(0, "SELECT");
        drpstudent.Items.Clear();
        drpstudent.Items.Insert(0, "SELECT");
    }

    protected void drpdiv_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Populate students based on selected division
        StuDT = StuAdapter.Select_By_STD_DIV(drpstd.SelectedItem.Text, drpdiv.SelectedItem.Text);
        drpstudent.DataSource = StuDT;
        drpstudent.DataTextField = "rollno";
        drpstudent.DataValueField = "sid";
        drpstudent.DataBind();

        // Insert "SELECT" option
        drpstudent.Items.Insert(0, "SELECT");
    }

    protected void btnsarch_Click(object sender, EventArgs e)
    {
        // Declare the variable before using it in TryParse
        int studentId;

        // Check if a valid student is selected
        if (!string.IsNullOrEmpty(drpstudent.SelectedValue) && int.TryParse(drpstudent.SelectedValue, out studentId))
        {
            StuDT = StuAdapter.SELECT_BY_ID(studentId); // Safe conversion

            if (StuDT.Rows.Count == 1)
            {
                // Bind student data to labels
                lblroll.Text = StuDT.Rows[0]["rollno"].ToString();
                lblname.Text = StuDT.Rows[0]["name"].ToString();
                lblemail.Text = StuDT.Rows[0]["email"].ToString();
                lblmobile.Text = StuDT.Rows[0]["mobile"].ToString();
                lbldob.Text = StuDT.Rows[0]["dob"].ToString();
                lbladd.Text = StuDT.Rows[0]["add"].ToString();
                lblcity.Text = StuDT.Rows[0]["city"].ToString();
                lblpin.Text = StuDT.Rows[0]["pincode"].ToString();
                lbluname.Text = StuDT.Rows[0]["uname"].ToString();
                lblpass.Text = StuDT.Rows[0]["pass"].ToString();
                imgg.ImageUrl = StuDT.Rows[0]["image"].ToString();

                // Display the student details view
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                // Hide view if no student is found
                MultiView1.ActiveViewIndex = -1;
            }
        }
        else
        {
            // Handle invalid student selection
            lblroll.Text = "Please select a valid student.";
            MultiView1.ActiveViewIndex = -1;
        }
    }
}
