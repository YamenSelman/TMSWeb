<%@ Page Title="إضافة فندق" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddHotel.aspx.cs" Inherits="TMSWeb.AddHotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                <h3>إضافة فندق</h3>
            </div>

            <div class="row p-2 fs-5 fw-bold text-center bg-white bg-opacity-25 m-3">
                <div class="col-6 fs-4 fw-bold">
                    معلومات الفندق
                </div>
                <div class="col-6  fs-4 fw-bold">
                    الغرف الفندقية
                </div>
            </div>
            <div class="row p-2">
                <div class="col-6 px-5">
                    <label for="hotelName">اسم الفندق</label>
                    <asp:TextBox ID="hotelName" runat="server" CssClass="form-control"></asp:TextBox>

                    <label for="hotelDesc">الوصف</label>
                    <asp:TextBox ID="hotelDesc" runat="server" CssClass="form-control"></asp:TextBox>

                    <label for="phoneNmuber">رقم الهاتف</label>
                    <asp:TextBox ID="phoneNmuber" runat="server" CssClass="form-control" type="number"></asp:TextBox>

                    <label for="email">البريد الالكتروني</label>
                    <asp:TextBox ID="email" runat="server" CssClass="form-control" type="email"></asp:TextBox>

                    <label for="accountNumber">رقم الحساب</label>
                    <asp:TextBox ID="accountNumber" runat="server" CssClass="form-control"></asp:TextBox>

                    <label for="hotelManager">مدير الفندق</label>
                    <asp:DropDownList ID="hotelManager" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-6 px-5" id="gridCol" runat="server">
                    <div class="mx-auto h-100">
                        <asp:GridView ID="roomsGrid" CssClass="w-100" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="roomsGrid_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="false" SortExpression="ID" />
                                <asp:BoundField DataField="Number" HeaderText="رقم الغرفة" SortExpression="Number" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                <asp:BoundField DataField="Capacity" HeaderText="سعة الغرفة" SortExpression="Capacity" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                <asp:BoundField DataField="Rent" HeaderText="السعر" SortExpression="Rent" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton" runat="server" CommandArgument='<%#Eval("Number") %>' CommandName="deleteRoom" OnClientClick="return confirm('تأكيد حذف الغرفة !؟')"><i class="fa fa-trash text-white"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>



                        <div class="btn-group-lg p-2 text-center">
                            <asp:Button ID="roomAddBtn" runat="server" Text="إضافة غرفة" OnClick="roomAddBtn_Click" CssClass="btn btn-outline-primary w-25 fw-bold shadow-lg btn-lg" />                        </div>
                    </div>
                </div>
                <div class="col-6 px-5" id="addCol" runat="server" visible="false">
                    <div class="w-50 mx-auto">
                        <label for="roomNum">رقم الغرفة</label>
                        <asp:TextBox ID="roomNum" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="roomDesc">الوصف</label>
                        <asp:TextBox ID="roomDesc" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="capacity">سعة الغرفة</label>
                        <asp:TextBox ID="capacity" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                        <label for="rent">السعر</label>
                        <asp:TextBox ID="rent" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                        <div class="btn-group-lg p-2 text-center">
                            <asp:Button ID="roomAddSaveBtn" runat="server" Text="حفظ" OnClick="roomAddSaveBtn_Click" CssClass="btn btn-outline-primary fw-bold" />
                            <asp:Button ID="roomAddCancelBtn" runat="server" Text="إلغاء" OnClick="roomAddCancelBtn_Click" CssClass="btn btn-outline-danger fw-bold" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="text-center pt-5">
                <asp:Button ID="saveHotelBtn" runat="server" OnClick="saveHotelBtn_Click" CssClass="btn btn-outline-primary w-25 shadow-lg fw-bold btn-lg" Text="حفظ" />
                <a href="HotelManager.aspx" class="btn btn-outline-danger w-25 shadow-lg fw-bold btn-lg">إلغاء</a>
            </div>

        </div>
    </div>
</asp:Content>
