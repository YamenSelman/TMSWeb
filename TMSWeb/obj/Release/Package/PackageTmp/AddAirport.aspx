<%@ Page Title="إضافة مطار" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAirport.aspx.cs" Inherits="TMSWeb.AddAirport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                <h3>إضافة مطار</h3>
            </div>

            <div class="row p-2 fs-5 fw-bold text-center bg-white bg-opacity-25 m-3">
                <div class="col-12 fs-4 fw-bold">
                    معلومات المطار
                </div>
            </div>
            <div class="row p-2">
                <div class="col-12">
                    <div class="w-75 m-auto">
                        <label for="airportName">اسم المطار</label>
                        <asp:TextBox ID="airportName" runat="server" CssClass="form-control"></asp:TextBox>

                        <label for="cityDD">المدينة</label>
                        <asp:DropDownList ID="cityDD" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="text-center pt-5">
                <asp:Button ID="saveAirportBtn" runat="server" OnClick="saveAirportBtn_Click" CssClass="btn btn-outline-primary btn-lg" Text="حفظ" />
                <a href="AirportManager.aspx" class="btn btn-outline-danger btn-lg">إلغاء</a>
            </div>

        </div>
    </div>
</asp:Content>
