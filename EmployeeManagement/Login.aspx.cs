﻿using EmployeeManagementBussinessLayer.Bussiness;
using EmployeeManagementBussinessLayer.Interface;
using EmployeeManagementBussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            UserModel myModel = new UserModel();
            UserInterface userMasterService = new UserBussiness();
            Response.Cookies["UserName"].Value = Username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();
            myModel.Name = Username.Text.Trim();
            myModel.Password = password.Text.Trim();
            bool msg = userMasterService.LoginUser(myModel);
            if (msg)
            {

                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login ID and Password is invalid.";
            }
        }
    }
}