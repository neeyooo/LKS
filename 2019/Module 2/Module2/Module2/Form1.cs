using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Module2
{
    public partial class Form1 : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read;

        public static string menuid;
        public static string nama;
        public static string desc;
        public static string price;
        public static string kondisi;
        public static string quantity;

        public Form1()
        {
            InitializeComponent();
        }
        private void clear()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Price", 100);
            listView1.Columns.Add("Description", 200);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
        }
        public void listdata(string where)
        {
            clear();
            con.Open();
            string sql = "SELECT id,name,CAST(price as int) as price, description FROM menu WHERE "+where+"";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["name"].ToString());
                item.SubItems.Add(read["price"].ToString());
                item.SubItems.Add(read["description"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        public void transferdata(string[] array)
        {
            if (kondisi == "tambah")
            {
                con.Open();
                string sql = "INSERT INTO header_order(order_made_time, table_number, customer_name) VALUES ('" + array[0] + "' , '" + comboBox1.Text + "' , '" + textBox1.Text + "') INSERT INTO detail_order(header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (SCOPE_IDENTITY(), '" + array[3] + "' , '" + array[2] + "' , '" + array[1] + "' , '" + array[0] + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

                ListViewItem item = new ListViewItem(array[0]);
                item.SubItems.Add(nama);
                item.SubItems.Add(array[1]);
                item.SubItems.Add(array[2]);
                item.SubItems.Add(array[3]);
                listView2.Items.Add(item);
            }
            if (kondisi == "tambah update")
            {
                con.Open();
                string sql = "INSERT INTO detail_order(header_order_id, menu_id, order_price, quantity, order_placed_time) SELECT header_order.id, '" + array[3] + "' , '" + array[2] + "' , '" + array[1] + "' , '" + array[0] + "' FROM header_order WHERE table_number = '" + comboBox1.Text + "' AND customer_name = '" + textBox1.Text + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

                ListViewItem item = new ListViewItem(array[0]);
                item.SubItems.Add(nama);
                item.SubItems.Add(array[1]);
                item.SubItems.Add(array[2]);
                item.SubItems.Add(array[3]);
                listView2.Items.Add(item);

            }
            if (kondisi == "update")
            {
                con.Open();
                string sql1 = "UPDATE detail_order SET header_order_id=header_order.id , menu_id='"+menuid+"' , order_price='"+array[2]+"' , quantity='"+array[1]+"' , order_placed_time='"+array[0]+ "' FROM header_order WHERE table_number='" + comboBox1.Text + "' AND customer_name='" + textBox1.Text + "' AND menu_id='" + menuid + "'";
                cmd = new SqlCommand(sql1, con);
                cmd.ExecuteNonQuery();
                con.Close();

                ListViewItem item = new ListViewItem(array[0]);
                item.SubItems.Add(nama);
                item.SubItems.Add(array[1]);
                item.SubItems.Add(array[2]);
                item.SubItems.Add(array[3]);
                listView2.Items.Add(item);
            }
            if (kondisi == "remove")
            {
                con.Open();
                string sql1 = "DELETE FROM detail_order WHERE header_order_id=(SELECT id FROM header_order WHERE table_number='"+comboBox1.Text+"' AND customer_name='"+textBox1.Text+"') AND menu_id='" + menuid+"'";
                cmd = new SqlCommand(sql1, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            hitungtotal();
        }
        private void hitungtotal()
        {
            int total = 0;
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems.Count > 1)
                {
                    total = total + int.Parse(item.SubItems[3].Text);
                    label5.Text = total.ToString();
                }
                if (item.SubItems.Count == 1)
                {
                    label5.Text = Form2.price.ToString();
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string where = "name LIKE '%%'";
            timer1.Start();
            listdata(where);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //favorite
            string where = "is_favourite='1'";
            listdata(where);
            label3.Text = "Favorite";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //foods
            string where = "menu_category_id='1'";
            listdata(where);
            label3.Text = "Foods";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //drinks
            string where = "menu_category_id='2'";
            listdata(where);
            label3.Text = "Drinks";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //snacks
            string where = "menu_category_id='3'";
            listdata(where);
            label3.Text = "Snacks";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //others
            string where = "menu_category_id!='1' AND menu_category_id!='2' AND menu_category_id!='3'";
            listdata(where);
            label3.Text = "Others";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string where = "name LIKE '%"+textBox2.Text+"%'";
            listdata(where);
            label3.Text = "Menu";
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            menuid = listView1.SelectedItems[0].SubItems[0].Text;
            nama = listView1.SelectedItems[0].SubItems[1].Text;
            price = listView1.SelectedItems[0].SubItems[2].Text;
            desc = listView1.SelectedItems[0].SubItems[3].Text;

            bool combo = String.IsNullOrEmpty(comboBox1.Text);
            bool texxt = String.IsNullOrEmpty(textBox1.Text);

            if (combo == true || texxt == true)
            {
                MessageBox.Show("Masukkan table dan nama terlebih dahulu");
            }
            else
            {
                if (listView2.Items.Count > 0)
                {
                    kondisi = "tambah update";
                }
                if (listView2.Items.Count < 1)
                {
                    kondisi = "tambah";
                }
                Form2 form = new Form2(this);
                form.Show();
            }
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            quantity = listView2.SelectedItems[0].SubItems[2].Text;
            menuid = listView2.SelectedItems[0].SubItems[4].Text;
            int hasil = int.Parse(listView2.SelectedItems[0].SubItems[3].Text) / int.Parse(listView2.SelectedItems[0].SubItems[2].Text);
            price = hasil.ToString();
            kondisi = "update";
            Form2 form = new Form2(this);
            form.Show();
        }
    }
}
