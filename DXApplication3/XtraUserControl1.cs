using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication3
{

    public partial class XtraUserControl1 : DevExpress.XtraEditors.XtraUserControl
    {
        
        private const string KEY = "eVCX2lzO7prHREze1TY2wglCAaHg7eHUNqJYUMi5Ps8zbzpLNLKqvKyenU5v6pPfMj35PG==";
        WebClient webs = new WebClient();
        LoginEx loginEx = new LoginEx();
        List<Button> button = new List<Button>();
        int page = 0;
        int currectpage;
        List<LoginEx.ObjectStruct> result;

        public XtraUserControl1()
        {
            InitializeComponent();
            result = loginEx.objectes("", 1);

            Data();

            gridView1.Columns[0].Caption = "Адрес";
            gridView1.Columns[1].Caption = "Тип объекта";
            gridView1.Columns[2].Caption = "Объект";
            gridView1.Columns[3].Caption = "Примечание";
            gridView1.Columns[4].Caption = "Дата создания";
            gridView1.Columns[5].Caption = "Потребитель";
            gridView1.Columns[6].Caption = "Мнемосхема";


        }

        private void XtraUserControl1_Load(object sender, EventArgs e)
        {
            loginEx.objectes("", 0);

            for (int i = 0; i < 6; i++)
            {

                button.Add(new Button());

                button[i].Text = i.ToString();
                button[i].Name = $"button{i}";

                button[i].Location = new Point(25 + (35 * i), 360);

                button[i].Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

                Controls.Add(button[i]);
                button[i].Height = 25;
                button[i].Width = 30;


                button[i].Click += ButtonOnClick;

            }

            button[0].Text = "Предыдущая";
            button[0].Width = 80;
            for (int i = 1; i < 6; i++)
            {
                button[i].Location = new Point(75 + (35 * i), 360);

            }

            button[5].Text = "Следующая";
            button[5].Width = 80;
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            Button buttontest = (Button)sender;


            loginEx.objectes("", 0);

            if (buttontest.Text == "Предыдущая")
            {
                currectpage = currectpage - 1;

            }
            else if (buttontest.Text == "Следующая")
            {
                if (currectpage == loginEx.numberOfPages)
                {

                }
                else
                {
                    currectpage = currectpage + 1;
                }

            }
            else
            {
                currectpage = Convert.ToInt32(buttontest.Text);
            }

            result = loginEx.objectes("", currectpage);

            if (currectpage == loginEx.numberOfPages)
            {
                Data();
            }
            else
            {

                if (buttontest.Name.ToString() == "button4")
                {
                    page++;
                    for (int i = 1; i <= 4; i++)
                    {
                        button[i].Text = (i + page + page).ToString();

                    }
                    Data();

                }
                Data();
            }


            if (buttontest.Text == "1")
            {

            }
            else
            {
                if (buttontest.Name.ToString() == "button1")
                {
                    page--;
                    for (int i = 4; i >= 1; i--)
                    {
                        button[i].Text = (page + page + i).ToString();
                    }
                }

            }
        }
        private async void textBox1_TextChanged(object sender, EventArgs e)
        {

            var search = textBox1.Text;

            await Task.Delay(3000);

            result = loginEx.objectes(search, 0);
            Data();

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            XtraUserControl2 xtraUserControl2 = new XtraUserControl2(this);
            gridControl1.Controls.Add(xtraUserControl2);
            xtraUserControl2.Location = new Point(400, 50);
        }

        public void FilterAPI()
        {
            string objects = "https://api.eldis24.ru/api/v1/objects/list";
            webs.Headers.Add(HttpRequestHeader.Cookie, $"access_token={loginEx.Login(loginEx.login, loginEx.password)}");
            webs.Headers.Add("key", KEY);
            webs.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=utf-8");
            var response = JObject.Parse(webs.UploadString($"{objects}", $"filter.org.id={XtraUserControl2.organizations}&filter.type.id={XtraUserControl2.typeobject}&filter.mode.id={XtraUserControl2.modeObjects}&filter.tag.id={XtraUserControl2.TagsObject}&filter.tagModem.id={XtraUserControl2.TagsModem}&filter.tag={XtraUserControl2.TagsDevice}&filter.tagTV.id={XtraUserControl2.TagsTV}&filter.payer.id={XtraUserControl2.Owners}&filter.sourceTV.id={XtraUserControl2.Source}&filter.addressLevel.id={XtraUserControl2.Education}&filter.inspector.id={XtraUserControl2.inspector}&filter.inspectionArea.id={XtraUserControl2.inspectionArea}"));
            var result = (object)response["response"]["objects"]["list"].Select(x => new 
            {
                address = (string)x["address"],
                typeObject = (string)x["typeObject"]["name"],
                name = (string)x["name"],
                consumer = (string)x["consumer"],
                createdOn = TOdateTime((long)x["createdOn"]),
                description = (string)x["description"],
                dashboardName = (string)x["dashboardName"],

            }).ToList();

            gridControl1.DataSource = result;



        }
        private DateTime TOdateTime(long createdOn)
        {
            var data = new DateTime(621355968230000000);
            return data.AddSeconds(createdOn);
        }
        private void Data()
        {

            this.gridControl1.DataSource = result;
        }

    }
}