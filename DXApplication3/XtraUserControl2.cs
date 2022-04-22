using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace DXApplication3
{
    
    public partial class XtraUserControl2 : DevExpress.XtraEditors.XtraUserControl
    {
        public string[] filteer;
        private const string filter = "https://api.eldis24.ru/api/v1/search/";
        private const string KEY = "eVCX2lzO7prHREze1TY2wglCAaHg7eHUNqJYUMi5Ps8zbzpLNLKqvKyenU5v6pPfMj35PG==";
        LoginEx loginEx = new LoginEx();
        WebClient webs = new WebClient();
        
        public XtraUserControl2()
        {
            InitializeComponent();
            
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
        
        private void checkedComboBoxEdit1_Click(object sender, EventArgs e)
        {           
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}organizations", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["organizations"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit1.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit1.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit1.Properties.Items.Add(restest[i].name);
                }
                      
            
        }

        private void checkedComboBoxEdit2_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}typeObjects", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["typeObjects"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit2.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit2.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit2.Properties.Items.Add(restest[i].name);
                }

            filteer = checkedComboBoxEdit2.Text.Split(',',' ');
        }

        private void checkedComboBoxEdit3_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}modeObjects", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["modeObjects"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit3.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit3.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit3.Properties.Items.Add(restest[i].name);
                }
            
        }

        private void checkedComboBoxEdit4_Click(object sender, EventArgs e)
        {

            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}tags?entity=objects/list", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tags"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit4.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit4.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit4.Properties.Items.Add(restest[i].name);
                }
        }

        private void checkedComboBoxEdit5_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}tags?entity=modems/list", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tags"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit5.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit5.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit5.Properties.Items.Add(restest[i].name);
                }
        }

        private void checkedComboBoxEdit6_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}tags?entity=devices/list", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tags"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit6.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit6.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit6.Properties.Items.Add(restest[i].name);
                }
        }

        private void checkedComboBoxEdit7_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}tags?entity=tv/list", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tags"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit7.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit7.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit7.Properties.Items.Add(restest[i].name);
                }
        }

        private void checkedComboBoxEdit8_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}organizations", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["organizations"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit8.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit8.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit8.Properties.Items.Add(restest[i].name);
                }
        } 

        private void checkedComboBoxEdit9_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}tv", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["tv"].Select(x => new
            {
                name = (string)x["address"],

            }).ToList();
            checkedComboBoxEdit9.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit9.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit9.Properties.Items.Add(restest[i].name);
                }
        }

        private void checkedComboBoxEdit10_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}addressLevels", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["addressLevels"].Select(x => new
            {
                name = (string)x?["name"],

            }).ToList();
            checkedComboBoxEdit10.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit10.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit10.Properties.Items.Add(restest[i].name);
                }
        }

        private void checkedComboBoxEdit11_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}users", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["users"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit11.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit11.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit11.Properties.Items.Add(restest[i].name);
                }
        }

        private void checkedComboBoxEdit12_Click(object sender, EventArgs e)
        {
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var test = JObject.Parse(webs.UploadString($"{filter}organizations", $"login={loginEx.login}&password={loginEx.password}"));
            var restest = test["response"]["search"]["organizations"].Select(x => new
            {
                name = (string)x["name"],

            }).ToList();
            checkedComboBoxEdit12.Properties.EditValueType = EditValueTypeCollection.List;
            if (checkedComboBoxEdit12.Properties.Items.Count < 2)
                for (int i = 0; i < restest.Count; i++)
                {
                    checkedComboBoxEdit12.Properties.Items.Add(restest[i].name);
                }

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
        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

    }
}