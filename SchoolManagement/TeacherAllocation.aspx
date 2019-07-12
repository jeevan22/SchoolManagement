<%@ Page Title="Teacher Allocation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherAllocation.aspx.cs" Inherits="SchoolManagement.TeacherAllocation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content" class="col-lg-10 col-sm-10">
        <!-- content starts -->
        <div>
            <ul class="breadcrumb">
                <li>
                    <a runat="server" href="~/">Home</a>
                </li>
                <li>
                    <a runat="server" href="~/TeacherAllocation">Teacher Allocation</a>
                </li>
            </ul>
        </div>
        <div class="box">
            <div class="box-inner">
                <div class="box-header well" data-original-title="">
                    <h2><i class="glyphicon glyphicon-edit"></i>Form Elements</h2>

                    <div class="box-icon">
                        <a href="#" class="btn btn-minimize btn-round btn-default"><i
                            class="glyphicon glyphicon-chevron-up"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="exampleInputClass">Class <span style="color: red;">*</span></label>
                                <asp:DropDownList ID="ClassMasterID" AppendDataBoundItems="true" class="form-control" runat="server">
                                    <asp:ListItem>------ Choose Class ------</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorClassName" ValidationGroup="Save" runat="server" ControlToValidate="ClassMasterID" ErrorMessage="Please choose class " ForeColor="#993333"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="exampleInputTeacher">Teacher <span style="color: red;">*</span></label>
                                <asp:DropDownList ID="TeacherMasterID" AppendDataBoundItems="true" class="form-control" runat="server">
                                    <asp:ListItem>------ Choose Teacher ------</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" runat="server" ControlToValidate="TeacherMasterID" ErrorMessage="Please choose teacher " ForeColor="#993333"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="exampleInputStudent">Student <span style="color: red;">*</span></label>
                                <asp:DropDownList ID="StudentMasterID" AppendDataBoundItems="true" class="form-control" runat="server">
                                    <asp:ListItem>------ Choose Student ------</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" runat="server" ControlToValidate="StudentMasterID" ErrorMessage="Please choose student " ForeColor="#993333"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="Submit" ValidationGroup="Save" runat="server" class="btn btn-primary" Text="Submit" OnClick="Submit_Click" />
                            <asp:Button ID="Reset" runat="server" class="btn btn-danger" Text="Reset" OnClick="Reset_Click" />

                        </div>
                    </div>
                </div>
                <!--/span-->

            </div>
            <div class="row">
                <div class="box col-md-12">
                    <div class="box-inner">
                        <div class="box-header well" data-original-title="">
                            <h2><i class="glyphicon glyphicon-user"></i>List</h2>

                            <div class="box-icon">
                                <a href="#" class="btn btn-minimize btn-round btn-default"><i
                                    class="glyphicon glyphicon-chevron-up"></i></a>
                            </div>
                        </div>
                        <div class="box-content">
                            <%--<table class="table table-striped table-bordered bootstrap-datatable datatable responsive">
                            <thead>
                                <tr>
                                    <th>Class</th>
                                    <th>Teacher</th>
                                    <th>Student</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>12th</td>
                                    <td class="center">John</td>
                                    <td class="center">Tommy</td>
                                    <td class="center">
                                        <a class="btn btn-success" href="#">
                                            <i class="glyphicon glyphicon-zoom-in icon-white"></i>
                                            View
            </a>
                                        <a class="btn btn-info" href="#">
                                            <i class="glyphicon glyphicon-edit icon-white"></i>
                                            Edit
            </a>
                                        <a class="btn btn-danger" href="#">
                                            <i class="glyphicon glyphicon-trash icon-white"></i>
                                            Delete
            </a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>--%>
                            <div id="datatable-responsive_wrapper" class="dataTables_wrapper form-inline dt-bootstrap no-footer">

                                <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover"
                                    AutoGenerateColumns="false" EmptyDataText="No Record Found" DataKeyNames="ID"
                                    AllowPaging="false" PageSize="10" OnRowCommand="grd_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ClassName" HeaderText="Class Name" />
                                        <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name" />
                                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                        <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="butType" runat="server" class="btn btn-success btn-xs" CommandName="updates" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="butEnable" runat="server" class="btn btn-warning btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
                <!--/span-->

            </div>
        </div>
</asp:Content>
