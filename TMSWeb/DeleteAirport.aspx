<%@ Page Title="حذف مطار" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteAirport.aspx.cs" Inherits="TMSWeb.DeleteAirport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                <h3>تأكيد حذف مطار</h3>
            </div>

            <div class="row p-2">
                <div class="col-12">
                    <div class="w-75 m-auto">
                        <asp:Label ID="msg" runat="server" CssClass="fs-4 text-white" />
                    </div>
                </div>
            </div>

            <div class="text-center pt-5">
                <asp:Button ID="deleteAirportBtn" runat="server" OnClick="deleteAirportBtn_Click" CssClass="btn btn-outline-primary btn-lg" Text="تأكيد الحذف" />
                <a href="AirportManager.aspx" class="btn btn-outline-danger btn-lg">إلغاء</a>
            </div>

        </div>
    </div>
</asp:Content>
