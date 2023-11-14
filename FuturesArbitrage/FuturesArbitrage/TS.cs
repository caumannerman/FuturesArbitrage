using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuturesArbitrage
{
    
    public class TS
    {
        public long id { get; set; }
        public String visited { get; set; }
        public String date { get; set; }
        public String sdontknow { get; set; }
        public String strCode { get; set; }
        public String strdQty { get; set; }
        public String sfarTrdPrice { get; set; }
        public String sorderNo { get; set; }
        public String strdPrice { get; set; }
        public String sbalanceType { get; set; }
        public String strdNo { get; set; }
        public String srpCode { get; set; }
        public String sside { get; set; }
        public String sfiller { get; set; }
        public String strdType { get; set; }
        public String slength { get; set; }
        public String strdTime { get; set; }
        public String smsgGb { get; set; }
        public String snearTrdPrice { get; set; }
        public String sdataCnt { get; set; }
        public String sacctNo { get; set; }
        public String sseq { get; set; }
        public String sbookCode { get; set; }
        public String sissueCode { get; set; }
        public String spurpose { get; set; }
    }

    public class TotalAsset
    {
        public String sissuecode { get; set; }
        public String date { get; set; }
        public String sbookcode { get; set; }
        public int quantity { get; set; }
        public Double pricesum { get; set; }
        public Double realprofit { get; set; }
        public String lastupdatetime { get; set; }
    }
}
