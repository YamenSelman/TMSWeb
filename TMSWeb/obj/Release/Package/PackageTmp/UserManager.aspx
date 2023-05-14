<%@ Page Title="إدارة المستخدمين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="TMSWeb.UserManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-1 mt-1">
        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">
            <div class="table-responsive">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h3>المستخدمين</h3>
                </div>

                <asp:GridView ID="usersGrid" runat="server" Width="100%" CssClass="table text-white" AutoGenerateColumns="False" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="false" SortExpression="ID" />
                        <asp:BoundField DataField="Name" HeaderText="الاسم" SortExpression="Name" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                        <asp:BoundField DataField="Email" HeaderText="البريد الالكتروني" SortExpression="Email" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                        <asp:BoundField DataField="Role" HeaderText="نوع الحساب" SortExpression="Role" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                        <asp:BoundField DataField="isApproved" HeaderText="الحالة" SortExpression="isApproved" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                            <ItemTemplate>
                                <a href='UserDetails.aspx?ID=<%#Eval("ID") %>'><i class="fa fa-eye text-white"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
