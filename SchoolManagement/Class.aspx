<%@ Page Title="Class" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="SchoolManagement.Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content" class="col-lg-10 col-sm-10">
        <!-- content starts -->
        <div>
            <ul class="breadcrumb">
                <li>
                    <a runat="server" href="~/">Home</a>
                </li>
                <li>
                    <a runat="server" href="~/Class">Classes</a>
                </li>
            </ul>
        </div>
        <div class="row">
            <div class="box col-md-12">
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
                        <div class="form-group">
                            <label for="exampleInputName">Class Name<span style="color: red;">*</span></label>
                            <asp:TextBox ID="ClassName" class="form-control" runat="server" placeholder="Class Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorClassName" ValidationGroup="Save" runat="server" ControlToValidate="ClassName" ErrorMessage="Please enter class name" ForeColor="#993333"></asp:RequiredFieldValidator>
                        </div>

                        <asp:Button ID="Submit" ValidationGroup="Save" runat="server" class="btn btn-success pull-right" Text="Submit" OnClick="Submit_Click" />
                        <asp:Button ID="Reset" runat="server" class="btn btn-danger pull-right" Text="Reset" OnClick="Reset_Click" />
                    </div>
                </div>
                <!--/span-->

            </div>
        </div>
        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="box-header well" data-original-title="">
                        <h2><i class="glyphicon glyphicon-user"></i>List </h2>

                        <div class="box-icon">
                            <a href="#" class="btn btn-minimize btn-round btn-default"><i
                                class="glyphicon glyphicon-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="box-content">
                        <div class="box-body">
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
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Class
                       
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("ClassName") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="BatchCode" HeaderText="Batch Code" />
                    <asp:BoundField DataField="AssessmentDate" HeaderText="Assessment Date" />
                    <asp:BoundField DataField="NoOfCandidate" HeaderText="No of Candidates" />--%>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="butEnable" runat="server" class="btn btn-warning btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->

        </div>
    </div>
</asp:Content>
