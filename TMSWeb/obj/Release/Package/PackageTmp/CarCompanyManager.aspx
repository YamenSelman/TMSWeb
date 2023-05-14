﻿<%@ Page Title="إدارة شركات السيارات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarCompanyManager.aspx.cs" Inherits="TMSWeb.CarCompanyManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid pt-1 mt-1">
        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">
            <div class="table-responsive">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h3>شركات السيارات</h3>
                </div>

                <asp:GridView ID="carCompanyGrid" runat="server" Width="100%" CssClass="table text-white" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="false" SortExpression="ID" />
                        <asp:BoundField DataField="Name" HeaderText="الشركة" SortExpression="Name" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="40%"/>
                        <asp:BoundField DataField="PhoneNumber" HeaderText="رقم الهاتف" SortExpression="PhoneNumber" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="20%"/>
                        <asp:BoundField DataField="Email" HeaderText="البريد الالكتروني" SortExpression="Email" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" HeaderStyle-Width="30%"/>
                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                            <ItemTemplate>
                                <a href='CarCompanyDetails.aspx?ID=<%#Eval("ID") %>' class="px-2"><i class="fa fs-2 fa-eye text-white"></i></a>
                                <a href='DeleteCarCompany.aspx?ID=<%#Eval("ID") %>' class="px-2"><i class="fa fs-2 fa-trash text-white"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div class="btn-group-lg p-3 text-center">
                    <a class="btn btn-outline-light btn-lg shadow-lg" href="AddCarCompany.aspx">إضافة شركة</a>
                    <a class="btn btn-outline-light btn-lg shadow-lg" href="Administration.aspx">صفحة الإدارة</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
