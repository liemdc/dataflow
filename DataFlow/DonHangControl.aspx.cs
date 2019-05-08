using CMS.CMSHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataFlow
{
    public partial class DonHangFlow : System.Web.UI.Page {
        string[] tabText = new string[] { "Danh sách đơn hàng", "Quản lý đơn hàng", "Khách hàng", "Loại khuôn", "Công đoạn" };
        string[] tabName = new string[] { "DanhSachDonHang1", "QuanLyDonHang", "KhachHang", "LoaiKhuon", "CongDoan" };
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(CMSContext.CurrentSiteName);
            //Response.Write(CMSContext.IsAuthenticated().ToString());
            //Response.Write(CMSContext.CurrentUser.IsAuthorizedPerResource("Functions", "ManHinhDungChungDonHang"));
            //lblTest.Visible = true;
        }

        protected void DonHangControl_Init(object sender, EventArgs e) {
            DonHangControl.TabStyle.Font.Name = "Arial";
            DonHangControl.TabStyle.Font.Size = new FontUnit(12, UnitType.Pixel);
            DonHangControl.TabStyle.Width = new Unit(100, UnitType.Percentage);
            for (int i = 0; i < tabText.Length; i++) {
                DonHangControl.TabPages[i].Text = tabText[i];
                DonHangControl.TabPages[i].Name = tabName[i];
                //DonHangControl.TabPages[i].Visible = CMSContext.CurrentUser.IsAuthorizedPerResource("DonHangControl", tabName[i]);
            }            
        }
    }
}