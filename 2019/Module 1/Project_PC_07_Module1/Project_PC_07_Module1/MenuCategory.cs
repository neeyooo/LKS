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

namespace Project_PC_07_Module1
{
    public partial class MenuCategory : Form
    {

        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read = null;

        public MenuCategory()
        {
            InitializeComponent();
        }
        private void list()
        {
            listView1.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("MenuCategory", 100);
            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;

            con.Open();

            string sql = "SELECT * FROM menu_category";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString(), 0);
                item.SubItems.Add(read["name"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            
            string sql = "INSERT INTO menu_category values ('"+textBox1.Text+"')";
            cmd = new SqlCommand(sql, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Inserted");
            }
            
            con.Close();
            list();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            list();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(listView1.SelectedItems[0].SubItems[1].Text == "Foods" || listView1.SelectedItems[0].SubItems[1].Text == "Drinks" || listView1.SelectedItems[0].SubItems[1].Text == "Snacks")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            string sql = "UPDATE menu_category set name=('" +textBox1.Text + "') where id=('" + id + "')";
            cmd = new SqlCommand(sql, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Updated");
            }
            con.Close();
            list();
        }

        private void MenuCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            form1 form1 = new form1();
            form1.Show();
        }
    }
}
