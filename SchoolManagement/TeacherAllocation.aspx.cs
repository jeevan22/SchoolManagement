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
    public partial class TeacherAllocation : Page
    {
        ITeacherAllocationService iTeacherAllocationService = new TeacherAllocationService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                bindClassList();
                bindTeacherList();
                bindStudentList();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            TeacherAllocationViewModel vmModel = new TeacherAllocationViewModel();
            vmModel.ClassMasterID = Convert.ToInt32(ClassMasterID.Text);
            vmModel.TeacherMasterID = Convert.ToInt32(TeacherMasterID.Text);
            vmModel.StudentMasterID = Convert.ToInt32(StudentMasterID.Text);

            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iTeacherAllocationService.AddAndUpdateTeacherAllocation(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("TeacherAllocation.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //TeacherAllocationViewModel vmModel = new TeacherAllocationViewModel();
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            //vmModel.ID = Convert.ToInt32(id);
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iTeacherAllocationService.GetTeacherAllocationByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    ClassMasterID.Text = dt.Rows[0]["ClassMasterID"].ToString();
                    TeacherMasterID.Text = dt.Rows[0]["TeacherMasterID"].ToString();
                    StudentMasterID.Text = dt.Rows[0]["StudentMasterID"].ToString();
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
                bool result = iTeacherAllocationService.DeleteTeacherAllocation(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindClassList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            IClassMasterService service = new ClassMasterService();
            var lst = service.GetClassMasterList().Select(x => new { x.ClassName, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                ClassMasterID.DataSource = dt;
                ClassMasterID.DataTextField = "ClassName";
                ClassMasterID.DataValueField = "ID";
                ClassMasterID.DataBind();

            }
            else
            {
                ClassMasterID.DataBind();
            }
        }
        protected void bindTeacherList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            ITeacherMasterService service = new TeacherMasterService();
            var lst = service.GetTeacherMasterList().Select(x => new { x.Name, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                TeacherMasterID.DataSource = dt;
                TeacherMasterID.DataTextField = "Name";
                TeacherMasterID.DataValueField = "ID";
                TeacherMasterID.DataBind();

            }
            else
            {
                TeacherMasterID.DataBind();
            }
        }
        protected void bindStudentList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            IStudentMasterService service = new StudentMasterService();
            var lst = service.GetStudentMasterList().Select(x => new { x.Name, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                StudentMasterID.DataSource = dt;
                StudentMasterID.DataTextField = "Name";
                StudentMasterID.DataValueField = "ID";
                StudentMasterID.DataBind();

            }
            else
            {
                StudentMasterID.DataBind();
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iTeacherAllocationService.GetTeacherAllocationList();
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
            Response.Redirect("TeacherAllocation.aspx");
        }
    }
}