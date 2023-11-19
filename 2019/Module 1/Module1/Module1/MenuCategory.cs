using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Module1
{
    public partial class MenuCategory : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read;

        public MenuCategory()
        {
            InitializeComponent();
        }
        private void clear()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("Name", 250);
            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
        }
        private void listdata()
        {
            clear();
            con.Open();
            string sql = "SELECT * FROM menu_category";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["name"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void MenuCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void MenuCategory_Load(object sender, EventArgs e)
        {
            listdata();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            if (listView1.SelectedItems[0].SubItems[1].Text == "Foods" ||listView1.SelectedItems[0].SubItems[1].Text == "Drinks" ||listView1.SelectedItems[0].SubItems[1].Text == "Snacks")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "INSERT INTO menu_category(name) VALUES ('" + textBox1.Text + "')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            listdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            con.Open();
            string sql = "UPDATE menu_category SET name='" + textBox1.Text + "' WHERE id='" + id +
                "'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            listdata();
        }
    }
}
