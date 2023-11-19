using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Module3
{
    public partial class PaymentHistory : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read;

        public PaymentHistory()
        {
            InitializeComponent();
        }
        private void clear()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Customer", 100);
            listView1.Columns.Add("Table", 50);
            listView1.Columns.Add("Status", 100);
            listView1.Columns.Add("promoid", 0);
            listView1.Columns.Add("discount", 0);
            listView1.Columns.Add("name", 0);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
        }
        private void clear1()
        {
            listView2.Clear();
            listView2.Columns.Add("Menu", 100);
            listView2.Columns.Add("Quantity", 100);
            listView2.Columns.Add("Price", 100);
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.MultiSelect = false;
        }
        private void listdata(string kondisi)
        {
            clear();
            con.Open();
            string sql = "SELECT payment.id, header_order.id as headerid, header_order.order_made_time, header_order.customer_name, header_order.table_number, promotion_id, CAST(discount as int) as discount, promotion.code FROM payment FULL JOIN header_order ON payment.header_order_id=header_order.id LEFT JOIN promotion ON payment.promotion_id=promotion.id "+kondisi+"";
            cmd = new SqlCommand(sql, con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["headerid"].ToString());
                item.SubItems.Add(read["order_made_time"].ToString());
                item.SubItems.Add(read["customer_name"].ToString());
                item.SubItems.Add(read["table_number"].ToString());

                if (read["id"].ToString() == "")
                {
                    item.SubItems.Add("Unpaid");
                }
                else
                {
                    item.SubItems.Add("Paid");
                }
                item.SubItems.Add(read["promotion_id"].ToString());
                item.SubItems.Add(read["discount"].ToString());
                item.SubItems.Add(read["code"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void PaymentHistory_Load(object sender, EventArgs e)
        {
            listdata("");
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            string promoid = listView1.SelectedItems[0].SubItems[6].Text;
            int subtotal = 0;
            double discount;

            clear1();
            con.Open();
            string sql = "SELECT menu.name, detail_order.quantity, CAST(detail_order.order_price as int) as price FROM detail_order INNER JOIN menu ON detail_order.menu_id=menu.id INNER JOIN header_order ON detail_order.header_order_id=header_order.id WHERE header_order.id=" + listView1.SelectedItems[0].SubItems[1].Text+"";
            cmd = new SqlCommand(sql, con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["name"].ToString());
                item.SubItems.Add(read["quantity"].ToString());
                item.SubItems.Add(read["price"].ToString());
                listView2.Items.Add(item);
            }
            con.Close();
            foreach (ListViewItem item in listView2.Items)
            {
                subtotal = subtotal + int.Parse(item.SubItems[2].Text);
            }

            angka_subtotal.Text = subtotal.ToString();
            angka_tax.Text = (subtotal * 0.1).ToString();
            int angkatax = int.Parse(angka_tax.Text);

            angka_service.Text = (subtotal * 0.05).ToString();
            int angkaservice = int.Parse(angka_service.Text);

            if (listView1.SelectedItems[0].SubItems[6].Text == "")
            {
                angka_discount.Text = "";
                label5.Text = "DISCOUNT";
                hasil_discount.Text = "";
                angka_total.Text = (subtotal + angkatax + angkaservice).ToString();
            }
            else
            {
                angka_discount.Text = listView1.SelectedItems[0].SubItems[7].Text + "%";
                label5.Text = "DISCOUNT " + "(" + listView1.SelectedItems[0].SubItems[8].Text + ")";
                discount = (double)int.Parse(listView1.SelectedItems[0].SubItems[7].Text) / 100;
                hasil_discount.Text = (subtotal * discount).ToString();
                int angkadisc = int.Parse(hasil_discount.Text);
                angka_total.Text = (subtotal - angkadisc + angkatax + angkaservice).ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listdata("WHERE payment.id is not null");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                listdata("WHERE payment.id is null");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string a = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string b = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            listdata("WHERE order_made_time > '" + a + "' AND order_made_time < '" + b + "'");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string a = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string b = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            listdata("WHERE order_made_time > '" + a + "' AND order_made_time < '" + b + "'");
        }
    }
}
