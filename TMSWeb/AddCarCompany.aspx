<%@ Page Title="إضافة شركة سيارات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCarCompany.aspx.cs" Inherits="TMSWeb.AddCarCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                <h3>إضافة شركة سيارات</h3>
            </div>

            <div class="row p-2 fs-5 fw-bold text-center bg-white bg-opacity-25 m-3">
                <div class="col-6 fs-4 fw-bold">
                    معلومات الشركة
                </div>
                <div class="col-6  fs-4 fw-bold">
                    سيارات الشركة
                </div>
            </div>
            <div class="row p-2">
                <div class="col-6 px-5">
                    <label for="companyName">اسم الشركة</label>
                    <asp:TextBox ID="companyName" runat="server" CssClass="form-control"></asp:TextBox>

                    <label for="companyDesc">الوصف</label>
                    <asp:TextBox ID="companyDesc" runat="server" CssClass="form-control"></asp:TextBox>

                    <label for="phoneNumber">رقم الهاتف</label>
                    <asp:TextBox ID="phoneNumber" runat="server" CssClass="form-control" type="number"></asp:TextBox>

                    <label for="email">البريد الالكتروني</label>
                    <asp:TextBox ID="email" runat="server" CssClass="form-control" type="email"></asp:TextBox>

                    <label for="accountNumber">رقم الحساب</label>
                    <asp:TextBox ID="accountNumber" runat="server" CssClass="form-control"></asp:TextBox>

                    <label for="companyManager">مدير الشركة</label>
                    <asp:DropDownList ID="companyManager" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-6 px-5" id="gridCol" runat="server">
                    <div class="mx-auto h-100">
                        <asp:GridView ID="carsGrid" CssClass="w-100" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="false" SortExpression="ID" />
                                <asp:BoundField DataField="Number" HeaderText="رقم السيارة" SortExpression="Number" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                <asp:BoundField DataField="Model" HeaderText="الموديل" SortExpression="Capacity" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                <asp:BoundField DataField="Year" HeaderText="السنة" SortExpression="Capacity" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                <asp:BoundField DataField="Rent" HeaderText="السعر" SortExpression="Rent" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <ItemTemplate>
                                        <a href='CarDetails.aspx?ID=<%#Eval("ID") %>'><i class="fa fa-eye text-white"></i></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="carAddBtn" runat="server" Text="إضافة" OnClick="carAddBtn_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
                <div class="col-6 px-5" id="addCol" runat="server" visible="false">
                    <div class="w-50 mx-auto">
                        <label for="carNum">رقم السيارة</label>
                        <asp:TextBox ID="carNum" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="carDesc">الوصف</label>
                        <asp:TextBox ID="carDesc" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="model">موديل السيارة</label>
                        <asp:TextBox ID="model" runat="server"  CssClass="form-control"></asp:TextBox>
                        <label for="year">السنة</label>
                        <asp:TextBox ID="year" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                        <label for="rent">السعر</label>
                        <asp:TextBox ID="rent" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="carAddSaveBtn" runat="server" Text="حفظ" OnClick="carAddSaveBtn_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="carAddCancelBtn" runat="server" Text="إلغاء" OnClick="carAddCancelBtn_Click" CssClass="btn btn-danger" />
                    </div>
                </div>
            </div>

            <div class="text-center pt-5">
                <asp:Button ID="saveCarCompanyBtn" runat="server" OnClick="saveCarCompanyBtn_Click" CssClass="btn btn-primary btn-lg" Text="حفظ" />
                <a href="CarCompanyManager.aspx" class="btn btn-danger btn-lg">إلغاء</a>
            </div>

        </div>
    </div>
</asp:Content>
