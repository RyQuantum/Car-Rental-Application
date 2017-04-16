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
    public partial class Insert : Form
    {
        private SqlDataAdapter da;
        private SqlConnection con;
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        private DataSet ds;                
        public delegate void dele();
        public event dele evt;        
        public Insert()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox5.Text.Length != 0)
                {
                    
                        try
                        {
                            string str = "insert into ware (warename ,price,type,zip,stocks) values('" + textBox2.Text.Trim().ToString() + "'," + int.Parse(textBox3.Text.Trim()) + "," + 0 + "," + int.Parse(textBox4.Text.Trim()) + "," + int.Parse(textBox5.Text.Trim()) + ")";
                            da.InsertCommand = con.CreateCommand();
                            da.InsertCommand.CommandText = str;
                            con.Open();
                            da.InsertCommand.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("增加新商品成功！");
                            this.Dispose(true);
                            evt();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                    
                }
                else
                {
                    MessageBox.Show("增加新商品失败！");
                }
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
                if (c < 48 || c > 57 || c!=46)
                {
                    return false;
                }
            }
            return true;
        }

    }
}