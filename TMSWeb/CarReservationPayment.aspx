<%@ Page Title="اتمام الدفع" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarReservationPayment.aspx.cs" Inherits="TMSWeb.CarReservationPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="table-responsive" id="resDiv" runat="server">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h4>تأكيد الحجز</h4>
                </div>
                <div class="row">
                    <div class="col-6">
                        <div class="img-fluid text-center">
                            <img src="img/carpay.png" class="p-2" height="200px" />
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="text-center rounded-3 text-white p-4 bg-danger bg-opacity-50 mt-2">
                            <h5>المبلغ المطلوب <span>
                                <asp:Label ID="sum" runat="server" /></span></h5>
                        </div>
                        <div class="text-center rounded-3 text-white p-4">
                            <h5>الرجاء إدخال كلمة المرور لتأكيد عملية الدفع </h5>
                            <asp:TextBox TextMode="Password" ID="pass" runat="server" CssClass="form-control text-center"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="text-center text-lg-end mt-2 pt-2 text-danger fw-bold">
                    <asp:Label class="fs-4" ID="ErrorLBL" runat="server" Text=""></asp:Label>
                </div>

                <div class="mt-4 row btn-group-lg m-auto text-center">
                    <asp:Button ID="confirmRes" runat="server" class="btn accordion-body btn-lg btn-outline-success w-25 m-auto" Text="تأكيد الدفع" OnClick="confirmRes_Click" />
                    <a href="UserPage.aspx" class="btn accordion-body btn-lg btn-outline-danger w-25 m-auto">إلغاء</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
