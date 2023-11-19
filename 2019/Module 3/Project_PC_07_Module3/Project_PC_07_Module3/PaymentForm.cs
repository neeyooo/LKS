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
    public partial class PaymentForm : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader read = null;
        DateTime time = DateTime.Now;
        public static string ab;

        public PaymentForm()
        {
            InitializeComponent();
        }
        private void list()
        {
            listView1.Clear();
            listView1.Columns.Add("Table", 100);
            listView1.Columns.Add("Customer", 100);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false; 

            string sql = "SELECT * FROM header_order";
            con.Open();
            cmd = new SqlCommand(sql, con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["table_number"].ToString());
                item.SubItems.Add(read["customer_name"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list();
            label1.Text = time.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaymentConfirmationForm form1 = new PaymentConfirmationForm();
            form1.Show();
            this.Hide();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ab = listView1.SelectedItems[0].SubItems[0].Text;
            listView2.Clear();
            listView2.Columns.Add("Name", 100);
            listView2.Columns.Add("Quantity", 100);
            listView2.Columns.Add("Price", 100);
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.MultiSelect = false;

            
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            string sql = "select menu.name as a, detail_order.quantity as b, detail_order.order_price as c  from menu join detail_order on menu.id = detail_order.menu_id join header_order on header_order.id = detail_order.header_order_id where header_order.id='"+id+"'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
