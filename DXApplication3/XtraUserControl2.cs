using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Linq;
using System.Net;

namespace DXApplication3
{

    public partial class XtraUserControl2 : DevExpress.XtraEditors.XtraUserControl
    {

        private const string filterr = "https://api.eldis24.ru/api/v1/search/";
        private const string KEY = "eVCX2lzO7prHREze1TY2wglCAaHg7eHUNqJYUMi5Ps8zbzpLNLKqvKyenU5v6pPfMj35PG==";
        LoginEx loginEx = new LoginEx();
        WebClient webs = new WebClient();

        XtraUserControl1 usercontrol;

        public XtraUserControl2(XtraUserControl1 control)
        {

            InitializeComponent();
            usercontrol = control;

            

            checkedComboBoxEdit1.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit2.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit3.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit4.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit5.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit6.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit7.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit8.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit9.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit10.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit11.Size = new System.Drawing.Size(300, 300);
            checkedComboBoxEdit12.Size = new System.Drawing.Size(300, 300);


            webs.Headers.Add(HttpRequestHeader.Cookie, $"access_token={loginEx.Login(loginEx.login, loginEx.password)}");
            webs.Headers.Add("key", KEY);

        }


        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit11_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit10_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit9_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit8_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit7_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit12_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit1_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}organizations", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["organizations"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit1.Properties.DataSource = restest;
            checkedComboBoxEdit1.Properties.DisplayMember = "name";
            checkedComboBoxEdit1.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit2_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}typeObjects", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["typeObjects"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();


            checkedComboBoxEdit2.Properties.DataSource = restest;
            checkedComboBoxEdit2.Properties.DisplayMember = "name";
            checkedComboBoxEdit2.Properties.ValueMember = "id";

        }

        private void checkedComboBoxEdit3_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}modeObjects", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["modeObjects"].Select(x => new
            {
                id = (int)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit3.Properties.DataSource = restest;
            checkedComboBoxEdit3.Properties.DisplayMember = "name";
            checkedComboBoxEdit3.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit4_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}tags?entity=objects/list", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tags"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit4.Properties.DataSource = restest;
            checkedComboBoxEdit4.Properties.DisplayMember = "name";
            checkedComboBoxEdit4.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit5_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}tags?entity=modems/list", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tags"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit5.Properties.DataSource = restest;
            checkedComboBoxEdit5.Properties.DisplayMember = "name";
            checkedComboBoxEdit5.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit6_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}tags?entity=devices/list", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tags"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit6.Properties.DataSource = restest;
            checkedComboBoxEdit6.Properties.DisplayMember = "name";
            checkedComboBoxEdit6.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit7_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}tags?entity=tv/list", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tags"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit7.Properties.DataSource = restest;
            checkedComboBoxEdit7.Properties.DisplayMember = "name";
            checkedComboBoxEdit7.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit8_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}organizations", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["organizations"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit8.Properties.DataSource = restest;
            checkedComboBoxEdit8.Properties.DisplayMember = "name";
            checkedComboBoxEdit8.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit9_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}tv", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tv"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["address"],

            }).ToList();

            checkedComboBoxEdit9.Properties.DataSource = restest;
            checkedComboBoxEdit9.Properties.DisplayMember = "name";
            checkedComboBoxEdit9.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit10_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}addressLevels", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["addressLevels"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x?["name"],

            }).ToList();

            checkedComboBoxEdit10.Properties.DataSource = restest;
            checkedComboBoxEdit10.Properties.DisplayMember = "name";
            checkedComboBoxEdit10.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit11_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}users", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["users"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit11.Properties.DataSource = restest;
            checkedComboBoxEdit11.Properties.DisplayMember = "name";
            checkedComboBoxEdit11.Properties.ValueMember = "id";
        }

        private void checkedComboBoxEdit12_Properties_Enter(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filterr}organizations", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["organizations"].Select(x => new
            {
                id = (Guid)x["id"],
                name = (string)x["name"],

            }).ToList();

            checkedComboBoxEdit12.Properties.DataSource = restest;
            checkedComboBoxEdit12.Properties.DisplayMember = "name";
            checkedComboBoxEdit12.Properties.ValueMember = "id";
        }


        public static string organizations;
        public static string typeobject;
        public static string modeObjects;
        public static string TagsObject;
        public static string TagsModem;
        public static string TagsDevice;
        public static string TagsTV;
        public static string Owners;
        public static string Source;
        public static string Education;
        public static string inspector;
        public static string inspectionArea;

        private void checkedComboBoxEdit1_Properties_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit1.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            organizations = textid.Replace(" ", "");


        }
        private void checkedComboBoxEdit2_Properties_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit2.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            typeobject = textid.Replace(" ", "");

        }

        private void checkedComboBoxEdit3_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit3.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            modeObjects = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit4_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit4.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            TagsObject = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit5_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit5.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            TagsModem = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit6_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit6.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            TagsDevice = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit7_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit7.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            TagsTV = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit8_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit8.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            Owners = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit9_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit9.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            Source = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit10_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit10.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            Education = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit11_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit11.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            inspector = textid.Replace(" ", "");
        }

        private void checkedComboBoxEdit12_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            var filterid = checkedComboBoxEdit12.EditValue.ToString();
            var id = filterid.Split(',').ToArray();

            var textid = string.Join("|", id);
            inspectionArea = textid.Replace(" ", "");
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            usercontrol.FilterAPI();

            this.Dispose();

        }

    }


}