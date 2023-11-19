using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PC_07_Module2
{
    public partial class OrderPopUp : Form
    {
        DateTime jam = DateTime.Now;
        public static int price_new;
        public static string kondisi;

        OrderForm form1;
        public OrderPopUp(OrderForm _form1)
        {
            InitializeComponent();
            form1 = _form1;

        }
        private void OrderPopUp_Load(object sender, EventArgs e)
        {
            label1.Text = "" + OrderForm.nama;
            label2.Text = "" + OrderForm.desc;
            label3.Text = "" + OrderForm.harga;
            if(OrderForm.quantity == 0)
            {
                label6.Text = "1";
            }
            else
            {
                label6.Text = OrderForm.quantity.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OrderPopUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = (int.Parse(label6.Text) + 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = (int.Parse(label6.Text) - 1).ToString();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (OrderForm.quantity > 0 & int.Parse(label6.Text) > 0)
            {
                form1.listView2.Items.RemoveAt(form1.listView2.SelectedIndices[0]);
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string name = OrderForm.nama;
                string quantity = label6.Text;
                price_new = int.Parse(OrderForm.harga) * int.Parse(label6.Text);
                string notes = textBox1.Text;
                string menu_id = OrderForm.menuid;
                string[] array = new string[] { time, name, quantity, price_new.ToString(), notes, menu_id };
                kondisi = "update";
                form1.UpdatingListView(array);
                form1.UpdatingPrice();
            }
            else if(int.Parse(label6.Text) < 1 && OrderForm.quantity.ToString() != label6.Text)
            {
                form1.listView2.Items.RemoveAt(form1.listView2.SelectedIndices[0]);
                kondisi = "hapus";
                form1.UpdatingPrice();
            }
            else
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string name = OrderForm.nama;
                string quantity = label6.Text;
                price_new = int.Parse(OrderForm.harga) * int.Parse(label6.Text);
                string notes = textBox1.Text;
                string menu_id = OrderForm.menuid;
                string[] array = new string[] { time, name, quantity, price_new.ToString(), notes, menu_id };
                kondisi = "tambah";
                form1.UpdatingListView(array);
                form1.UpdatingPrice();
            }
            OrderForm.quantity = 0;
            this.Close();
        }

        private void label6_TextChanged_1(object sender, EventArgs e)
        {
            var result = OrderForm.quantity;
            if(label6.Text == "0")
            {
                if (result.ToString() != label6.Text)
                {
                    button1.Enabled = true;
                    button4.Enabled = false;
                    button1.Text = "Remove";
                }
                else
                {
                    button1.Enabled = false;
                    button4.Enabled = false;
                }
            }
            else
            {
                button1.Enabled = true;
                button4.Enabled = true;
            }
        }
    }
}
