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
    public partial class Update : Form
    {
        private SqlDataAdapter da;
        public delegate void dele();
        public event dele evt;       
        private SqlConnection con;
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        private DataSet ds;
        private DBTools db;
        DLbh c = DLbh.getIns();
        public Update()
        {
            InitializeComponent();
            b.DataSource = ".";
            b.InitialCatalog = "wkdl";
            b.IntegratedSecurity = true;
            con = new SqlConnection(b.ConnectionString);
            da = new SqlDataAdapter("select id as 商品编号,warename as 商品名称,price as 单价,type as 已售出数量,zip as 保质期 from ", con);
            ds = new DataSet();
            //this.skinengine1.skinfile = "macos.ssk";
        }

        private void Update_Load(object sender, EventArgs e)
        {
            db = new DBTools(".", "wkdl", true, "sa", "wdxg");
            SqlDataReader b = db.getResult("Select * from ware where id=" + c.Num);

            while (b.Read())
            {
           
                textBox1.Text = b["id"].ToString();
                textBox2.Text = b["warename"].ToString();
                textBox3.Text = b["price"].ToString();
                textBox4.Text = b["type"].ToString();
                textBox5.Text = b["zip"].ToString();
                textBox6.Text = b["stocks"].ToString();
            }

            db.Disconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Length == 0)
                    {
                        MessageBox.Show("不能有任何一项为空！", "系统提示");
                    }
                    else
                    {

                        string strc = "update ware set warename='" + textBox2.Text.Trim().ToString() + "',price=" + int.Parse(textBox3.Text.Trim()) + ",type=" + int.Parse(textBox4.Text.Trim()) + ",zip=" + int.Parse(textBox5.Text.Trim()) + ",stocks=" + int.Parse(textBox6.Text.Trim()) + " where [id]=" + c.Num;
                        da.InsertCommand = con.CreateCommand();
                        da.InsertCommand.CommandText = strc;
                        con.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        con.Close();
                        this.Dispose(true);
                        evt();
                    }      

               
            }
            catch (Exception)
            {
                MessageBox.Show("数据类型不符，请核对后再插入！","系统提示");
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        

    }
}