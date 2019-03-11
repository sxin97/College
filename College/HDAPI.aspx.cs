using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

using Newtonsoft.Json;
using System.IO;
using System.Collections.Specialized;
namespace College
{
    public partial class HDAPI : System.Web.UI.Page
    {
        List<tempStudent> tempList;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }



        private void BindGrid()
        {
            string apiUrl = "http://192.168.1.138/api/Student";
            //string apiUrl = "http://192.168.1.116/api/students";
            //object input = new
            //{
            //    Name = txtName.Text.Trim(),
            //};



            //string inputJson = (new JavaScriptSerializer()).Serialize(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl);

            //gvCustomers.DataSource = (new JavaScriptSerializer()).Deserialize<List<StudentInfo>>(json);
            //gvCustomers.DataBind();


            // List<StudentInfo> lstStudenInfo = JsonConvert.DeserializeObject(json);
            //List <StudentInfo> lstStudenInfo = (new JavaScriptSerializer()).Deserialize<List<StudentInfo>>(json);

            // JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, PreserveReferencesHandling = PreserveReferencesHandling.None };
            //var myObject = JsonConvert.DeserializeObject<PageCollection>(data.pageCollection.ToString(), settings)

            //var lstStudenInfo = JsonConvert.DeserializeObject<List<StudentInfo>>(json);
            var lstStudenInfo = JsonConvert.DeserializeObject<List<tempStudent>>(json);

            tempList = lstStudenInfo;


            // GridView1.DataSource = lstStudenInfo;
            //GridView1.DataBind();

            //gv1.DataSource = lstStudenInfo;
            // gv1.DataBind();


            if (GridView1.Attributes["CurrentSortDirection"] == "ASC")
            {
                if (GridView1.Attributes["CurrentSortField"] == "StudentID")
                {
                    tempList = lstStudenInfo.OrderBy(order => order.StudentID).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "StudentFirstName")
                {
                    tempList = lstStudenInfo.OrderBy(order => order.StudentFirstName).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "StudentLastName")
                {
                    tempList = lstStudenInfo.OrderBy(order => order.StudentLastName).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "Gender")
                {
                    tempList = lstStudenInfo.OrderBy(order => order.Gender).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "PhoneNum")
                {
                    tempList = lstStudenInfo.OrderBy(order => order.PhoneNum).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "GroupID")
                {
                    tempList = lstStudenInfo.OrderBy(order => order.GroupID).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "isDelete")
                {
                    tempList = lstStudenInfo.OrderBy(order => order.isDelete).ToList();
                }

            }

            else
            {
                if (GridView1.Attributes["CurrentSortField"] == "StudentID")
                {
                    tempList = lstStudenInfo.OrderByDescending(order => order.StudentID).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "StudentFirstName")
                {
                    tempList = lstStudenInfo.OrderByDescending(order => order.StudentFirstName).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "StudentLastName")
                {
                    tempList = lstStudenInfo.OrderByDescending(order => order.StudentLastName).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "Gender")
                {
                    tempList = lstStudenInfo.OrderByDescending(order => order.Gender).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "PhoneNum")
                {
                    tempList = lstStudenInfo.OrderByDescending(order => order.PhoneNum).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "GroupID")
                {
                    tempList = lstStudenInfo.OrderByDescending(order => order.GroupID).ToList();
                }

                else if (GridView1.Attributes["CurrentSortField"] == "isDelete")
                {
                    tempList = lstStudenInfo.OrderByDescending(order => order.isDelete).ToList();
                }
            }







            GridView1.DataSource = tempList.Where(x => x.StudentFirstName.Contains(txtSearch.Text)).ToList();
            GridView1.DataBind();





        }


