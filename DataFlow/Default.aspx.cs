
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DataFlow
{
    public partial class Default : System.Web.UI.Page
    {
        public class JsonData {
            public Nullable<Decimal> DX_DuKienGC_lapRap { get; set; }
            public Nullable<DateTime> DX_DuKienHT_lapRap { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_lapRap { get; set; }
            public Nullable<Decimal> DX_DuKienGC_NC { get; set; }
            public Nullable<DateTime> DX_DuKienHT_NC { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_NC { get; set; }
            public Nullable<Decimal> DX_DuKienGC_MC { get; set; }
            public Nullable<DateTime> DX_DuKienHT_MC { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_MC { get; set; }
            public Nullable<Decimal> DX_DuKienGC_PhayTay { get; set; }
            public Nullable<DateTime> DX_DuKienHT_PhayTay { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_PhayTay { get; set; }
            public Nullable<Decimal> DX_DuKienGC_Nhiet { get; set; }
            public Nullable<DateTime> DX_DuKienHT_Nhiet { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_Nhiet { get; set; }
            public Nullable<Decimal> DX_DuKienGC_Mai { get; set; }
            public Nullable<DateTime> DX_DuKienHT_Mai { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_Mai { get; set; }
            public Nullable<Decimal> DX_DuKienGC_WEDM { get; set; }
            public Nullable<DateTime> DX_DuKienHT_WEDM { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_WEDM { get; set; }
            public Nullable<Decimal> DX_DuKienGC_EDM { get; set; }
            public Nullable<DateTime> DX_DuKienHT_EDM { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_EDM { get; set; }
            public Nullable<Decimal> DX_DuKienGC_QA { get; set; }
            public Nullable<DateTime> DX_DuKienHT_QA { get; set; }
            public Nullable<DateTime> DX_ThucTeHT_QA { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //JsonData data = new JsonData{};

            //data.DX_DuKienGC_EDM = 100;

            //JObject o = (JObject)JToken.FromObject(data);

            //DataUtils.WriteLog(o.ToString(Formatting.None));

            //JObject rx = JObject.Parse(o.ToString(Formatting.None));

            //rx["DX_DuKienGC_EDM1"] = 1234;

            //DataUtils.WriteLog(rx.ToString());

            //DataUtils.WriteLog(rx.Properties().FirstOrDefault().Name);

            //string json = @"{
            //  'CongDoanThoiGian': {
            //    'CongDoan1': '100',
            //    'CongDoan2': '100',
            //    'CongDoan3': '100',
            //    'CongDoan4': '100',
            //    'CongDoan5': '100',
            //    'CongDoan6': '100'
            //  }
            //}";



            //JObject rss = JObject.Parse(json);

            //JObject channel = (JObject)rss["CongDoanThoiGian"];

            //channel["CongDoan4"] = 800;

            //channel.Property("CongDoan1").Remove();

            //channel.Property("CongDoan4").AddAfterSelf(new JProperty("CongDoan41", "400"));

            //DataUtils.WriteLog(channel["CongDoan400"] == null ? "Null Data" : channel["CongDoan400"].ToString());

            //DataUtils.WriteLog(rss.ToString(Formatting.None));

            List<person> lp = new List<person>();
            person p = new person();
            p.name = "Chervine";
            p.surname = "Bhiwoo";
            p.country = "Mauritius";

            person p2 = new person();
            p2.name = "Chervine2";
            p2.surname = "Bhiwoo2";
            p2.country = "Mauritius2";

            lp.Add(p);
            lp.Add(p2);

            

            var xmlperson = ObjectToXMLGeneric<List<person>>(lp);

            XDocument doc = XDocument.Load(xmlperson);

            XElement alt = doc.Descendants("person").Where(x => (string)x.Attribute("name") == "Chervine2").FirstOrDefault();
            alt.Value = "00000000";

            DataUtils.WriteLog(xmlperson);

            DataUtils.WriteLog(doc.ToString());

        }

        public static String ObjectToXMLGeneric<T>(T filter) {
            string xml = null;
            using (StringWriter sw = new StringWriter()) {

                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, filter);
                try {
                    xml = sw.ToString();
                } catch (Exception e) {
                    throw e;
                }
            }
            return xml;
        }

        [Serializable]
        public class person {
            public string name { get; set; }
            public string surname { get; set; }
            public string country { get; set; }
        }
    }
}