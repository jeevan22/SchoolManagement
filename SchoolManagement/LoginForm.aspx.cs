using SchoolManagement.Bussiness.Interface;
using SchoolManagement.Bussiness.Service;
using SchoolManagement.Bussiness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagement
{
    public partial class LoginForm : System.Web.UI.Page
    {
        IUserMasterService iUserMasterService = new UserMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            UserMasterViewModel vmModel = new UserMasterViewModel();
           
            Response.Cookies["UserName"].Value = Username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();
            vmModel.Name = Username.Text.Trim();
            vmModel.Password = password.Text.Trim();
            bool msg = iUserMasterService.LoginUser(vmModel);
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