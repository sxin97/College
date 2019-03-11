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
        SortDirection direction = SortDirection.Ascending;
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
            
            string apiUrl = "http://192.168.1.116/api/students";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);
            List<Student> lst = (new JavaScriptSerializer()).Deserialize<List<Student>>(json);
            List<Student> tempList;

            GridView1.DataSourceID = null;

            if (DropDownList3.SelectedValue == "Descending")
            {
                if (DropDownList2.SelectedValue == "StudentId")
                    tempList = lst.OrderByDescending(o => o.StudentId).ToList();
                else if (DropDownList2.SelectedValue == "StudentEmail")
                    tempList = lst.OrderByDescending(o => o.StudentEmail).ToList();
                else if (DropDownList2.SelectedValue == "StudentPhone")
                    tempList = lst.OrderByDescending(o => o.StudentPhone).ToList();
                else if (DropDownList2.SelectedValue == "GroupCode")
                    tempList = lst.OrderByDescending(o => o.GroupCode).ToList();
                else
                    tempList = lst.OrderByDescending(o => o.StudentName).ToList();
            }
            else
            {
                if (DropDownList2.SelectedValue == "StudentId")
                    tempList = lst.OrderBy(o => o.StudentId).ToList();
                else if (DropDownList2.SelectedValue == "StudentEmail")
                    tempList = lst.OrderBy(o => o.StudentEmail).ToList();
                else if (DropDownList2.SelectedValue == "StudentPhone")
                    tempList = lst.OrderBy(o => o.StudentPhone).ToList();
                else if (DropDownList2.SelectedValue == "GroupCode")
                    tempList = lst.OrderBy(o => o.GroupCode).ToList();
                else
                    tempList = lst.OrderBy(o => o.StudentName).ToList();
            }


            GridView1.DataSource = tempList.Where(x=>x.StudentName.Contains(TextBoxSearch.Text)).ToList();

            GridView1.DataBind();

            
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
           
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
            
            string apiurl = "http://192.168.1.116/api/students/";
            var client = new WebClient();

            var stud = new NameValueCollection();
            stud["StudentName"] = "anything";
            //client.DownloadString(apiurl + ((Label)GridView1.Rows[e.RowIndex].FindControl("itemStudId")).Text,"DELETE");
            client.UploadValues(apiurl + ((Label)GridView1.Rows[e.RowIndex].FindControl("itemStudId")).Text, "DELETE", stud);
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
            string id = ((Label)GridView1.Rows[e.RowIndex].FindControl("LabelStudId")).Text;
            string name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            string pass= ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox")).Text;
            string phone = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
            string email = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            string group = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedValue;

            string apiurl = "http://192.168.1.116/api/students/";
            var client = new WebClient();
            

            var stud = new NameValueCollection();
            stud["StudentId"] = id;
            stud["StudentName"] = name;
            stud["StudentPass"] = pass;
            stud["StudentPhone"] = phone;
            stud["StudentEmail"] = email;
            stud["GroupCode"] = group;
            stud["Deleted"] = "false";
            //string studJson = "{\"StudentName:\""+name+", \"StudentPass:\""+pass+", \"StudentPhone:\""+phone+", \"StudentEmail:\""+email+", \"GroupCode:\""+group+"}";

            client.UploadValues(apiurl + id, "PUT", stud);
           
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
            load_data();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load_data();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            
            load_data();
            

        }
    }

}