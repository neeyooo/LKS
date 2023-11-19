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
    public partial class MenuForm : Form
    {
        public string id_menu_category;
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read;
        public MenuForm()
        {
            InitializeComponent();
        }
        private void clear_list()
        {
            listView1.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("id", 0); //0
            listView1.Columns.Add("id", 0); //1
            listView1.Columns.Add("Name", 100); //2
            listView1.Columns.Add("Category", 100); //3
            listView1.Columns.Add("Price", 100); //4
            listView1.Columns.Add("Description", 100); //5
            listView1.Columns.Add("Favorite", 50); //6
            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
        }
        private void list_listview()
        {
            clear_list();
            con.Open();
            string sql = "select menu.id,menu_category.id as id_menu,menu.name,menu_category.name as category,REPLACE(price,'.00','') as price,menu.description,menu.is_favourite from menu_category, menu where menu.menu_category_id=menu_category.id";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString(), 0);
                item.SubItems.Add(read["id_menu"].ToString());
                item.SubItems.Add(read["name"].ToString());
                item.SubItems.Add(read["category"].ToString());
                item.SubItems.Add(read["price"].ToString());
                item.SubItems.Add(read["description"].ToString());
                item.SubItems.Add(read["is_favourite"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void list_combobox1()
        {
            con.Open();
            string sql = "select name from menu_category";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Load(read);
            comboBox3.ValueMember = "name";
            comboBox3.DataSource = dt;
            con.Close();
        }
        private void list_combobox()
        {
            con.Open();

            string sql = "SELECT * FROM menu_category";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                comboBox2.Items.Add(read["name"].ToString());
            }
            con.Close();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            list_listview();
            list_combobox();
            list_combobox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "INSERT INTO menu(name,menu_category_id,price,description,is_favourite) values (@name, @category, @price , @description, @favourite)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@category", id_menu_category);
            cmd.Parameters.AddWithValue("@price", textBox3.Text);
            cmd.Parameters.AddWithValue("@description", textBox4.Text);
            cmd.Parameters.AddWithValue("@favourite", checkBox1.Checked);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Inserted");
            }

            con.Close();
            list_listview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            string sql = "UPDATE menu set name=@name, menu_category_id=@category, price=@price, description=@description, is_favourite=@favourite where id=" + id + "";
            cmd = new SqlCommand(sql, con);
         
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@category", id_menu_category);
            cmd.Parameters.AddWithValue("@price", textBox3.Text);
            cmd.Parameters.AddWithValue("@description", textBox4.Text);
            cmd.Parameters.AddWithValue("@favourite", checkBox1.Checked);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Updated");
            }

            con.Close();
            list_listview();
            list_combobox1();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            form1 form1 = new form1();
            form1.Show();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox3.Text =listView1.SelectedItems[0].SubItems[3].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            //textBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            if(listView1.SelectedItems[0].SubItems[6].Text == "True")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(comboBox1.Text == "Price (ascending)")
            {
                clear_list();
                con.Open();

                string sql = "SELECT menu.id, menu_category.id as id_menu, menu.name, menu_category.name as category, CAST(price AS int) as price, description, is_favourite FROM menu INNER JOIN menu_category ON menu.menu_category_id = menu_category.id order by price ASC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString(), 0);
                    item.SubItems.Add(read["id_menu"].ToString());
                    item.SubItems.Add(read["name"].ToString());
                    item.SubItems.Add(read["category"].ToString());
                    item.SubItems.Add(read["price"].ToString());
                    item.SubItems.Add(read["description"].ToString());
                    item.SubItems.Add(read["is_favourite"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if(comboBox1.Text == "Price (descending)")
            {
                clear_list();
                con.Open();

                string sql = "SELECT menu.id, menu_category.id as id_menu, menu.name, menu_category.name as category, CAST(price AS int) as price, description, is_favourite FROM menu INNER JOIN menu_category ON menu.menu_category_id = menu_category.id order by price DESC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString(), 0);
                    item.SubItems.Add(read["id_menu"].ToString());
                    item.SubItems.Add(read["name"].ToString());
                    item.SubItems.Add(read["category"].ToString());
                    item.SubItems.Add(read["price"].ToString());
                    item.SubItems.Add(read["description"].ToString());
                    item.SubItems.Add(read["is_favourite"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if(comboBox1.Text == "Name (ascending)")
            {
                clear_list();
                con.Open();

                string sql = "SELECT menu.id, menu_category.id as id_menu, menu.name, menu_category.name as category, CAST(price AS int) as price, description, is_favourite FROM menu INNER JOIN menu_category ON menu.menu_category_id = menu_category.id order by name ASC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString(), 0);
                    item.SubItems.Add(read["id_menu"].ToString());
                    item.SubItems.Add(read["name"].ToString());
                    item.SubItems.Add(read["category"].ToString());
                    item.SubItems.Add(read["price"].ToString());
                    item.SubItems.Add(read["description"].ToString());
                    item.SubItems.Add(read["is_favourite"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if(comboBox1.Text == "Name (descending)")
            {
                clear_list();
                con.Open();

                string sql = "SELECT menu.id, menu_category.id as id_menu, menu.name, menu_category.name as category, CAST(price AS int) as price, description, is_favourite FROM menu INNER JOIN menu_category ON menu.menu_category_id = menu_category.id order by name DESC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString(), 0);
                    item.SubItems.Add(read["id_menu"].ToString());
                    item.SubItems.Add(read["name"].ToString());
                    item.SubItems.Add(read["category"].ToString());
                    item.SubItems.Add(read["price"].ToString());
                    item.SubItems.Add(read["description"].ToString());
                    item.SubItems.Add(read["is_favourite"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBox2.Text;
            clear_list();
            con.Open();

            string sql = "SELECT menu.id, menu_category_id as id_menu, menu.name, menu_category.name as category, CAST(price AS int) as price, description, is_favourite from menu inner join menu_category ON menu.menu_category_id = menu_category.id where menu_category.name = '"+category+"'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString(), 0);
                item.SubItems.Add(read["id_menu"].ToString());
                item.SubItems.Add(read["name"].ToString());
                item.SubItems.Add(read["category"].ToString());
                item.SubItems.Add(read["price"].ToString());
                item.SubItems.Add(read["description"].ToString());
                item.SubItems.Add(read["is_favourite"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string makan = comboBox3.Text;
            string sql = "SELECT * FROM menu_category WHERE name LIKE '"+makan+"'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                id_menu_category = read["id"].ToString();
            }
            con.Close();
        }
    }
}
