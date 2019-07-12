using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using StudentManagement.Bussiness.Service;
using System.Data;
using SchoolManagement.Bussiness.ViewModel;
using SchoolManagement.Bussiness.Interface;
using SchoolManagement.Bussiness.Service;

namespace SchoolManagement
{
    public partial class Student : Page
    {
        
        IStudentMasterService iStudentMasterService = new StudentMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            StudentMasterViewModel vmModel = new StudentMasterViewModel();
            vmModel.Name = Name.Text;
            vmModel.FatherName = FatherName.Text;
            vmModel.Address = Address.InnerText;
            vmModel.PhoneNo = PhoneNumber.Text;
            vmModel.Email = Email.Text;
            vmModel.DOB = Convert.ToDateTime(DOB.Text);
            vmModel.Gender = GenderList.Text;
            
            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iStudentMasterService.AddAndUpdateStudentMaster(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Student.aspx");
            }
           bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //StudentMasterViewModel vmModel = new StudentMasterViewModel();
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            //vmModel.ID = Convert.ToInt32(id);
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iStudentMasterService.GetStudentMasterByID(Convert.ToInt32(id));
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
                bool result = iStudentMasterService.DeleteStudentMaster(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iStudentMasterService.GetStudentMasterList();
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
            Response.Redirect("Student.aspx");
        }
    }
}