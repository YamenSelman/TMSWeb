<%@ Page Title="إدارة المطارات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AirportManager.aspx.cs" Inherits="TMSWeb.AirportManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid pt-1 mt-1">
        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">
            <div class="table-responsive">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h3>المطارات</h3>
                </div>

                <asp:GridView ID="AirportGrid" runat="server" Width="100%" CssClass="table text-white" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="true" SortExpression="ID" />
                        <asp:BoundField DataField="Name" HeaderText="اسم المطار" SortExpression="Name" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="60%"/>
                        <asp:BoundField DataField="City" HeaderText="المدينة" SortExpression="PhoneNumber" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="20%"/>
                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                            <ItemTemplate>
                                <a href='AirportDetails.aspx?ID=<%#Eval("ID") %>' class="px-2"><i class="fa fs-2 fa-eye text-white"></i></a>
                                <a href='DeleteAirport.aspx?ID=<%#Eval("ID") %>' class="px-2"><i class="fa fs-2 fa-trash text-white"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div class="btn-group-lg p-3 text-center">
                    <a class="btn btn-outline-light btn-lg shadow-lg" href="AddAirport.aspx">إضافة مطار</a>
                    <a class="btn btn-outline-light btn-lg shadow-lg" href="Administration.aspx">صفحة الإدارة</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
