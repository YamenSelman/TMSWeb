<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TMSWeb.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid h-custom pt-1 mt-1">
        <div class="row d-flex fs-5 justify-content-center align-items-center m-3 rounded-1 bg-dark bg-opacity-25 px-3 text-black-75" style="width: 35%;">
            <div class="row">
                <div class="card-body p-md-4 text-black">

                    <h4 class="bg-white bg-opacity-50 p-2 fw-bolder mb-4 text-center">تسجيل حساب مستخدم</h4>

                    <div class="row my-3">

                        <div class="form-outline">
                            <input type="text" runat="server" id="userNameTB" class="form-control form-control-lg" placeholder="اسم المستخدم"/>
                        </div>

                    </div>
                    <div class="row my-3">
                        <div class="form-outline">
                            <input type="email" runat="server" id="emailTB" class="form-control form-control-lg" placeholder="البريد الالكتروني"/>
                        </div>
                    </div>
                    <div class="row my-3">
                        <div class="form-outline">
                            <input type="number" runat="server" id="phoneTB" class="form-control form-control-lg" placeholder="رقم الهاتف"/>
                        </div>
                    </div>
                    <div class="row my-3">
                        <div class="form-outline">
                            <input type="password" runat="server" id="passwordTB" class="form-control form-control-lg" placeholder="كلمة المرور"/>
                        </div>
                    </div>
                    <div class="row my-3">
                        <div class="form-outline">
                            <input type="password" runat="server" id="confirmPWTB" class="form-control form-control-lg" placeholder="تأكيد كلمة المرور"/>
                        </div>
                    </div>
                    <div class="row my-3">
                        <div class="form-outline">
                            <input type="text" runat="server" id="accountNumTB" class="form-control form-control-lg" placeholder="رقم الحساب"/>
                        </div>
                    </div>


                    <div class="w-100 p-1 btn-group" role="group" aria-label="Basic example" dir="ltr">
                        <a class=" fw-bold btn btn-danger cancel btn-lg mw-50 w-50 mx-1" href="Home.aspx">إلغاء الأمر</a>
                        <asp:Button type="button" class=" fw-bold btn btn-lg btn-primary mw-50 w-50 mx-2" runat="server" ID="registerBTN" OnClick="registerBTN_Click" Text="تسجيل"></asp:Button>
                    </div>

                    <div class="text-center text-lg-end mt-1 p-1" id="ErrorDIV" runat="server">
                        <asp:Label class="fw-bolder text-white fs-5" ID="ErrorLBL" runat="server" Text=""></asp:Label>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
