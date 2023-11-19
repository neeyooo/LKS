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
    public partial class PromotionForm : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read;

        public PromotionForm()
        {
            InitializeComponent();
        }
        private void clear()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);
            listView1.Columns.Add("Name", 250);
            listView1.Columns.Add("disc", 0);
            listView1.Columns.Add("min", 0);
            listView1.Columns.Add("start", 0);
            listView1.Columns.Add("end", 0);
            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
        }
        private void listdata()
        {
            clear();
            con.Open();
            string sql = "SELECT id,code,CAST(discount as int) as discount ,CAST(minimum_spent as int) as minimum_spent, CONVERT(nvarchar, start_time, 120) as start_time, CONVERT(nvarchar, end_time, 120) as end_time FROM promotion";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["code"].ToString());
                item.SubItems.Add(read["discount"].ToString());
                item.SubItems.Add(read["minimum_spent"].ToString());
                item.SubItems.Add(read["start_time"].ToString());
                item.SubItems.Add(read["end_time"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void PromotionForm_Load(object sender, EventArgs e)
        {
            listdata();
        }

        private void PromotionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "INSERT INTO promotion(code,discount,minimum_spent,start_time,end_time) VALUES ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            listdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            con.Open();
            string sql = "UPDATE promotion SET code='" + textBox1.Text + "', discount='" + textBox2.Text + "', minimum_spent='" + textBox3.Text + "', start_time='" + textBox4.Text + "', end_time='" + textBox5.Text + "' WHERE id='" + id + "'";
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
                string sql = "SELECT id,code,CAST(discount as int) as discount ,CAST(minimum_spent as int) as minimum_spent, CONVERT(nvarchar, start_time, 120) as start_time, CONVERT(nvarchar, end_time, 120) as end_time FROM promotion ORDER BY start_time ASC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["code"].ToString());
                    item.SubItems.Add(read["discount"].ToString());
                    item.SubItems.Add(read["minimum_spent"].ToString());
                    item.SubItems.Add(read["start_time"].ToString());
                    item.SubItems.Add(read["end_time"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                clear();
                con.Open();
                string sql = "SELECT id,code,CAST(discount as int) as discount ,CAST(minimum_spent as int) as minimum_spent, CONVERT(nvarchar, start_time, 120) as start_time, CONVERT(nvarchar, end_time, 120) as end_time FROM promotion ORDER BY start_time DESC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["code"].ToString());
                    item.SubItems.Add(read["discount"].ToString());
                    item.SubItems.Add(read["minimum_spent"].ToString());
                    item.SubItems.Add(read["start_time"].ToString());
                    item.SubItems.Add(read["end_time"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                clear();
                con.Open();
                string sql = "SELECT id,code,CAST(discount as int) as discount ,CAST(minimum_spent as int) as minimum_spent, CONVERT(nvarchar, start_time, 120) as start_time, CONVERT(nvarchar, end_time, 120) as end_time FROM promotion ORDER BY discount ASC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["code"].ToString());
                    item.SubItems.Add(read["discount"].ToString());
                    item.SubItems.Add(read["minimum_spent"].ToString());
                    item.SubItems.Add(read["start_time"].ToString());
                    item.SubItems.Add(read["end_time"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                clear();
                con.Open();
                string sql = "SELECT id,code,CAST(discount as int) as discount ,CAST(minimum_spent as int) as minimum_spent, CONVERT(nvarchar, start_time, 120) as start_time, CONVERT(nvarchar, end_time, 120) as end_time FROM promotion ORDER BY discount DESC";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["code"].ToString());
                    item.SubItems.Add(read["discount"].ToString());
                    item.SubItems.Add(read["minimum_spent"].ToString());
                    item.SubItems.Add(read["start_time"].ToString());
                    item.SubItems.Add(read["end_time"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                clear();
                con.Open();
                string sql = "SELECT id,code,CAST(discount as int) as discount ,CAST(minimum_spent as int) as minimum_spent, CONVERT(nvarchar, start_time, 120) as start_time, CONVERT(nvarchar, end_time, 120) as end_time FROM promotion WHERE end_time > GETDATE()";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["code"].ToString());
                    item.SubItems.Add(read["discount"].ToString());
                    item.SubItems.Add(read["minimum_spent"].ToString());
                    item.SubItems.Add(read["start_time"].ToString());
                    item.SubItems.Add(read["end_time"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();

            }
            if (comboBox2.SelectedIndex == 1)
            {
                clear();
                con.Open();
                string sql = "SELECT id,code,CAST(discount as int) as discount ,CAST(minimum_spent as int) as minimum_spent, CONVERT(nvarchar, start_time, 120) as start_time, CONVERT(nvarchar, end_time, 120) as end_time FROM promotion WHERE end_time < GETDATE()";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["id"].ToString());
                    item.SubItems.Add(read["code"].ToString());
                    item.SubItems.Add(read["discount"].ToString());
                    item.SubItems.Add(read["minimum_spent"].ToString());
                    item.SubItems.Add(read["start_time"].ToString());
                    item.SubItems.Add(read["end_time"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();

            }

        }
    }
}
