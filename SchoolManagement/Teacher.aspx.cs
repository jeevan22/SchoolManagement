using SchoolManagement.Bussiness.Interface;
using SchoolManagement.Bussiness.Service;
using SchoolManagement.Bussiness.ViewModel;
using StudentManagement.Bussiness.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagement
{
    public partial class Teacher : Page
    {
        ITeacherMasterService iTeacherMasterService = new TeacherMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            TeacherMasterViewModel vmModel = new TeacherMasterViewModel();
            vmModel.Name = Name.Text;
            vmModel.FatherName = FatherName.Text;
            vmModel.Address = Address.InnerText;
            vmModel.PhoneNo = PhoneNumber.Text;
            vmModel.Email = Email.Text;
            vmModel.DOB = Convert.ToDateTime(DOB.Text);
            vmModel.Gender = GenderList.Text;

            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iTeacherMasterService.AddAndUpdateTeacherMaster(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Teacher.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //TeacherMasterViewModel vmModel = new TeacherMasterViewModel();
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            //vmModel.ID = Convert.ToInt32(id);
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iTeacherMasterService.GetTeacherMasterByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    FatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    Address.InnerText = dt.Rows[0]["Address"].ToString();
                    PhoneNumber.Text = dt.Rows[0]["PhoneNo"].ToString();
                    Email.Text = dt.Rows[0]["Email"].ToString();
                    DOB.Text = dt.Rows[0]["DOB"].ToString();
                    GenderList.Text = dt.Rows[0]["Gender"].ToString();
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
                bool result = iTeacherMasterService.DeleteTeacherMaster(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iTeacherMasterService.GetTeacherMasterList();
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
            Response.Redirect("Teacher.aspx");
        }
    }
}