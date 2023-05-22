<%@ Page Title="صفحة الزبون" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="TMSWeb.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-5 mt-3">
        <div class="row">
            <div class="col-4">
                <a href="HotelReservation.aspx" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">حجز فندقي</a>
                <a href="#" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">حجز طيران</a>
                <a href="CarReservation.aspx" class="btn btn-outline-dark fw-bold btn-lg w-100 my-2 py-4 shadow-lg" role="button" aria-disabled="true">حجز سيارة</a>
                <asp:LinkButton ID="logoutBtn" runat="server" Text="تسجيل خروج" OnClick="logout" class="btn btn-outline-danger shadow-lg fw-bold btn-lg w-100 my-2 py-4" role="button" aria-disabled="true" />
            </div>
            <div class="col-7 bg-primary fw-bold rounded-3 bg-opacity-75" id="companiesDiv" runat="server" visible="false">
                <div class="text-center rounded-3 bg-opacity-50 bg-dark  text-white p-4 m-4">
                    <h4>إدارة المنشآت</h4>
                </div>

                <div class="px-4 m-4" id="companies" runat="server">
                    
                </div>

            </div>
        </div>
    </div>
</asp:Content>
