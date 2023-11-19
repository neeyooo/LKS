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

namespace Project_PC_07_Module3
{
    public partial class PaymentConfirmationForm : Form
    {
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=belajar;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader read = null;
        DateTime time = DateTime.Now;
        public static string a;

        public PaymentConfirmationForm()
        {
            InitializeComponent();
        }
        private void list()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            string sql = "select header_order.order_made_time as a, header_order.table_number as b, header_order.customer_name as c, payment.amount_to_pay as d, payment.amount_paid as e from header_order join payment on header_order.id = payment.header_order_id where header_order.order_made_time='" + PaymentForm.ab + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {


            }
            con.Close();

        }
    }
}
