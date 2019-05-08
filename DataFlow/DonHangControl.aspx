<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DonHangControl.aspx.cs" Inherits="DataFlow.DonHangFlow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plcMain" runat="server">
    <asp:Label ID="lblTest" Text="text" runat="server" />
    <dx:ASPxPageControl ID="DonHangControl" Width="100%" runat="server" CssClass="dxDonHang" ActiveTabIndex="0" EnableHierarchyRecreation="True" OnInit="DonHangControl_Init" >
        <TabPages>
            <dx:TabPage Name="DanhSachDonHang">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl1" runat="server">
                        <uControl:DataGird ID="Test" runat="server" />
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Name="QuanLyDonHang">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl2" runat="server">
                        test
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Name="KhachHang">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl3" runat="server">
                        test
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Name="LoaiKhuon">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl4" runat="server">
                        test
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Name="CongDoan">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl5" runat="server">
                        test
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
</asp:Content>
