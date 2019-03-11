using CollegeDataAccess;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace College
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                load_data();
            }
        }
        public void load_data()
        {

            string apiUrl = "http://192.168.0.222/api/Customer";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);
            List<Customer> lst = (new JavaScriptSerializer()).Deserialize<List<Customer>>(json);

            GridView1.DataSourceID = null;
            GridView1.DataSource = lst;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string apiurl = "http://192.168.0.222/api/Customer/";
            var client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            Customer customer = new Customer();
            customer.CustomerName = "";

            var data = (new JavaScriptSerializer()).Serialize(customer);

            client.UploadString(apiurl + ((Label)GridView1.Rows[e.RowIndex].FindControl("itemStudId")).Text, "DELETE", data);
            load_data();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
           
            load_data();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string id = ((Label)GridView1.Rows[e.RowIndex].FindControl("LabelStudId")).Text;
            string name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            string address = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox")).Text;
            string phone = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
            //string email = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            //string group = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedValue;

            string apiurl = "http://192.168.0.222/api/Customer/";
            var client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            Customer cust = new Customer();
            cust.CustomerName = name;
            cust.CustomerPhone = phone;
            cust.CustomerAddress = address;

            var data = (new JavaScriptSerializer()).Serialize(cust);

            client.UploadString(apiurl + id, "PUT", data);

            GridView1.EditIndex = -1;
            load_data();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            load_data();
        }
        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            
            Boolean trigger = false;

            //string id = ((TextBox)GridView1.FooterRow.FindControl("TextBoxID")).Text;
            string name = ((TextBox)GridView1.FooterRow.FindControl("TextBoxName")).Text;
            string address = ((TextBox)GridView1.FooterRow.FindControl("TextBoxAddress")).Text;
            string phone = ((TextBox)GridView1.FooterRow.FindControl("TextBoxPhone")).Text;
            
            
            if (name == "")
            {
                if (!trigger)
                {
                    Response.Write("<script>alert('Please input all the field!');</script>");
                    trigger = true;
                }
            }
            if (address == "")
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
            

            if (!trigger)
            {
                
                string apiurl = "http://192.168.0.222/api/Customer";
                var client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;

                Customer cust = new Customer();
                cust.CustomerName = name;
                cust.CustomerAddress = address;
                cust.CustomerPhone = phone;

                var data = (new JavaScriptSerializer()).Serialize(cust);

                client.UploadString(apiurl, data);

            
                load_data();
               
            }
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerStatus { get; set; }
    }
}