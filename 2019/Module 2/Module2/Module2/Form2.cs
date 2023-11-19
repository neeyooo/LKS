using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Module2
{
    public partial class Form2 : Form
    {
        public static string kondisi;
        public static int price;

        Form1 form1;
        public Form2(Form1 _form1)
        {
            InitializeComponent();
            form1 = _form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.nama;
            label2.Text = Form1.desc;
            label3.Text = Form1.price;
            if (Form1.kondisi == "update")
                label5.Text = Form1.quantity;
        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(label5.Text) < 1)
            {
                if (Form1.kondisi == "update")
                {
                    button3.Text = "Remove";
                    button3.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                }
            }
            else if (int.Parse(label5.Text) > 0)
            {
                button3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //-
            label5.Text = (int.Parse(label5.Text) - 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //+
            label5.Text = (int.Parse(label5.Text) + 1).ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string[] array = { };
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string quantity = label5.Text;

            if (Form1.kondisi == "tambah" || Form1.kondisi == "tambah update")
            {
                price = int.Parse(label5.Text) * int.Parse(Form1.price);
                array = new string[] { time, quantity, price.ToString() , Form1.menuid};
                form1.transferdata(array);
            }
            if (Form1.kondisi == "update")
            {
                price = int.Parse(label5.Text) * int.Parse(Form1.price);
                if (button3.Text == "Remove")
                {
                    Form1.kondisi = "remove";
                    form1.transferdata(array);
                    form1.listView2.Items.RemoveAt(form1.listView2.SelectedIndices[0]);
                }
                else
                {
                    form1.listView2.Items.RemoveAt(form1.listView2.SelectedIndices[0]);
                    array = new string[] { time, quantity, price.ToString(),Form1.menuid };
                    form1.transferdata(array);
                }
            }
            
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
