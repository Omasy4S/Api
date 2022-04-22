using DevExpress.XtraBars;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DXApplication3
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        XtraUserControl1 xtraUserControl1 = new XtraUserControl1();
        public Form1()
        {
            InitializeComponent();

        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            fluentDesignFormContainer1.Controls.Clear();
            fluentDesignFormContainer1.Controls.Add(xtraUserControl1);

            xtraUserControl1.Dock = DockStyle.Fill;
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {

        }
    }
    public class LoginEx
    {
        public string login = "student14052021@gmail.com";
        public string password = "a5581e6c";
        public string _token;
        public int currentpage;
        public int numberOfPages;
        


        private const string KEY = "eVCX2lzO7prHREze1TY2wglCAaHg7eHUNqJYUMi5Ps8zbzpLNLKqvKyenU5v6pPfMj35PG==";
        private const string ADDRESS = "https://api.eldis24.ru/api/v1/";
        private const string objects = "https://api.eldis24.ru/api/v1/objects/list";

        public string Login(string login, string password)
        {
            WebClient web = new WebClient();
            web.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            web.Headers.Add("key", KEY);
            var response = JObject.Parse(web.UploadString($"{ADDRESS}/users/login", $"login={login}&password={password}"));
            var result = (bool?)response["response"]["users"]["login"]["result"];

            if (result != true)
            {
                return _token;
            }

            var cookies = web.ResponseHeaders["Set-Cookie"];
            Regex reg = new Regex("access_token=(?<Token>[^;]+)");
            _token = reg.Match(cookies).Groups["Token"].Value;

            return _token;
        }
        public List<ObjectStruct> objectes(string search, int currentPage)
        {
            WebClient webs = new WebClient();
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            webs.Headers.Add(HttpRequestHeader.Cookie, $"access_token={Login(login, password)}");
            webs.Headers.Add("key", KEY);

            search = "?Search=" + search;

            var response = JObject.Parse(webs.UploadString($"{objects}{search}&page={currentPage}&limit=200", $"login={login}&password={password}"));
            var result = (object)response["response"]["objects"]["list"].Select(x => new ObjectStruct
            {
                address = (string)x["address"],
                typeObject = (string)x["typeObject"]["name"],
                name = (string)x["name"],
                consumer = (string)x["consumer"],
                createdOn = TOdateTime((long)x["createdOn"]),
                description = (string)x["description"],
                dashboardName = (string)x["dashboardName"],

            }).ToList();
            currentpage = (int)response["response"]["objects"]["pagination"]["currentPage"];
            numberOfPages = (int)response["response"]["objects"]["pagination"]["numberOfPages"];

           
            
            return (List<ObjectStruct>)result;

        }

        public DateTime TOdateTime(long createdOn)
        {
            var data = new DateTime(621355968230000000);
            return data.AddSeconds(createdOn);
        }
        public class ObjectStruct
        {
            public string address { get; set; }
            public string typeObject { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public DateTime createdOn { get; set; }
            public string consumer { get; set; }
            public string dashboardName { get; set; }

        }
    }

}
