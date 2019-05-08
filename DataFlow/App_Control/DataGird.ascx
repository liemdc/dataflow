<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataGird.ascx.cs" Inherits="DataFlow.App_Control.DataGird" %>

<dx:ASPxGridView ID="GvLevelD" ClientInstanceName="GvLevelD" runat="server" Width="100%" >
    <ClientSideEvents Init="OnInit" BeginCallback="OnBeginCallback" EndCallback="OnEndCallback" ColumnResized="function(s, e) { OnColumnResized(s, e, 0); }" />
    <SettingsContextMenu Enabled="true" />
    <SettingsPager Mode="ShowPager" PageSize="20" FirstPageButton-Visible="true" LastPageButton-Visible="true" PageSizeItemSettings-Visible="true" PageSizeItemSettings-Position="Right" Summary-Text="Trang {0} / {1} (Số dòng: {2}):" PageSizeItemSettings-Caption="Số dòng 1 trang:" />
    <SettingsBehavior AllowDragDrop="true" ConfirmDelete="true" ColumnResizeMode="Control" EnableCustomizationWindow="true" EnableRowHotTrack="true" />
    <Settings VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Hidden" />
    <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true"/>
    <Styles DetailCell-Paddings-Padding="0" DetailCell-Paddings-PaddingBottom="8" />
</dx:ASPxGridView>
