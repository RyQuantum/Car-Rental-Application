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
    public partial class SelectJD : Form
    {
        //private String scr = "";
        public SelectJD()
        {
            InitializeComponent();
            //this.skinengine1.skinfile = "macos.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";     
            if (IsNumeric(textBox1.Text.Trim()))
            {
                DBTools db = new DBTools(".", "wkdl", true, "sa", "wdxg");    
                SqlDataReader b = db.getResult("Select * from ware where id=" + textBox1.Text.Trim());
                if (b.Read())
                {
                    textBox2.Text = b["warename"].ToString();
                    textBox3.Text = b["price"].ToString();
                    textBox4.Text = b["type"].ToString();
                    textBox5.Text = b["zip"].ToString();
                    textBox6.Text = b["stocks"].ToString();
                }
                else
                {
                    MessageBox.Show("没有此商品！", "系统提示");
                }
                b.Close();
                db.Disconnect();
            }
            else
            {
                MessageBox.Show("商品编号无效！", "系统提示");
            }          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
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

        private void SelectJD_Load(object sender, EventArgs e)
        {

        }

    }
}
