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

namespace Module3
{
    public partial class Form1 : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read;
        public static double discount;
        public static string idpromo;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listdata("id");
        }
        private void clear()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("Table", 100);
            listView1.Columns.Add("Customer", 200);
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
        }        
        private void clear1()
        {
            listView2.Clear();
            listView2.Columns.Add("id", 0);
            listView2.Columns.Add("Name", 100);
            listView2.Columns.Add("Quantity", 50);
            listView2.Columns.Add("Price", 100);
            listView2.MultiSelect = false;
            listView2.FullRowSelect = true;
            listView2.View = View.Details;
        }
        private void listdata(string kondisi)
        {
            clear();
            con.Open();
            string sql = "SELECT * FROM header_order ORDER BY "+kondisi+"";
            cmd = new SqlCommand(sql, con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["table_number"].ToString());
                item.SubItems.Add(read["customer_name"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd, yyyy-MM-dd HH:mm:ss");
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT id,code,CAST(discount as int) as discount FROM promotion WHERE code='"+textBox1.Text+"'";
            cmd = new SqlCommand(sql, con);
            read = cmd.ExecuteReader();
            if (read.Read() == true)
            {
                idpromo = read["id"].ToString();
                discount = (double)read.GetInt32(2) / 100;
                MessageBox.Show("Berhasil mendapatkan discount " + read["discount"] + "%");
                label_discount.Text = read["discount"] + "%";
            }
            else
            {
                MessageBox.Show("Code tidak ditemukan");
            }
            con.Close();
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            int harga = 0;
            clear1();
            con.Open();
            string sql = "SELECT detail_order.id, menu.name, quantity, CAST(order_price as int) as price FROM detail_order INNER JOIN menu ON detail_order.menu_id=menu.id WHERE header_order_id='" + listView1.SelectedItems[0].SubItems[0].Text + "'";
            cmd = new SqlCommand(sql, con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["name"].ToString());
                item.SubItems.Add(read["quantity"].ToString());
                item.SubItems.Add(read["price"].ToString());
                listView2.Items.Add(item);
            }
            foreach (ListViewItem item in listView2.Items)
            {
                harga = harga + int.Parse(item.SubItems[3].Text);
                angka_subtotal.Text = harga.ToString();
            }
            angka_discount.Text = (harga * discount).ToString();
            int angkadiscount = int.Parse(angka_discount.Text);

            angka_tax.Text = ((harga + angkadiscount) * 0.1).ToString();
            int angkatax = int.Parse(angka_tax.Text);

            angka_service.Text = ((harga + angkadiscount + angkatax) * 0.05).ToString();
            int angkaservice = int.Parse(angka_service.Text);

            angka_total.Text = (harga + angkatax + angkaservice).ToString();

            con.Close();


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listdata("customer_name ASC");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                listdata("customer_name DESC");
            }
            if (comboBox1.SelectedIndex == 2)
            {
                listdata("table_number ASC");
            }
            if (comboBox1.SelectedIndex == 3)
            {
                listdata("table_number DESC");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();
        }
    }
}
