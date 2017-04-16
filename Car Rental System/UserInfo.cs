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
    public partial class UserInfo : Form
    {
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        private SqlConnection con;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter da;
        private DataSet ds;
        private SqlCommandBuilder d;
        int x;
        int y;

        public UserInfo()
        {
            InitializeComponent();
            b.DataSource = ".";
            b.InitialCatalog = "wkdl";
            b.IntegratedSecurity = true;
            con = new SqlConnection(b.ConnectionString);
            //this.skinengine1.skinfile = "macos.ssk";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDGV();
            //if (this.Text == "超级商品管理与查询")
            //{
            //    LoadDGV();
            //}
            //else
            //{
            //    button1.Enabled = false;
            //    button2.Enabled = false;
            //    button3.Enabled = false;
            //    button6.Enabled = false;
            //    button5.Text = "经典查询";
            //    textBox1.Enabled = false;
            //    LoadDGV();
            //    MessageBox.Show("您是普通员工，部分功能受限！", "系统提示");
            //}
        }
        private void LoadDGV()
        {
            //cmd.CommandText = "select id as 商品编号,warename as 商品名称,price as 单价,type as 已售出数量,zip as 保质期 from ware";
            cmd.CommandText = "select uFullName,uAddress,uPhone,uReservation from userlogin where usa = 'member'";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderText = "Address";
            dataGridView1.Columns[2].HeaderText = "Phone Number";
            dataGridView1.Columns[3].HeaderText = "Reservation";
            dataGridView1.RowHeadersVisible = false;

            setFridViewProperty();
        }

        private void setFridViewProperty()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.Rows[0].Selected = false;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Tables[0].Rows[x].Delete();
            d = new SqlCommandBuilder(da);
            da.Update(ds);
            MessageBox.Show("Delete Successfully！");
            LoadDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Insert ins = new Insert();
            ins.evt += new Insert.dele(LoadDGV);
            ins.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                if (textBox1.Text.Length != 0 || comboBox1.Text !="")
                {

                    string str = "select uFullName,uAddress,uPhone,uReservation from userlogin where usa = 'member' and";

                    dataGridView1.Columns[0].HeaderText = "Name";
                    dataGridView1.Columns[1].HeaderText = "Address";
                    dataGridView1.Columns[2].HeaderText = "Phone Number";
                    dataGridView1.Columns[3].HeaderText = "Reservation";

                    string oth = "";
                    string[] name = new string[2];
                    for (int j = 0; j < name.Length; j++)
                    {
                        name[j] = "";
                    }
                    if (textBox1.Text.Length != 0)
                    {
                        name[0] = " uFullName ='" + textBox1.Text.Trim() + "'";
                    }

                    if (comboBox1.Text.Length != 0)
                    {
                        if (comboBox1.Text == "Yes")
                        {
                            name[1] = " uReservation != ''";
                        } else
                        {
                            name[1] = " uReservation = ''";
                        }
                    }
                    
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (name[i].Length != 0)
                        {
                            str += name[i] + "and";
                        }
                    }
                    if (str == "select id,warename,price,zip,type,stocks from userlogin where usa = 'member' and")
                    {
                        oth = "select id,warename,price,zip,type,stocks from userlogin where usa = 'member'";
                        MessageBox.Show("不能为空!");
                        return;
                    }
                    else
                    {
                        oth = str.Substring(0, str.Length - 3);
                    }

                    //MessageBox.Show(oth);
                    da = new SqlDataAdapter(oth, con);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No result!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dataGridView1.DataSource = ds.Tables[0];
                    setFridViewProperty();
                }
                else
                {
                    MessageBox.Show("Please enter valid information.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            x = e.RowIndex;
            y = e.ColumnIndex;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Update u = new Update();
            u.evt += new Update.dele(LoadDGV);
            u.ShowDialog();
        }

        private void 查询所有SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDGV();
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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            LoadDGV();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            String id = dataGridView1.Rows[x].Cells[0].Value.ToString();
            String stock = dataGridView1.Rows[x].Cells[5].Value.ToString();
            if (int.Parse(stock) == 0)
            {
                MessageBox.Show("Inventory is empty. Please select others.");
            }
            else
            {
                string strc = "update ware set stocks=" + (int.Parse(stock) - 1) + " where [id]=" + id;
                da.InsertCommand = con.CreateCommand();
                da.InsertCommand.CommandText = strc;
                con.Open();
                da.InsertCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reserve successfully");
                LoadDGV();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}