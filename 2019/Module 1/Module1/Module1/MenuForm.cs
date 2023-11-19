using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Module1
{
    public partial class MenuForm : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read;
        public static string idmenucategory;
        public MenuForm()
        {
            InitializeComponent();
        }
        private void clear()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("idcategory", 0);
            listView1.Columns.Add("Name", 250);
            listView1.Columns.Add("price", 0);
            listView1.Columns.Add("desc", 0);
            listView1.Columns.Add("fav", 0);
            listView1.Columns.Add("category", 0);
            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
        }
        private void listdata()
        {
            clear();
            con.Open();
            string sql = "SELECT menu.id, menu_category_id as categoryid, menu.name, CAST(price as int) as price, description, is_favourite, menu_category.name as category FROM menu INNER JOIN menu_category ON menu.menu_category_id=menu_category.id";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["categoryid"].ToString());
                item.SubItems.Add(read["name"].ToString());
                item.SubItems.Add(read["price"].ToString());
                item.SubItems.Add(read["description"].ToString());
                item.SubItems.Add(read["is_favourite"].ToString());
                item.SubItems.Add(read["category"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void listcombo()
        {
            con.Open();
            string sql = "SELECT name FROM menu_category";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Load(read);
            comboBox2.Items.Add(dt);
            comboBox2.ValueMember = "name";
            comboBox2.DataSource = dt;
            con.Close();

        }
        private void listcombo1()
        {
            con.Open();
            string sql = "SELECT name FROM menu_category";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox3.Items.Add(dt);
            comboBox3.ValueMember = "name";
            comboBox3.DataSource = dt;
            con.Close();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            listdata();
            listcombo();
            listcombo1();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            if (listView1.SelectedItems[0].SubItems[5].Text == "True")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            comboBox3.Text = listView1.SelectedItems[0].SubItems[6].Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "INSERT INTO menu(menu_category_id, name, price, description, is_favourite) VALUES ('" + idmenucategory + "' , '" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + checkBox1.Checked + "')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            listdata();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makan = comboBox3.Text;
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "SELECT * FROM menu_category WHERE name LIKE '" + makan + "'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idmenucategory = read["id"].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            con.Open();
            string sql = "UPDATE menu SET menu_category_id='"+idmenucategory+"', name='"+textBox1.Text+"', price='"+textBox2.Text+"', description='"+textBox3.Text+"', is_favourite='"+checkBox1.Checked+"' WHERE id='"+id+"'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            listdata();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                clear();
                con.Open();
                string sql = "SELECT menu.id, menu_category_id as categoryid, menu.name, CAST(price as int) as price, description, is_favourite, menu_category.name as category FROM menu INNER JOIN menu_category ON menu.menu_category_id=menu_category.id ORDER BY price ASC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["categoryid"].ToString());
                    item.SubItems.Add(read["name"].ToString());
                    item.SubItems.Add(read["price"].ToString());
                    item.SubItems.Add(read["description"].ToString());
                    item.SubItems.Add(read["is_favourite"].ToString());
                    item.SubItems.Add(read["category"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                clear();
                con.Open();
                string sql = "SELECT menu.id, menu_category_id as categoryid, menu.name, CAST(price as int) as price, description, is_favourite, menu_category.name as category FROM menu INNER JOIN menu_category ON menu.menu_category_id=menu_category.id ORDER BY price DESC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["categoryid"].ToString());
                    item.SubItems.Add(read["name"].ToString());
                    item.SubItems.Add(read["price"].ToString());
                    item.SubItems.Add(read["description"].ToString());
                    item.SubItems.Add(read["is_favourite"].ToString());
                    item.SubItems.Add(read["category"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                clear();
                con.Open();
                string sql = "SELECT menu.id, menu_category_id as categoryid, menu.name, CAST(price as int) as price, description, is_favourite, menu_category.name as category FROM menu INNER JOIN menu_category ON menu.menu_category_id=menu_category.id ORDER BY name ASC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["categoryid"].ToString());
                    item.SubItems.Add(read["name"].ToString());
                    item.SubItems.Add(read["price"].ToString());
                    item.SubItems.Add(read["description"].ToString());
                    item.SubItems.Add(read["is_favourite"].ToString());
                    item.SubItems.Add(read["category"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                clear();
                con.Open();
                string sql = "SELECT menu.id, menu_category_id as categoryid, menu.name, CAST(price as int) as price, description, is_favourite, menu_category.name as category FROM menu INNER JOIN menu_category ON menu.menu_category_id=menu_category.id ORDER BY name DESC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["categoryid"].ToString());
                    item.SubItems.Add(read["name"].ToString());
                    item.SubItems.Add(read["price"].ToString());
                    item.SubItems.Add(read["description"].ToString());
                    item.SubItems.Add(read["is_favourite"].ToString());
                    item.SubItems.Add(read["category"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "SELECT menu.id, menu_category_id as categoryid, menu.name, CAST(price as int) as price, description, is_favourite, menu_category.name as category FROM menu INNER JOIN menu_category ON menu.menu_category_id=menu_category.id WHERE menu_category.name LIKE '" + comboBox2.Text + "'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["categoryid"].ToString());
                item.SubItems.Add(read["name"].ToString());
                item.SubItems.Add(read["price"].ToString());
                item.SubItems.Add(read["description"].ToString());
                item.SubItems.Add(read["is_favourite"].ToString());
                item.SubItems.Add(read["category"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
    }
}
