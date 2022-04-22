using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication3
{
    public partial class XtraUserControl1 : DevExpress.XtraEditors.XtraUserControl
    {
        XtraUserControl2 xtraUserControl2 = new XtraUserControl2();
        LoginEx loginEx = new LoginEx();
        int page = 0;
        int currectpage;
        List<Button> button = new List<Button>();
        public XtraUserControl1()
        {
            InitializeComponent();
            var result = loginEx.objectes("", 1);
           
            gridControl1.DataSource = result;            

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

            var result = loginEx.objectes("", currectpage);

            if (currectpage == loginEx.numberOfPages)
            {
                gridControl1.DataSource = result;
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
                    gridControl1.DataSource = result;

                }
                gridControl1.DataSource = result;
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

            var result = loginEx.objectes(search, 0);
            gridControl1.DataSource = result;

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            gridControl1.Controls.Clear();
            var result = loginEx.objectes("", 1);
            string str = "";
            for (int i = 0; i < xtraUserControl2.filteer.Length; i++)
            {
                str = xtraUserControl2.filteer[i].Trim();
            }
            
            gridControl1.DataSource = result.Where(x => x.typeObject == str);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

            gridControl1.Controls.Add(xtraUserControl2);
            xtraUserControl2.Location = new Point(400, 50);
            
        }

        
    } 
}
