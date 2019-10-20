using EmployeeManagementBussinessLayer.Bussiness;
using EmployeeManagementBussinessLayer.Interface;
using EmployeeManagementBussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class Job : Page
    {
        JobInterface jobInterface = new JobBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            JobModel myModel = new JobModel();
            myModel.Job = JobName.Text;
            myModel.MinSalary = Convert.ToDecimal(MinSalary.Text);
            myModel.MaxSalary = Convert.ToDecimal(MaxSalary.Text);

            if (HiddenField1.Value != "")
                myModel.ID = Convert.ToInt32(HiddenField1.Value);
            myModel = jobInterface.AddAndUpdateJob(myModel);
            if (myModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Job.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = jobInterface.GetJobByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    JobName.Text = dt.Rows[0]["Job"].ToString();
                    MinSalary.Text = dt.Rows[0]["MinSalary"].ToString();
                    MaxSalary.Text = dt.Rows[0]["MaxSalary"].ToString();
                    Submit.Text = "Update";

                }
                else
                {
                    Submit.Text = "Save";
                }
                
            }
            else
            {
                DataTable dt = new DataTable();
                bool result = jobInterface.DeleteJob(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = jobInterface.GetJobList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataBind();
            }
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Job.aspx");
        }
      
    }
}