        protected void Search_Click(object sender, EventArgs e)
        {

            BindGrid();
        }


        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value).ToString();
            string firstName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbStudentFirstName")).Text;
            string lastName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbStudentLastName")).Text;
            string gender = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlGenderEdit")).SelectedValue;
            string phoneNum = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbPhoneNum")).Text;
            string groupID = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbGroupID")).Text;


            string apiUrl = "http://192.168.1.138/api/Student/";

            WebClient client = new WebClient();
            // client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            //string json = client.DownloadString(apiUrl);


            var stud = new NameValueCollection();

            stud["StudentFirstName"] = firstName;
            stud["StudentLastName"] = lastName;
            stud["Gender"] = gender;
            stud["PhoneNum"] = phoneNum;
            stud["GroupID"] = groupID;
            stud["isDelete"] = "false";

            client.UploadValues(apiUrl + id, "PUT", stud);

            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value).ToString();
            //string firstName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbStudentFirstName")).Text;
            //string lastName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbStudentLastName")).Text;
            //string gender = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlGenderEdit")).SelectedValue;
            //string phoneNum = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbPhoneNum")).Text;
            //string groupID = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlGroupIDEdit")).Text;


            string apiUrl = "http://192.168.1.138/api/Student/";

            WebClient client = new WebClient();
            // client.Headers["Content-type"] = "application/json";

            //string json = client.DownloadString(apiUrl);


            var stud = new NameValueCollection();

            stud["StudentFirstName"] = "";
            //stud["StudentLastName"] = lastName;
            //stud["Gender"] = gender;
            //stud["PhoneNum"] = phoneNum;
            //stud["GroupID"] = groupID;
            //stud["isDelete"] = "false";
            //string temp = apiUrl + id + "/delete";
            client.UploadValues(apiUrl + id + "/delete", "PUT", stud);

            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row;

            if (e.CommandName == "Recover")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                row = GridView1.Rows[index];

                string id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value).ToString();

                string apiUrl = "http://192.168.1.138/api/Student/";
                WebClient client = new WebClient();


                var stud = new NameValueCollection();

                stud["StudentFirstName"] = "";
                //stud["StudentLastName"] = lastName;
                //stud["Gender"] = gender;
                //stud["PhoneNum"] = phoneNum;
                //stud["GroupID"] = groupID;
                //stud["isDelete"] = "false";
                //string temp = apiUrl + id + "/delete";
                client.UploadValues(apiUrl + id + "/recover", "PUT", stud);

                GridView1.EditIndex = -1;
                BindGrid();

            }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = e.SortDirection;
            string sortField = string.Empty;

            sortGridView(GridView1, e, out sortDirection, out sortField);




            BindGrid();



        }

        private void sortGridView(GridView gv1, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        {
            sortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (GridView1.Attributes["CurrentSortField"] != null && GridView1.Attributes["CurrentSortDirection"] != null)
            {


                if (sortField == GridView1.Attributes["CurrentSortField"])
                {
                    if (GridView1.Attributes["CurrentSortDirection"] == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }

                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }



                GridView1.Attributes["CurrentSortField"] = sortField;

                if (sortDirection == SortDirection.Ascending)
                {
                    GridView1.Attributes["CurrentSortDirection"] = "ASC";
                }

                else
                {
                    GridView1.Attributes["CurrentSortDirection"] = "DESC";
                }
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.PageSize = int.Parse(ddlSize.SelectedValue);
            BindGrid();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string firstName = ((TextBox)GridView1.FooterRow.FindControl("txtStudFirstName")).Text;
            string lastName = ((TextBox)GridView1.FooterRow.FindControl("txtStudLastName")).Text;
            string gender = ((DropDownList)GridView1.FooterRow.FindControl("ddlGenderInsert")).SelectedValue;
            string phoneNum = ((TextBox)GridView1.FooterRow.FindControl("txtPhoneNum")).Text;
            string groupID = ((DropDownList)GridView1.FooterRow.FindControl("txtGroupID")).Text;


            string apiUrl = "http://192.168.1.138/api/POS";

            WebClient client = new WebClient();
            // client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            //string json = client.DownloadString(apiUrl);


            var stud = new NameValueCollection();

            stud["StudentFirstName"] = firstName;
            stud["StudentLastName"] = lastName;
            stud["Gender"] = gender;
            stud["PhoneNum"] = phoneNum;
            stud["GroupID"] = groupID;
            stud["isDelete"] = "false";

            client.UploadValues(apiUrl, stud);

            BindGrid();
        }

        public class tempStudent
        {
            public int StudentID { get; set; }
            public string StudentFirstName { get; set; }
            public string StudentLastName { get; set; }
            public string Gender { get; set; }
            public string PhoneNum { get; set; }
            public string GroupID { get; set; }
            public bool isDelete { get; set; }

        }
    }
}