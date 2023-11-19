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

namespace Project_PC_07_Module3
{
    public partial class PaymentHistoryForm : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader read = null;
        DateTime time = DateTime.Now;
        public PaymentHistoryForm()
        {
            InitializeComponent();
        }
        private void list()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Customer", 100);
            listView1.Columns.Add("Table", 100);
            listView1.Columns.Add("Status", 100);
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.View = View.Details;

            string sql = "select order_made_time as a, customer_name as b, table_number as c from payment join header_order on payment.header_order_id = header_order.id";
            con.Open();
            cmd = new SqlCommand(sql, con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["a"].ToString());
                item.SubItems.Add(read["b"].ToString());
                item.SubItems.Add(read["c"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView2.Clear();
            listView2.Columns.Add("Menu", 100);
            listView2.Columns.Add("Quantity", 100);
            listView2.Columns.Add("Price", 100);
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.MultiSelect = false;


            string id = listView1.SelectedItems[0].SubItems[0].Text;
            string sql = "select menu.name as a, detail_order.quantity as b, detail_order.order_price as c from menu join detail_order on detail_order.menu_id = menu.id join header_order on detail_order.header_order_id=header_order.id where header_order.order_made_time='" + id+"'";
            con.Open();
            cmd = new SqlCommand(sql, con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["a"].ToString());
                item.SubItems.Add(read["b"].ToString());
                item.SubItems.Add(read["c"].ToString());
                listView2.Items.Add(item);
            }
            con.Close();
        }

        private void PaymentHistoryForm_Load(object sender, EventArgs e)
        {
            list();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
