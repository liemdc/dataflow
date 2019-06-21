using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataFlow
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataUtils.WriteLog(SystemModels.Fn_Get_MaDinhDanh("2020", "DH", 4, "Mã đơn hàng."));
        }
    }
}