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
    public partial class FormPromotion : Form
    {
        public static string waktu = DateTime.Now.ToString("yyyy-MM-dd");
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read = null;

        public FormPromotion()
        {
            InitializeComponent();
        }
        private void clearlist()
        {
            listView1.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("id", 20);
            listView1.Columns.Add("Code", 100);
            listView1.Columns.Add("Discount", 100);
            listView1.Columns.Add("Minimum Spend", 100);
            listView1.Columns.Add("Start", 100);
            listView1.Columns.Add("End", 100);
            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;

        }
        private void list()
        {
            clearlist();
            con.Open();

            string sql = "SELECT id,code,REPLACE(discount,'.00','') AS discount,REPLACE(minimum_spent,'.00','') AS minimum_spent,CONVERT(nvarchar,start_time,120) AS start_time,CONVERT(nvarchar,end_time,120) AS end_time FROM promotion";
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
        private void FormPromotion_Load(object sender, EventArgs e)
        {
            list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "INSERT INTO promotion(code, discount, minimum_spent, start_time, end_time) values (@code, @discount, @minimum, @start, @end)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@code", textBox1.Text);
            cmd.Parameters.AddWithValue("@discount", textBox2.Text);
            cmd.Parameters.AddWithValue("@minimum", textBox3.Text);
            cmd.Parameters.AddWithValue("@start", textBox4.Text);
            cmd.Parameters.AddWithValue("@end", textBox5.Text);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Inserted");
            }

            con.Close();
            list();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            string sql = "UPDATE promotion SET code=@code, discount=@discount, minimum_spent=@minimum, start_time=@start, end_time=@end where id="+id+"";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@code", textBox1.Text);
            cmd.Parameters.AddWithValue("@discount", textBox2.Text);
            cmd.Parameters.AddWithValue("@minimum", textBox3.Text);
            cmd.Parameters.AddWithValue("@start", textBox4.Text);
            cmd.Parameters.AddWithValue("@end", textBox5.Text);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Updated");
            }

            con.Close();
            list();
        }

        private void FormPromotion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            form1 form1 = new form1();
            form1.Show();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Start Date (ascending)")
            {
                clearlist();
                con.Open();

                string sql = "SELECT id,code,REPLACE(discount,'.00','') AS discount,REPLACE(minimum_spent,'.00','') AS minimum_spent,CONVERT(nvarchar,start_time,120) AS start_time,CONVERT(nvarchar,end_time,120) AS end_time FROM promotion ORDER BY start_time ASC";
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
            if (comboBox1.Text == "Start Date (descending)")
            {
                clearlist();
                con.Open();

                string sql = "SELECT id,code,REPLACE(discount,'.00','') AS discount,REPLACE(minimum_spent,'.00','') AS minimum_spent,CONVERT(nvarchar,start_time,120) AS start_time,CONVERT(nvarchar,end_time,120) AS end_time FROM promotion ORDER BY start_time DESC";
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
            if (comboBox1.Text == "Discount (ascending)")
            {
                clearlist();
                con.Open();

                string sql = "SELECT id,code,REPLACE(discount,'.00','') AS discount,REPLACE(minimum_spent,'.00','') AS minimum_spent,CONVERT(nvarchar,start_time,120) AS start_time,CONVERT(nvarchar,end_time,120) AS end_time FROM promotion ORDER BY discount ASC";
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
            if (comboBox1.Text == "Discount (descending)")
            {
                clearlist();
                con.Open();

                string sql = "SELECT id,code,REPLACE(discount,'.00','') AS discount,REPLACE(minimum_spent,'.00','') AS minimum_spent,CONVERT(nvarchar,start_time,120) AS start_time,CONVERT(nvarchar,end_time,120) AS end_time FROM promotion ORDER BY discount DESC";
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = waktu;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Active")
            {
                clearlist();
                con.Open();

                string sql = "SELECT id,code,REPLACE(discount,'.00','') AS discount,REPLACE(minimum_spent,'.00','') AS minimum_spent,CONVERT(nvarchar,start_time,120) AS start_time,CONVERT(nvarchar,end_time,120) AS end_time FROM promotion WHERE start_time > '" + waktu + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                read = cmd.ExecuteReader();

                while(read.Read())
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
            if (comboBox2.Text == "Expired")
            {
                clearlist();
                con.Open();

                string sql = "SELECT id,code,REPLACE(discount,'.00','') AS discount,REPLACE(minimum_spent,'.00','') AS minimum_spent,CONVERT(nvarchar,start_time,120) AS start_time,CONVERT(nvarchar,end_time,120) AS end_time FROM promotion WHERE end_time < '" + waktu + "'";
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
