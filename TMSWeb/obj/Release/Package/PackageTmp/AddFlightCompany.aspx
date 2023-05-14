<%@ Page Title="إضافة شركة طيران" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFlightCompany.aspx.cs" Inherits="TMSWeb.AddFlightCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                <h3>إضافة شركة طيران</h3>
            </div>

            <div class="row p-2 fs-5 fw-bold text-center bg-white bg-opacity-25 m-3">
                <div class="col-12 fs-4 fw-bold">
                    معلومات الشركة
                </div>
            </div>
            <div class="row p-2">
                <div class="col-6">
                    <div class="w-75 m-auto">
                        <label for="companyName">اسم الشركة</label>
                        <asp:TextBox ID="companyName" runat="server" CssClass="form-control"></asp:TextBox>

                        <label for="companyDesc">الوصف</label>
                        <asp:TextBox ID="companyDesc" runat="server" CssClass="form-control"></asp:TextBox>

                        <label for="phoneNumber">رقم الهاتف</label>
                        <asp:TextBox ID="phoneNumber" runat="server" CssClass="form-control" type="number"></asp:TextBox>
                    </div>
                </div>
                <div class="col-6">

                    <div class="w-75 m-auto">
                        <label for="email">البريد الالكتروني</label>
                        <asp:TextBox ID="email" runat="server" CssClass="form-control" type="email"></asp:TextBox>

                        <label for="accountNumber">رقم الحساب</label>
                        <asp:TextBox ID="accountNumber" runat="server" CssClass="form-control"></asp:TextBox>

                        <label for="companyManager">مدير الشركة</label>
                        <asp:DropDownList ID="companyManager" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="text-center pt-5">
                <asp:Button ID="saveFlightCompanyBtn" runat="server" OnClick="saveFlightCompanyBtn_Click" CssClass="btn btn-primary btn-lg" Text="حفظ" />
                <a href="FlightCompanyManager.aspx" class="btn btn-danger btn-lg">إلغاء</a>
            </div>

        </div>
    </div>
</asp:Content>
