<%@ Page Title="حجز الغرفة" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoomReservation.aspx.cs" Inherits="TMSWeb.RoomReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-1 mt-1">

        <div class="row fs-5 justify-content-center align-items-center m-5 h-100 rounded-3 bg-black text-white bg-opacity-75 p-3 text-black-75">

            <div class="text-center bg-info rounded-3 bg-opacity-50 text-white p-4">
                <h3>حجز الغرفة</h3>
            </div>

            <div class="table-responsive">
                <asp:GridView ID="roomsGrid" runat="server"
                    Width="100%" CssClass="table text-white"
                    AutoGenerateColumns="false"
                    DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="الرقم" ReadOnly="True" Visible="false" SortExpression="ID" />
                        <asp:BoundField DataField="Number" HeaderText="الرقم" SortExpression="Number" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="Capacity" HeaderText="عدد الأسرة" SortExpression="Capacity" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="Rent" HeaderText="التكلفة / يوم" SortExpression="Rent" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="Description" HeaderText="الوصف" SortExpression="Description" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" HeaderStyle-Width="40%" />
                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                            <ItemTemplate>
                                <a href='RoomReservation.aspx?ID=<%#Eval("ID") %>' class="px-2"><i class="fa fs-2 fa-hand-pointer-o text-white"></i></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
