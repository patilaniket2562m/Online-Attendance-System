using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class AttendanceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateStudents();
        }
    }

    private void PopulateStudents()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyProjectConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT Rollno, Name FROM dbo.Attendancemst"; // Correct table name
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drpStudent.Items.Add(new ListItem(reader["Name"].ToString(), reader["Rollno"].ToString()));
                }
            }
        }
    }

    protected void btnFetchAttendance_Click(object sender, EventArgs e)
    {
        string rollNo = drpStudent.SelectedValue;
        DateTime startDate;
        DateTime endDate;

        // Validate and parse the dates from the TextBoxes
        if (DateTime.TryParse(txtStartDate.Text, out startDate) && DateTime.TryParse(txtEndDate.Text, out endDate))
        {
            FetchAttendance(rollNo, startDate, endDate);
        }
    }

    private void FetchAttendance(string rollNo, DateTime startDate, DateTime endDate)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyProjectConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            // Adjust the query to fit your table structure and attendance logic
            string query = "SELECT * FROM dbo.Attendancemst WHERE Rollno = @Rollno AND Date BETWEEN @StartDate AND @EndDate";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Rollno", rollNo);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind(); // Bind data to the GridView
            }
        }
    }
}
