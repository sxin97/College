using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace College
{
    public partial class testRicoAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //this.puopulateGrid();
            }
        }
        public void puopulateGrid()
        {
            string url = "http://192.168.0.222/api/Customer";

            //object input = new
            //{
            //    Name = "2",
            //};
            //string inputJson = (new JavaScriptSerializer()).Serialize(input);

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            //string json = client.UploadString(url, inputJson);
            string json = client.DownloadString(url);

            gvCustomers.DataSource = (new JavaScriptSerializer()).Deserialize<List<Customer>>(json);
            gvCustomers.DataBind();
        }
    }
    
}