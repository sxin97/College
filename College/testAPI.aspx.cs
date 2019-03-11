using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using CollegeDataAccess;

namespace College
{
    public partial class testAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.PopulateGridView();
            }
        }
        private void PopulateGridView()
        {
            string apiUrl = "http://localhost:51569/api/students";
            //object input = new
            //{
            //    Name = txtName.Text.Trim(),
            //};
            //string inputJson = (new JavaScriptSerializer()).Serialize(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            //string json = client.UploadString(apiUrl + "/GetCustomers", inputJson);
            string json = client.DownloadString(apiUrl);
          
            //gvCustomers.DataSource = (new JavaScriptSerializer()).Deserialize<List<Student>>(json);
            List<Student> lst = (new JavaScriptSerializer()).Deserialize<List<Student>>(json);

            

            gvCustomers.DataSource = lst.OrderBy(o => o.StudentName).ToList(); //(new JavaScriptSerializer()).Deserialize<List<Student>>(json);
            gvCustomers.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }
    }
}