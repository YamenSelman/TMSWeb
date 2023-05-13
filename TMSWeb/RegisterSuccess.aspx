<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterSuccess.aspx.cs" Inherits="TMSWeb.RegisterSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="text-center h2 fw-bold" id="msg" runat="server">
                <h3 class="p-5">تم ارسال طلب الاشتراك بنجاح .. سيتم الموافقة على الطلب في أقرب وقت</h3>
            </div>
            <div class="btn-group text-center col-md-9 col-lg-6 col-xl-5 h2 fw-bold p-5" role="group" aria-label="Basic example">
                <a href="Home.aspx" class="btn btn-outline-primary btn-lg">الصفحة الرئيسية</a>
            </div>
        </div>
    </div>

</asp:Content>
