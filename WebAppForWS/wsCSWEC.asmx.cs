using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebAppForWS
{
    /// <summary>
    ///wsCSWEC 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class wsCSWEC : System.Web.Services.WebService, IWsCSWECSoap
    {
        public DataSet GET_ORDER_ATTACHMETNS(string PI_AP_USER, string PI_ORDER_NO)
        {
            DataSet ds = new DataSet();            
            DataTable dtERR = new DataTable("PO_ERR");
            dtERR.Columns.Add("PO_ERR_CDE", typeof(String));
            dtERR.Columns.Add("PO_ERR_MSG", typeof(String));

            //取得圖片
            DataTable dt = new DataTable("PO_TABLE");
            dt.Columns.Add("ORDER_NO", typeof(String));
            dt.Columns.Add("ATTACH_TYPE_ID", typeof(String));
            dt.Columns.Add("ATTACH_TYPE_NAME", typeof(String));
            dt.Columns.Add("ATTACH_FILE", typeof(Byte[]));

            DataRow row = dt.NewRow();
            row["ORDER_NO"] = PI_ORDER_NO;
            row["ATTACH_TYPE_ID"] = "ID1_FRONT";
            row["ATTACH_TYPE_NAME"] = "身分證正面";
            serviceGetFile serviceGetFile = new serviceGetFile();
            row["ATTACH_FILE"] = serviceGetFile.GetImage("身份證樣張-正面.jpg");
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["ORDER_NO"] = PI_ORDER_NO;
            row["ATTACH_TYPE_ID"] = "ID1_REAR";
            row["ATTACH_TYPE_NAME"] = "身分證反面";
            serviceGetFile = new serviceGetFile();
            row["ATTACH_FILE"] = serviceGetFile.GetImage("身份證樣張-背面.jpg");
            dt.Rows.Add(row);

            ds.Tables.Add(dt);

            row = dtERR.NewRow();
            row["PO_ERR_CDE"] = "00";
            row["PO_ERR_MSG"] = "";
            dtERR.Rows.Add(row);
            ds.Tables.Add(dtERR);

            return ds;
        }

        public DataSet PC_GET_HPS_BARGAIN_LOG(string PI_AP_USER, string PI_ORDER_NO)
        {
            throw new NotImplementedException();
        }

        public DataSet PC_UPDATE_ORDER_APPLY_INFO(string PI_AP_USER, string PI_ORDER_NO, string PI_RESERVE_DATE, string PI_SCMS_APPLY_DATE, string PI_SCMS_AMOUNT, string PI_SCMS_APPLY_NBR, string PI_MSISDN, string PI_SUBSCRID)
        {
            throw new NotImplementedException();
        }
    }
}
