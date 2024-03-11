using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustStay.Web.BusinessLogic
{
    [Serializable]
    public class searchDto
    {
        private string atrcid;
        public string AtrcId
        {
            get { return atrcid; }
            set { atrcid = value; }
        }
        private string hr;
        public string Hr
        {
            get { return hr; }
            set { hr = value; }
        }
        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        private string frto;
        public string FrTo
        {
            get { return frto; }
            set { frto = value; }
        }
        private string rcbid;
        public string RestChairBookingId
        {
            get { return rcbid; }
            set { rcbid = value; }
        }
        private string rcpaymentid;
        public string RestChairPaymentId
        {
            get { return rcpaymentid; }
            set { rcpaymentid = value; }
        }
        private string orderid;
        public string OrderId
        {
            get { return orderid; }
            set { orderid = value; }
        }
        private string totalamount;
        public string TotalAmount
        {
            get { return totalamount; }
            set { totalamount = value; }
        }
        private string per;
        public string Per
        {
            get { return per; }
            set { per = value; }
        }
    }
}