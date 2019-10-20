﻿using EmployeeManagementBussinessLayer.Bussiness;
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
    public partial class Employee : Page
    {
        EmployeeInterface employeeInterface = new EmployeeBussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                bindDepartmentList();
                bindJobList();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            EmployeeModel myModel = new EmployeeModel();
            myModel.tblJobID = Convert.ToInt32(JobID.Text);
            myModel.tblDepartment = Convert.ToInt32(DepartmentID.Text);
            myModel.Name = Name.Text;
            myModel.PhoneNumber = PhoneNumber.Text;
            myModel.Salary = Convert.ToDecimal(Salary.Text);
            myModel.Email = Email.Text;
            myModel.HireDate = Convert.ToDateTime(HireDate.Text);
            if (HiddenField1.Value != "")
                myModel.ID = Convert.ToInt32(HiddenField1.Value);
            myModel = employeeInterface.AddAndUpdateEmployee(myModel);
            if (myModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Employee.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //EmployeeModel myModel = new EmployeeModel();
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            //myModel.ID = Convert.ToInt32(id);
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = employeeInterface.GetEmployeeByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    JobID.Text = dt.Rows[0]["tblJobID"].ToString();
                    DepartmentID.Text = dt.Rows[0]["tblDepartment"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    PhoneNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
                    Email.Text = dt.Rows[0]["Email"].ToString();
                    HireDate.Text = dt.Rows[0]["HireDate"].ToString();
                    Salary.Text = dt.Rows[0]["Salary"].ToString();
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
                bool result = employeeInterface.DeleteEmployee(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = employeeInterface.GetEmployeeList();
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
        protected void bindJobList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            JobInterface service = new JobBussiness();
            var lst = service.GetJobList().Select(x => new { x.Job, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                JobID.DataSource = dt;
                JobID.DataTextField = "Job";
                JobID.DataValueField = "ID";
                JobID.DataBind();

            }
            else
            {
                JobID.DataBind();
            }
        }
        protected void bindDepartmentList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            DepartmentInterface service = new DepartmentBussiness();
            var lst = service.GetDepartmentList().Select(x => new { x.Name, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                DepartmentID.DataSource = dt;
                DepartmentID.DataTextField = "Name";
                DepartmentID.DataValueField = "ID";
                DepartmentID.DataBind();

            }
            else
            {
                DepartmentID.DataBind();
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

    }
}