<%@ Page Title="إدارة شركة الطيران" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageFlightCompany.aspx.cs" Inherits="TMSWeb.ManageFlightCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                <h3>إدارة شركة الطيران</h3>
            </div>

            <div class="row p-2 fs-5 fw-bold text-center bg-white bg-opacity-25 m-3">
                <div class="col-6 fs-4 fw-bold">
                    معلومات الشركة
                </div>
                <div class="col-6  fs-4 fw-bold">
                    الرحلات
                </div>
            </div>
            <div class="row p-2">
                <div class="col-4 px-5">
                    <div class=" m-auto">
                        <label for="companyName">اسم الشركة</label>
                        <asp:TextBox Enabled="false" ID="companyName" runat="server" CssClass="form-control"></asp:TextBox>

                        <label for="companyDesc">الوصف</label>
                        <asp:TextBox Enabled="false" ID="companyDesc" runat="server" CssClass="form-control"></asp:TextBox>

                        <label for="phoneNumber">رقم الهاتف</label>
                        <asp:TextBox Enabled="false" ID="phoneNumber" runat="server" CssClass="form-control" type="number"></asp:TextBox>

                        <label for="email">البريد الالكتروني</label>
                        <asp:TextBox Enabled="false" ID="email" runat="server" CssClass="form-control" type="email"></asp:TextBox>

                        <label for="accountNumber">رقم الحساب</label>
                        <asp:TextBox Enabled="false" ID="accountNumber" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <div class="col-8 px-2" id="gridCol" runat="server">
                    <div class="w-100 m-auto">
                        <div class="mx-auto h-100">
                            <asp:GridView ID="flightsGrid" CssClass="w-100" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="false" SortExpression="ID" />
                                    <asp:BoundField DataField="Origin.Name" HeaderText="المغادرة" SortExpression="Origin.Name" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                    <asp:BoundField DataField="Destination.Name" HeaderText="الوصول" SortExpression="Destination.Name" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                    <asp:BoundField DataField="DepartureDate" HeaderText="المغادرة" SortExpression="DepartureDate" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                    <asp:BoundField DataField="ArriveDate" HeaderText="الوصول" SortExpression="ArriveDate" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href='FlightDetails.aspx?ID=<%#Eval("ID") %>' class="px-2"><i class="fa fs-2 fa-eye text-white"></i></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="flightAddBtn" runat="server" Text="إضافة" OnClick="flightAddBtn_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <div class="col-6 px-5" id="addCol" runat="server" visible="false">
                    <div class="w-50 mx-auto">
                        <label for="originDD">الانطلاق</label>
                        <asp:DropDownList ID="originDD" runat="server" CssClass="form-control" />
                        <label for="destinationDD">الوصول</label>
                        <asp:DropDownList ID="destinationDD" runat="server" CssClass="form-control" />
                        <label for="sdate">تاريخ المغادرة</label>
                        <div class="row">
                            <div class="col-6">
                                <asp:TextBox ID="sdate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="stime" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <label for="edate">تاريخ الوصول</label>
                        <div class="row">
                            <div class="col-6">
                                <asp:TextBox ID="edate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="etime" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <label for="capacity">عدد المقاعد</label>
                        <asp:TextBox ID="capacity" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                        <label for="price">السعر</label>
                        <asp:TextBox ID="price" runat="server" type="number" CssClass="form-control"></asp:TextBox>
                        <div class="btn-group-lg p-2 text-center">
                            <asp:Button ID="flightAddSaveBtn" runat="server" Text="حفظ" OnClick="flightAddSaveBtn_Click" CssClass="btn btn-outline-primary fw-bold" />
                            <asp:Button ID="flightAddCancelBtn" runat="server" Text="إلغاء" OnClick="flightAddCancelBtn_Click" CssClass="btn btn-outline-danger fw-bold" />
                        </div>

                        <div class="text-center text-lg-end mt-2 pt-2 m-auto fw-bold" style="color: #ffd800">
                            <asp:Label class="fs-4 text-cente pe-auto m-auto" ID="ErrorLBL" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="text-center pt-5">
                <%--                <asp:Button ID="saveFlightCompanyBtn" runat="server" OnClick="saveFlightCompanyBtn_Click" CssClass="btn btn-primary btn-lg" Text="حفظ" />--%>
                <a href="UserPage.aspx" class="btn btn-danger btn-lg">إلغاء</a>
            </div>

        </div>
    </div>
</asp:Content>
