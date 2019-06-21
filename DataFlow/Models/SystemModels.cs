using CMS.CMSHelper;
using CMS.GlobalHelper;
using CMS.SettingsProvider;
using CMS.SiteProvider;
using System;
using System.Data;
using System.Text;

public class SystemModels {

    /// <summary>
    /// Lấy mã định danh mới
    /// </summary>
    /// <param name="dataYear">Mã theo năm</param>
    /// <param name="dataTable">Tiếp đầu ngữ của bảng</param>
    /// <param name="dataLen">Chiều dài số tự tăng</param>
    /// <param name="dataTXT">Mô tả về mã định danh</param>
    /// <returns>Mã định danh</returns>
    public static string Fn_Get_MaDinhDanh(string dataYear, string dataTable, int dataLen, string dataTXT) {
        string maDinhDanh;
        string dataYY = string.IsNullOrEmpty(dataYear) ? DateTime.Now.Year.ToString().Substring(2, 2) : dataYear.Substring(2, 2);
        // Create new Custom table item provider
        CustomTableItemProvider customTableProvider = new CustomTableItemProvider(CMSContext.CurrentUser);
        // Prepares the code name of the custom table
        string Code_MaLuuTru = "DX.MaLuuTru";
        // Check if Custom table exists
        DataClassInfo DX_MaLuuTru = DataClassInfoProvider.GetDataClass(Code_MaLuuTru);

        maDinhDanh = "19000001";
        if (DX_MaLuuTru != null) {
            // Prepare the parameters
            string where = string.Format("MaTXT = '{0}{1}'", dataTable, dataYY);
            // Get the data set according to the parameters
            DataSet dataSet = customTableProvider.GetItems(Code_MaLuuTru, where, null, 1, "ItemID");
            if (!DataHelper.DataSourceIsEmpty(dataSet)) {
                // Get the custom table item ID
                int itemID = ValidationHelper.GetInteger(dataSet.Tables[0].Rows[0][0], 0);
                // Get the custom table item
                CustomTableItem DX_MaLuuTru_Item = customTableProvider.GetItem(itemID, Code_MaLuuTru);
                if (DX_MaLuuTru_Item != null) {
                    string maTXT = ValidationHelper.GetString(DX_MaLuuTru_Item.GetValue("MaTXT"), "");
                    int maNUM = ValidationHelper.GetInteger(DX_MaLuuTru_Item.GetValue("MaNUM"), 0);
                    int maLEN = ValidationHelper.GetInteger(DX_MaLuuTru_Item.GetValue("MaLEN"), 0);

                    // Set new values
                    DX_MaLuuTru_Item.SetValue("MaNUM", maNUM + 1);
                    // Save the changes
                    DX_MaLuuTru_Item.Update();

                    StringBuilder sb = new StringBuilder();
                    string newText = sb.Append('0', maLEN - maNUM.ToString().Length).ToString() + maNUM + 1;
                    maDinhDanh = maTXT + newText;
                }
            } else {
                // Create new custom table item
                CustomTableItem newItem = new CustomTableItem(Code_MaLuuTru, customTableProvider);

                // Set the ItemText field value
                newItem.SetValue("MaTXT", dataTable + dataYY);
                newItem.SetValue("maNUM", 1);
                newItem.SetValue("maLEN", dataLen);
                newItem.SetValue("ActiveNUM", true);
                newItem.SetValue("MoTaTXT", dataTXT);
                // Insert the custom table item into database
                newItem.Insert();

                StringBuilder sb = new StringBuilder();
                string newText = dataTable + dataYY + sb.Append('0', dataLen - 0.ToString().Length).ToString() + 1;
                maDinhDanh = newText;
            }
        }
        // Return
        return maDinhDanh;
    }
}