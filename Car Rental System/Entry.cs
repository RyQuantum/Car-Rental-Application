using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Super_market
{
    public partial class Entry : Form
    {
        Random rnd = new Random();
        DBTools db;
        private List<string> bid = new List<string>();
        private SqlDataAdapter da;
        private DataSet ds;
        private SqlConnection con;
        private SqlConnectionStringBuilder bbb = new SqlConnectionStringBuilder();
        public Entry()
        {
            bbb.DataSource = ".";
            bbb.InitialCatalog = "wkdl";
            bbb.IntegratedSecurity = true;
            con = new SqlConnection(bbb.ConnectionString);
            da = new SqlDataAdapter("select id as 商品编号,warename as 商品名称,price as 单价,type as 已售出数量,zip as 保质期,stocks as 库存 from ", con);
            InitializeComponent();
            //this.skinengine1.skinfile = "macos.ssk";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; 
            listView1.View = View.Details;
            listView1.Columns.Add("商品名称");
            listView1.Columns.Add("入库数量");
            listView1.Columns.Add("保质期(月)");
            listView1.Columns.Add("商品单价");
            listView1.Columns.Add("入库时间");

            listView1.Columns[0].Width = 80;
            listView1.Columns[1].Width = 80;
            listView1.Columns[2].Width = 80;
            listView1.Columns[3].Width = 80;
            listView1.Columns[4].Width = 120;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label6.Text = dt.ToLocalTime().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db = new DBTools(".", "wkdl", true, "sa", "wdxg");
                if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0)
                {
                    MessageBox.Show("不能有任何一项为空！", "系统提示");
                }
                if (textBox2.Text.Trim().Equals('0'))
                {
                    MessageBox.Show("入库数量不能为0", "系统提示");
                    return;
                }
                else
                {
                    if (IsNumeric(textBox2.Text.Trim()) && IsNumeric(textBox3.Text.Trim()) && IsNumeric(textBox4.Text.Trim()))
                    {
                        string oth = "select id,warename,price,type,zip,stocks from ware where warename='" + textBox1.Text.Trim().ToString() + "'";
                        da = new SqlDataAdapter(oth, con);
                        ds = new DataSet();
                        da.Fill(ds);
                        string str;
                        if (ds.Tables[0].Rows.Count == 0)
                            str = "insert into ware (warename ,price,type,zip,stocks) values('" + textBox1.Text.Trim().ToString() + "'," + int.Parse(textBox4.Text.Trim()) + "," + 0 + "," + int.Parse(textBox3.Text.Trim()) + "," + int.Parse(textBox2.Text.Trim()) + ")";
                        else
                            str = "update ware set price=" + int.Parse(textBox4.Text.Trim()) + ",zip=" + int.Parse(textBox3.Text.Trim()) + ",stocks=stocks+" + int.Parse(textBox2.Text.Trim()) + " where [warename]='" + textBox1.Text.Trim().ToString() + "'";
                        da.InsertCommand = con.CreateCommand();
                        da.InsertCommand.CommandText = str;
                        con.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("增加新商品成功！");
                        ListViewItem l = new ListViewItem();
                        l.Text = textBox1.Text.ToString();
                        l.Tag = l.Text;
                        bid.Add(l.Tag.ToString());
                        l.SubItems.Add(textBox2.Text.ToString());
                        l.SubItems.Add(textBox3.Text.ToString());
                        l.SubItems.Add(textBox4.Text.ToString());
                        l.SubItems.Add(label6.Text.ToString());
                        listView1.Items.Add(l);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("除商品名称都只能是数字", "系统提示");
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }

                }
                db.Disconnect();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        private bool IsNumeric(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(str);
            foreach (byte c in bytestr)
            {
                if (c < 48 || c > 57)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
