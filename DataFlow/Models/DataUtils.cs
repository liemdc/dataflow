using CMS.SiteProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;

public class DataUtils {

    public static bool WriteLog(string strMessage) {
        string appPath = HttpContext.Current.Request.ApplicationPath;
        string physicalPath = HttpContext.Current.Request.MapPath(appPath);
        string strFileName = "WriteLog";
        try {
            FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", physicalPath, strFileName), FileMode.Append, FileAccess.Write);
            StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
            objStreamWriter.WriteLine(string.Format("Date: {0}", DateTime.Now));
            objStreamWriter.WriteLine(strMessage);
            objStreamWriter.Close();
            objFilestream.Close();
            return true;
        }
        catch (Exception ex) {
            return false;
        }
    }
    public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist){
        DataTable dtReturn = new DataTable();
        System.Reflection.PropertyInfo[] oProps = null;
        if (varlist == null) return dtReturn;
        foreach (T rec in varlist){
            if (oProps == null){
                oProps = ((Type)rec.GetType()).GetProperties();
                foreach (System.Reflection.PropertyInfo pi in oProps){
                    Type colType = pi.PropertyType;
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>))){
                        colType = colType.GetGenericArguments()[0];
                    }
                    dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                }
            }
            DataRow dr = dtReturn.NewRow();
            foreach (System.Reflection.PropertyInfo pi in oProps){
                dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                (rec, null);
            }
            dtReturn.Rows.Add(dr);
        }
        return dtReturn;
    }    
    public static bool CreateModule(string displayName, string Name){
        try {
            ResourceInfo newModule = new ResourceInfo();
            newModule.ResourceDisplayName = displayName;
            newModule.ResourceName = Name;
            ResourceInfoProvider.SetResourceInfo(newModule);
            return true;
        } catch { return false; }
    }
    public static bool DeleteModule(string resourceName){
        ResourceInfo deleteModule = ResourceInfoProvider.GetResourceInfo(resourceName);
        ResourceInfoProvider.DeleteResourceInfo(deleteModule);
        return (deleteModule != null);
    }
    public static bool CreatePermission(string displayName, string Name, string resourceName){
        ResourceInfo module = ResourceInfoProvider.GetResourceInfo(resourceName);
        if (module != null){
            PermissionNameInfo newPermission = new PermissionNameInfo();
            newPermission.PermissionDisplayName = displayName;
            newPermission.PermissionName = Name;
            newPermission.ResourceId = module.ResourceId;
            PermissionNameInfoProvider.SetPermissionInfo(newPermission);
            return true;
        } return false;
    }
    public static bool DeletePermission(string permissionName, string resourceName){
        PermissionNameInfo deletePermission = PermissionNameInfoProvider.GetPermissionNameInfo(permissionName, resourceName, null);
        PermissionNameInfoProvider.DeletePermissionInfo(deletePermission);
        return (deletePermission != null);
    }
}