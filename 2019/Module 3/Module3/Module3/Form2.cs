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
    public partial class Form2 : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        SqlDataReader read;

        Form1 form1;
        public Form2(Form1 _form1)
        {
            InitializeComponent();
            form1 = _form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            textBox2.Text = form1.listView1.SelectedItems[0].SubItems[1].Text;
            textBox4.Text = form1.listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = form1.angka_total.Text;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {
                textBox5.Text = textBox3.Text;
                textBox5.Enabled = false;
            }
            else
            {
                textBox5.Enabled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(textBox3.Text);
                int b = int.Parse(textBox5.Text);
                if (textBox5.Text == "")
                {
                    MessageBox.Show("");
                    textBox6.Clear();
                }
                else
                {
                    textBox6.Text = (a - b).ToString();
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql;
            if (String.IsNullOrEmpty(Form1.idpromo))
            {
                sql = "INSERT INTO payment(header_order_id, payment_type, amount_to_pay, amount_paid) VALUES ('" + form1.listView1.SelectedItems[0].SubItems[0].Text + "' , '" + comboBox1.Text + "' , '" + textBox3.Text + "' , '" + textBox5.Text + "')";
            }
            else
            {
                sql = "INSERT INTO payment(header_order_id, promotion_id, payment_type, amount_to_pay, amount_paid) VALUES ('" + form1.listView1.SelectedItems[0].SubItems[0].Text + "' , '" + Form1.idpromo + "' , '" + comboBox1.Text + "' , '" + textBox3.Text + "' , '" + textBox5.Text + "')";
            }
            cmd = new SqlCommand(sql, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("terbayar");
            }
        }
    }
}
