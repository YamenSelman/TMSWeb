<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="TMSWeb.Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-5 mt-3">
        <div class="col-md-8 col-lg-6 col-xl-4">
            <a href="UserManager.aspx" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">إدارة المستخدمين</a>
            <a href="HotelManager.aspx" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">إدارة الفنادق</a>
            <a href="FlightCompanyManager.aspx" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">إدارة شركات الطيران</a>
            <a href="CarCompanyManager.aspx" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">إدارة شركات السيارات</a>
            <a href="AirportManager.aspx" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">إدارة المطارات</a>
            <asp:LinkButton ID="logoutBtn" runat="server" Text="تسجيل خروج" OnClick="logout" class="btn btn-outline-danger shadow-lg fw-bold btn-lg w-100 my-2 py-4" role="button" aria-disabled="true"/>
        </div>
    </div>
</asp:Content>
