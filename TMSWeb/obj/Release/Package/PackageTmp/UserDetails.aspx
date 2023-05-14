<%@ Page Title="تفاصيل المستخدم" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="TMSWeb.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-1 mt-1">
        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">
            <div class="table-responsive">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h3>معلومات المستخدم</h3>
                </div>
                <div class="row">
                    <div class="card-body p-md-4 text-white col-5">
                        <div class="row my-3">

                            <div class="form-outline">
                                <label for="userNameTB">اسم المستخدم</label>
                                <asp:TextBox type="text" readonly="true" runat="server" id="userNameTB" class="form-control form-control-lg" />
                            </div>

                        </div>
                        <div class="row my-3">
                            <div class="form-outline">
                                <label for="emailTB">البريد الالكتروني</label>
                                <asp:TextBox type="email" readonly="true" runat="server" id="emailTB" class="form-control form-control-lg" />
                            </div>
                        </div>


                        <div class="row my-3">
                            <div class="form-outline">
                                <label for="userRoleTB">نوع الحساب</label>
                                <asp:TextBox type="text" readonly="true" runat="server" id="userRoleTB" class="form-control form-control-lg" />
                            </div>
                        </div>

                    </div>
                    <div class="card-body p-md-4 text-white col-5">
                        <div class="row my-3">
                            <div class="form-outline">
                                <label for="phoneTB">رقم الهاتف</label>
                                <asp:TextBox type="number" runat="server" id="phoneTB" class="form-control form-control-lg" />
                            </div>
                        </div>  
                        <div class="row my-3">
                            <div class="form-outline">
                                <label for="password">كلمة المرور</label>
                                <asp:TextBox type="password" runat="server" id="passwordTB" class="form-control form-control-lg" />
                            </div>
                        </div>

                        <div class="row my-3">
                            <div class="form-outline">
                                <label for="userStatue">حالة المستخدم</label>
                                <asp:DropDownList ID="userStatue" runat="server" class="form-control form-control-lg">
                                    <asp:ListItem Text="مفعل" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="غير مفعل" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="text-center">
                    <div class="w-50 p-1 btn-group" role="group" aria-label="Basic example" dir="ltr">
                        <a class=" fw-bold btn btn-primary cancel btn-lg mw-50 w-50 mx-1" href="UserManager.aspx">رجوع</a>
                        <asp:Button type="button" class="fw-bold btn btn-lg btn-success mw-50 w-50 mx-2" runat="server" ID="saveBtn" OnClick="saveBtn_Click" Text="حفظ التغييرات"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
