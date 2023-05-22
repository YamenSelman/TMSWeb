<%@ Page Title="حجز سيارة" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarReservation.aspx.cs" Inherits="TMSWeb.CarReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="table-responsive">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h4>تفاصيل الحجز</h4>
                    <div class="row">
                        <div class="col-4">المدينة</div>
                        <div class="col-4">من</div>
                        <div class="col-4">إلى</div>
                        <%--<div class="col-3">عدد الغرف</div>--%>
                    </div>
                    <div class="row mt-2">
                        <div class="col-4">
                            <asp:DropDownList ID="cityDD" runat="server" CssClass="form-control" OnSelectedIndexChanged="cityDD_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="sdate" TextMode="Date" CssClass="form-control" runat="server" OnTextChanged="getCars" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="edate" TextMode="Date" CssClass="form-control" runat="server" OnTextChanged="getCars" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="text-center text-lg-end mt-2 pt-2 m-auto fw-bold" style="color: #ffd800">
                        <asp:Label class="fs-4 text-cente pe-auto m-auto" ID="ErrorLBL" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="table-responsive mt-3" id="resDiv" runat="server" visible="false">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h4>تأكيد الحجز</h4>
                </div>

                <div class="px-5 text-black fs-3 fw-bold">
                    <div class="row m-1 bg-white bg-opacity-75">
                        <div class="col-3"></div>
                        <div class="col-3">الشركة</div>
                        <div class="col-6">
                            <asp:Label ID="rescompany" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row m-1 bg-white bg-opacity-75">
                        <div class="col-3"></div>
                        <div class="col-3">السيارة</div>
                        <div class="col-6">
                            <asp:Label ID="rescar" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row m-1 bg-white bg-opacity-75">
                        <div class="col-3"></div>
                        <div class="col-3">المدة</div>
                        <div class="col-6">
                            <asp:Label ID="resperiod" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row m-1 bg-white bg-opacity-75">
                        <div class="col-3"></div>
                        <div class="col-3 ">التكلفة</div>
                        <div class="col-6">
                            <asp:Label ID="resprice" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="mt-2 row btn-group-lg m-auto text-center">
                        <asp:Button ID="confirmRes" runat="server" class="btn accordion-body btn-lg btn-outline-success w-25 m-auto" Text="تأكيد الحجز" OnClick="confirmRes_Click" />
                        <a href="UserPage.aspx" class="btn accordion-body btn-lg btn-outline-danger w-25 m-auto">إلغاء</a>
                    </div>
                </div>
            </div>

            <div class="table-responsive mt-3" id="carsDiv" runat="server" visible="false">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h4>السيارات المتوفرة</h4>
                </div>
                <asp:GridView ID="carsGrid" runat="server"
                    Width="100%" CssClass="table text-white"
                    AutoGenerateColumns="false"
                    DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="false" SortExpression="ID" />
                        <asp:BoundField DataField="Number" HeaderText="الرقم" SortExpression="Number" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="15%" />
                        <asp:BoundField DataField="Model" HeaderText="الطراز" SortExpression="Model" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="Year" HeaderText="السنة" SortExpression="Year" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="15%" />
                        <asp:BoundField DataField="Rent" HeaderText="التكلفة / يوم" SortExpression="Rent" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" HeaderStyle-Width="15%" />
                        <asp:BoundField DataField="Description" HeaderText="الوصف" SortExpression="Description" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" HeaderStyle-Width="35%" />
                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                            <ItemTemplate>
                                <asp:LinkButton ID="rlb" CommandArgument='<%#Eval("ID")%>' class='fa fs-2 fa-hand-pointer-o text-white text-decoration-none' Text="" OnClick="rlb_Click" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="table-responsive mt-3">
                <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                    <h4>شركات السيارات</h4>
                </div>
                <asp:GridView ID="companiesGrid" runat="server"
                    Width="100%" CssClass="table text-white"
                    AutoGenerateColumns="false"
                    DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="false" SortExpression="ID" />
                        <asp:BoundField DataField="Name" HeaderText="الشركة" SortExpression="Name" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="40%" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="رقم الهاتف" SortExpression="PhoneNumber" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="Email" HeaderText="البريد الالكتروني" SortExpression="Email" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" HeaderStyle-Width="30%" />
                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                            <ItemTemplate>
                                <asp:LinkButton ID="hlb" CommandArgument='<%#Eval("ID")%>' class='fa fs-2 fa-hand-pointer-o text-white text-decoration-none' Text="" OnClick="hlb_Click" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
