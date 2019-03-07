using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.Text;
using CollegeDataAccess;
using System.Web.Script.Serialization;
using System.Collections.Specialized;

namespace College
{
    public partial class Default : System.Web.UI.Page
    {
        string sortDirection = "ASC";
        string sortItem = "StudentName";
        protected void Page_Load(object sender, EventArgs e)
        {
            //TextBoxSearch.Attributes.Add("onKeyUp", "load()");
            //load_data();
            if (!this.IsPostBack)
            {
                load_data();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        public void load_data()
        {
            //string searchBox;
            //if (TextBoxSearch.Text == "")
            //    searchBox = " ";
            //else
            //    searchBox = TextBoxSearch.Text;

            //if (DropDownList3.SelectedValue == "Ascending")
            //{
            //    sortDirection = "ASC";
            //    sortItem = DropDownList2.SelectedValue;
            //}
            //else if (DropDownList3.SelectedValue == "Descending")
            //{
            //    sortDirection = "DESC";
            //    sortItem = DropDownList2.SelectedValue;
            //}

            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString);
            //conn.Open();
            //string selectQuery = "SELECT * FROM Student WHERE (StudentName LIKE '%' + @StudentName + '%') ORDER BY " + sortItem + " " + sortDirection;
            //SqlCommand cmd = new SqlCommand(selectQuery, conn);
            //cmd.Parameters.AddWithValue("@StudentName", searchBox);


            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //GridView1.DataSourceID = null;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            //conn.Close();
            string apiUrl = "http://192.168.1.116/api/students";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);
            List<Student> lst = (new JavaScriptSerializer()).Deserialize<List<Student>>(json);

            GridView1.DataSourceID = null;
            GridView1.DataSource = lst;
            GridView1.DataBind();
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            //SqlDataSource1.InsertParameters["StudentID"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBoxID")).Text;

            //SqlDataSource1.InsertParameters["StudentName"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBoxName")).Text;

            //SqlDataSource1.InsertParameters["StudentPass"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBoxPassword")).Text;

            //SqlDataSource1.InsertParameters["StudentPhone"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBoxPhone")).Text;

            //SqlDataSource1.InsertParameters["StudentEmail"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBoxEmail")).Text;

            //SqlDataSource1.InsertParameters["GroupCode"].DefaultValue = ((DropDownList)GridView1.FooterRow.FindControl("DropDownListGroupCode")).SelectedValue;
            //SqlDataSource1.Insert();
            Boolean trigger = false;

            string id = ((TextBox)GridView1.FooterRow.FindControl("TextBoxID")).Text;
            string name = ((TextBox)GridView1.FooterRow.FindControl("TextBoxName")).Text;
            string pass = ((TextBox)GridView1.FooterRow.FindControl("TextBoxPassword")).Text;
            string phone = ((TextBox)GridView1.FooterRow.FindControl("TextBoxPhone")).Text;
            string email = ((TextBox)GridView1.FooterRow.FindControl("TextBoxEmail")).Text;
            string groupcode = ((DropDownList)GridView1.FooterRow.FindControl("DropDownListGroupCode")).SelectedValue.ToString();

            if (id == "")
            {
                Response.Write("<script>alert('Please input all the field!');</script>");
                trigger = true;
            }
            if (name == "")
            {
                if (!trigger)
                {
                    Response.Write("<script>alert('Please input all the field!');</script>");
                    trigger = true;
                }
            }
            if (pass == "")
            {
                if (!trigger)
                {
                    Response.Write("<script>alert('Please input all the field!');</script>");
                    trigger = true;
                }
            }
            if (phone == "")
            {
                if (!trigger)
                {
                    Response.Write("<script>alert('Please input all the field!');</script>");
                    trigger = true;
                }
            }
            if (email == "")
            {
                if (!trigger)
                {
                    Response.Write("<script>alert('Please input all the field!');</script>");
                    trigger = true;
                }
            }

            if (!trigger)
            {
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString);
                //conn.Open();
                //string insertQuery = "insert into Student values (@id, @name, @pass, @phone, @email, @group, @delete)";
                //SqlCommand cmd = new SqlCommand(insertQuery, conn);
                //cmd.Parameters.AddWithValue("@id", id);
                //cmd.Parameters.AddWithValue("@name", name);
                //cmd.Parameters.AddWithValue("@pass", pass);
                //cmd.Parameters.AddWithValue("@phone", phone);
                //cmd.Parameters.AddWithValue("@email", email);
                //cmd.Parameters.AddWithValue("@group", groupcode);
                //cmd.Parameters.AddWithValue("@delete", 0);

                //cmd.ExecuteNonQuery();
                //conn.Close();
                string apiurl = "http://192.168.1.116/api/students";
                var client = new WebClient();
                //client.Headers["Content-type"] = "application/json";
                //client.Encoding = Encoding.UTF8;

                var stud = new NameValueCollection();
                stud["StudentId"] = id;
                stud["StudentName"] = name;
                stud["StudentPass"] = pass;
                stud["StudentPhone"] = phone;
                stud["StudentEmail"] = email;
                stud["GroupCode"] = groupcode;
                stud["Deleted"] = "false";

                client.UploadValues(apiurl, stud);

                //GridView1.DataSourceID = null;
                load_data();
                //load_data();
            }
        }




        protected void TextBoxPaging_TextChanged(object sender, EventArgs e)
        {
            GridView1.PageSize = Convert.ToInt32(TextBoxPaging.Text);
            load_data();
        }

        protected void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            load_data();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString);
            //conn.Open();
            //string deleteQuery = "delete from Student where StudentId =  @id";
            //SqlCommand cmd = new SqlCommand(deleteQuery, conn);
            //cmd.Parameters.AddWithValue("@id", ((Label)GridView1.Rows[e.RowIndex].FindControl("itemStudId")).Text);
            //cmd.ExecuteNonQuery();
            //conn.Close();

            //GridView1.DataSourceID = null;


            load_data();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            //GridView1.DataSourceID = null;
            load_data();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString);
            conn.Open();
            string updateQuery = "update Student set StudentName = @studname, StudentPass = @studpass, StudentPhone = @studphone, StudentEmail = @studemail, GroupCode = @group where StudentId =  @id";
            SqlCommand cmd = new SqlCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@studname", ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text);
            cmd.Parameters.AddWithValue("@studpass", ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox")).Text);
            cmd.Parameters.AddWithValue("@studemail", ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3")).Text);
            cmd.Parameters.AddWithValue("@studphone", ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text);
            cmd.Parameters.AddWithValue("@group", ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedValue);
            cmd.Parameters.AddWithValue("@id", ((Label)GridView1.Rows[e.RowIndex].FindControl("LabelStudId")).Text);
            cmd.ExecuteNonQuery();
            conn.Close();



            GridView1.EditIndex = -1;
            load_data();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            load_data();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            load_data();
        }




        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortItem = DropDownList2.SelectedValue;
            if (DropDownList3.SelectedValue == "Ascending")
            {
                sortDirection = "ASC";
            }
            else if (DropDownList3.SelectedValue == "Descending")
            {
                sortDirection = "DESC";
            }

            load_data();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue == "Ascending")
            {
                sortDirection = "ASC";
                sortItem = DropDownList2.SelectedValue;
            }
            else if (DropDownList3.SelectedValue == "Descending")
            {
                sortDirection = "DESC";
                sortItem = DropDownList2.SelectedValue;
            }
            load_data();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load_data();
        }
    }
}