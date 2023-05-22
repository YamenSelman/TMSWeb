﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TMSWeb.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container-fluid pt-1 mt-1">
            <div class="row fs-5 justify-content-center align-items-center w-25 m-5 h-100 rounded-1 bg-dark bg-opacity-25 p-3 text-black-75" id="loginDiv" runat="server">
                <div class="divider align-items-center fs-3 fw-bold text-center py-3">
                    تسجيل الدخول
                </div>


                <div class="form-outline mb-4">
                    <label class="form-label fw-bold" for="username">اسم المستخدم</label>
                    <asp:TextBox type="text" ID="username" runat="server" class="form-control form-control-lg" value="sss" />
                </div>

                <div class="form-outline mb-3">
                    <label class="form-label fw-bold" for="password">كلمة المرور</label>
                    <asp:TextBox type="password" ID="password" runat="server" class="form-control form-control-lg" value="111" />
                </div>


                <div class="btn-group-lg mt-4">
                    <asp:Button ID="loginBtn" runat="server" Text="دخول" OnClick="loginBtn_Click" type="button" class="w-100 btn btn-lg btn-outline-success fw-bold shadow-lg" />
                    <a href="Register.aspx" class="mt-2 btn btn-outline-light fw-bold shadow-lg w-100 btn-lg">حساب جديد</a>
                </div>

                <div class="text-center text-lg-end mt-2 pt-2 text-danger fw-bold">
                    <asp:Label class="fs-4" ID="ErrorLBL" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row fs-5 justify-content-center align-items-center w-25 m-5 h-100 rounded-1 bg-dark bg-opacity-25 p-3 text-black-75" id="loggedDiv" runat="server">
                <div class="divider align-items-center fs-3 fw-bold text-center py-3">
                    أهلا بك
                <label class="form-label fw-bold" id="currentUserLBL" runat="server"></label>

                </div>

                <div class="btn-group-lg mt-4">
                    <asp:Button ID="PanelBtn" runat="server" Text="لوحة التحكم" OnClick="PanelBtn_Click" type="button" class="w-100 btn btn-lg btn-outline-primary fw-bold shadow-lg" />
                    <asp:Button ID="LogoutBtn" runat="server" Text="تسجيل خروج" OnClick="logout" type="button" class="mt-2 w-100 btn btn-lg btn-outline-dark fw-bold shadow-lg" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
