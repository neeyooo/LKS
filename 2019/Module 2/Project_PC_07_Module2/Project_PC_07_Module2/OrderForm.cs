using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_PC_07_Module2
{

    public partial class OrderForm : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True;MultipleActiveResultSets=True;";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read = null;

        public static string nama;
        public static string desc;
        public static string harga;
        public static string menuid;
        public static int quantity;
        private static string label;
        string headerid;

        private bool ada;
        public OrderForm()
        {
            InitializeComponent();
            
        }
        public void UpdatingListView(string[] array)
        {
            var ada = String.IsNullOrEmpty(comboBox1.Text);
            var ada1 = String.IsNullOrEmpty(textBox1.Text);
            

            if (ada | ada1)
            {
                MessageBox.Show("Pastikan table number dan customer name terisi");
            }
            else
            {
                if (OrderPopUp.kondisi == "tambah")
                {
                    ListViewItem lvi = new ListViewItem(array[0]);
                    lvi.SubItems.Add(array[1]);
                    lvi.SubItems.Add(array[2]);
                    lvi.SubItems.Add(array[3]);
                    lvi.SubItems.Add(array[4]);
                    lvi.SubItems.Add(array[5]);
                    this.listView2.Items.Add(lvi);
                    MessageBox.Show(listView2.Items.Count.ToString());
                }
                if (OrderPopUp.kondisi == "update")
                {
                    con.Open();
                    string sql = "SELECT header_order.id, menu_id FROM detail_order inner join header_order on detail_order.header_order_id=header_order.id where header_order.customer_name='"+textBox1.Text+"' and menu_id='"+menuid+"'";
                    cmd = new SqlCommand(sql, con);
                    read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        headerid = read["id"].ToString();
                        menuid = array[5];
                    }
                    string sql1 = "UPDATE detail_order SET header_order_id='"+headerid+"' , menu_id='"+menuid+"' , order_price='"+array[3]+"' , quantity='"+array[2]+"' , order_placed_time='"+array[0]+"' WHERE ";
                    cmd = new SqlCommand(sql1, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    ListViewItem lvi = new ListViewItem(array[0]);
                    lvi.SubItems.Add(array[1]);
                    lvi.SubItems.Add(array[2]);
                    lvi.SubItems.Add(array[3]);
                    lvi.SubItems.Add(array[4]);
                    lvi.SubItems.Add(array[5]);
                    this.listView2.Items.Add(lvi);

                }
            }
        }
        public void UpdatingPrice()
        {
            int count = 0;
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems.Count > 1)
                {
                    count = count + int.Parse(item.SubItems[3].Text);
                    // break;
                }
            }
            label5.Text = count.ToString();
        }
        private void clear_list()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Description", 200);
            listView1.Columns.Add("Price", 100);
            listView1.Columns.Add("menuid", 0);
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.MultiSelect = false;
        }
        private void favorite()
        {
            clear_list();
            con.Open();
            string sql = "SELECT menu_category.id as a, menu.name as b, menu.description as c, CAST(CAST(menu.price as int) as int) as d, menu.id from menu_category inner join menu on menu_category.id=menu.menu_category_id where menu.is_favourite='true'";

            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["a"].ToString());
                item.SubItems.Add(read["b"].ToString());
                item.SubItems.Add(read["c"].ToString());
                item.SubItems.Add(read["d"].ToString());
                item.SubItems.Add(read["id"].ToString());
                listView1.Items.Add(item);
            }

            label = "menu.is_favourite='true'";
            con.Close();
        }
        private void food()
        {
            string sql = "SELECT menu_category.id as a, menu.name as b, menu.description as c, CAST(menu.price as int) as d from menu_category inner join menu on menu_category.id=menu.menu_category_id where menu_category.id='1'";

            con.Open();
            clear_list();

            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["a"].ToString());
                item.SubItems.Add(read["b"].ToString());
                item.SubItems.Add(read["c"].ToString());
                item.SubItems.Add(read["d"].ToString());
                listView1.Items.Add(item);
            }
            label = "menu_category.id='1'";
            con.Close();
        }
        private void drink()
        {
            string sql = "SELECT menu_category.id as a, menu.name as b, menu.description as c, CAST(CAST(menu.price as int) as int) as d from menu_category inner join menu on menu_category.id=menu.menu_category_id where menu_category.id='2'";

            con.Open();
            clear_list();

            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["a"].ToString());
                item.SubItems.Add(read["b"].ToString());
                item.SubItems.Add(read["c"].ToString());
                item.SubItems.Add(read["d"].ToString());
                listView1.Items.Add(item);
            }
            label = "menu_category.id='2'";
            con.Close();
        }
        private void snack()
        {
            string sql = "SELECT menu_category.id as a, menu.name as b, menu.description as c, CAST(menu.price as int) as d from menu_category inner join menu on menu_category.id=menu.menu_category_id where menu_category.id='3'";

            con.Open();
            clear_list();

            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["a"].ToString());
                item.SubItems.Add(read["b"].ToString());
                item.SubItems.Add(read["c"].ToString());
                item.SubItems.Add(read["d"].ToString());
                listView1.Items.Add(item);
            }
            label = "menu_category.id='3'";
            con.Close();
        }
        private void other()
        {
            string sql = "SELECT menu_category_id as a, menu.name as b, menu.description as c, CAST(menu.price as int) as d FROM menu WHERE menu_category_id != 1 AND menu_category_id != 2 AND menu_category_id != 3";

            con.Open();
            clear_list();

            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["a"].ToString());
                item.SubItems.Add(read["b"].ToString());
                item.SubItems.Add(read["c"].ToString());
                item.SubItems.Add(read["d"].ToString());
                listView1.Items.Add(item);
            }
            label = "menu_category_id != 1 AND menu_category_id != 2 AND menu_category_id != 3";
            con.Close();
        }
        public string labeltext
        {
            get
            {
                return label5.Text;
            }
            set
            {
                label5.Text = value;
            }
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            favorite();
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            food();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drink();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            snack();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            other();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            favorite();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            nama = listView1.SelectedItems[0].SubItems[1].Text;
            desc = listView1.SelectedItems[0].SubItems[2].Text;
            harga = listView1.SelectedItems[0].SubItems[3].Text;
            menuid = listView1.SelectedItems[0].SubItems[4].Text;

            OrderPopUp mf = new OrderPopUp(this);
            mf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            clear_list();
            string sql = "SELECT menu_category.id as a, menu.name as b, menu.description as c, CAST(menu.price as int) as d  from menu_category inner join menu on menu_category.id = menu.menu_category_id where "+label+" and menu.name like '%"+textBox2.Text+"%'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["a"].ToString());
                item.SubItems.Add(read["b"].ToString());
                item.SubItems.Add(read["c"].ToString());
                item.SubItems.Add(read["d"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            time_label.Text = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            nama = listView2.SelectedItems[0].SubItems[1].Text;
            quantity = int.Parse(listView2.SelectedItems[0].SubItems[2].Text);

            OrderPopUp mf = new OrderPopUp(this);
            mf.Show();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ada = false;
            var ada1 = !String.IsNullOrEmpty(comboBox1.Text);

            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems.Count > 0)
                {
                    ada = true;
                   // break;
                }
                else
                {
                    ada = false;
                    break;
                }
            }
            if(ada & ada1)
            {
                MessageBox.Show("Order list sudah terisi, tidak bisa dihapus");
                textBox1.Text = "Customer Name";
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
