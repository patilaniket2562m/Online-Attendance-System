using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Staff_StudentReport : System.Web.UI.Page
{
    // Declare DataTable and TableAdapter objects for accessing data
    DS_STD.STDMST_SELECTDataTable StdDT = new DS_STD.STDMST_SELECTDataTable();
    DS_STDTableAdapters.STDMST_SELECTTableAdapter StdAdapter = new DS_STDTableAdapters.STDMST_SELECTTableAdapter();
    DS_DIV.DIVMST_SELECTDataTable DivDT = new DS_DIV.DIVMST_SELECTDataTable();
    DS_DIVTableAdapters.DIVMST_SELECTTableAdapter DivAdapter = new DS_DIVTableAdapters.DIVMST_SELECTTableAdapter();

    DS_STAFF.StaffMST_SELECTDataTable StaffDT = new DS_STAFF.StaffMST_SELECTDataTable();
    DS_STAFFTableAdapters.StaffMST_SELECTTableAdapter StaffAdapter = new DS_STAFFTableAdapters.StaffMST_SELECTTableAdapter();

    DS_STUDENT.StudentMst_SELECTDataTable StuDT = new DS_STUDENT.StudentMst_SELECTDataTable();
    DS_STUDENTTableAdapters.StudentMst_SELECTTableAdapter StuAdapter = new DS_STUDENTTableAdapters.StudentMst_SELECTTableAdapter();

    // Event handler for Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl.Text = ""; // Clear label text

        if (!Page.IsPostBack)
        {
            // Check if the session variable "uname" exists
            if (Session["uname"] != null)
            {
                // Populate StaffDT based on the session's uname
                StaffDT = StaffAdapter.Select_UNAME(Session["uname"].ToString());

                // Fetch and bind standard (STD) data to dropdown
                StdDT = StdAdapter.SelectStd();
                drpstd.DataSource = StdDT;
                drpstd.DataTextField = "STDName"; // Display text
                drpstd.DataValueField = "SID"; // Value field
                drpstd.DataBind();

                // Add default "SELECT" item
                drpstd.Items.Insert(0, "SELECT");

                // Ensure Division dropdown starts with a "SELECT" option
                drpdiv.Items.Insert(0, "SELECT");
            }
            else
            {
                // Handle the case where session uname is null (redirect to login page)
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    // Event handler for the Button7 (Search) click event
    protected void Button7_Click(object sender, EventArgs e)
    {
        if (drpstd.SelectedItem != null && drpdiv.SelectedItem != null &&
            drpstd.SelectedItem.Text != "SELECT" && drpdiv.SelectedItem.Text != "SELECT")
        {
            // Fetch students based on selected STD and DIV
            StuDT = StuAdapter.Select_By_STD_DIV(drpstd.SelectedItem.Text, drpdiv.SelectedItem.Text);
            GridView1.DataSource = StuDT;
            GridView1.DataBind();

            // Display total number of students
            lbl.Text = "Total Student = " + GridView1.Rows.Count.ToString();
        }
        else
        {
            // If a dropdown is not selected, show a message
            lbl.Text = "Please select both Standard and Division.";
        }
    }

    // Event handler for the dropdown (STD) selection change
    protected void drpstd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpstd.SelectedItem != null && drpstd.SelectedItem.Text != "SELECT")
        {
            // Fetch divisions based on the selected STD
            DivDT = DivAdapter.Select_By_STD(drpstd.SelectedItem.Text);
            drpdiv.DataSource = DivDT;
            drpdiv.DataTextField = "DivName"; // Display text
            drpdiv.DataValueField = "DID"; // Value field
            drpdiv.DataBind();

            // Add default "SELECT" item to division dropdown
            drpdiv.Items.Insert(0, "SELECT");
        }
        else
        {
            // Clear the division dropdown if no valid STD is selected
            drpdiv.Items.Clear();
            drpdiv.Items.Insert(0, "SELECT");
        }
    }

    // Event handler for the Delete button click
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // Get the button that raised the event
        Button btn = (Button)sender;

        // Get the roll number from the CommandArgument
        string rollno = btn.CommandArgument;

        // Define the connection string (replace with your actual connection string)
        string connectionString = "Data Source=LAPTOP-3A4AQSMQ\\SQLEXPRESS03;Initial Catalog=AttSystem;Integrated Security=True";

        // Use SqlConnection and SqlCommand to execute the delete operation
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            // Define the SQL DELETE query with a parameter
            string deleteQuery = "DELETE FROM StudentMst WHERE rollno = @rollno";

            using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
            {
                // Add the rollno parameter to the query
                cmd.Parameters.AddWithValue("@rollno", rollno);

                // Open the SQL connection
                con.Open();

                // Execute the SQL command to delete the record
                cmd.ExecuteNonQuery();

                // Close the connection
                con.Close();
            }
        }

        // Rebind the GridView to reflect the updated data after deletion
        StuDT = StuAdapter.Select_By_STD_DIV(drpstd.SelectedItem.Text, drpdiv.SelectedItem.Text);
        GridView1.DataSource = StuDT;
        GridView1.DataBind();

        // Update the label text with the new total number of students
        lbl.Text = "Total Students = " + GridView1.Rows.Count.ToString();
    }
}
