<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="TMSWeb.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-5 mt-3">
        <div class="col-md-8 col-lg-6 col-xl-4">
            <a href="HotelReservation.aspx" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">حجز فندقي</a>
            <a href="#" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">حجز طيران</a>
            <a href="#" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">حجز سيارة</a>
            <asp:LinkButton ID="logoutBtn" runat="server" Text="تسجيل خروج" OnClick="logout" class="btn btn-outline-danger shadow-lg fw-bold btn-lg w-100 my-2 py-4" role="button" aria-disabled="true" />
        </div>
    </div>
</asp:Content>
