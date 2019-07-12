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
    public partial class Class : Page
    {
        IClassMasterService iClassMasterService = new ClassMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            ClassMasterViewModel vmModel = new ClassMasterViewModel();
            vmModel.ClassName = ClassName.Text;

            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iClassMasterService.AddAndUpdateClassMaster(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Class.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //ClassMasterViewModel vmModel = new ClassMasterViewModel();
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            //vmModel.ID = Convert.ToInt32(id);
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iClassMasterService.GetClassMasterByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    ClassName.Text = dt.Rows[0]["ClassName"].ToString();
                    Submit.Text = "Update";
                    
                }
                else
                {
                    Submit.Text = "Save";
                }
                //if (lst != null)
                //{
                //    HiddenField1.Value = lst.ID.ToString();
                //    ClassName.Text = lst.ClassName;
                //    Submit.Text = "Update";
                //}
                //else
                //{
                //    //do nothing
                //    Submit.Text = "Save";
                //}
            }
            else
            {
                DataTable dt = new DataTable();
                bool result = iClassMasterService.DeleteClassMaster(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iClassMasterService.GetClassMasterList();
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
            Response.Redirect("Class.aspx");
        }
    }
}