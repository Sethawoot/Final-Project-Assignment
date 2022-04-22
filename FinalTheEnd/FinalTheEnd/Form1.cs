using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTheEnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
           
           

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("กรุณากรอก Username");
                textBox1.Focus();
            }
            if (textBox2.Text == "")
            {
            MessageBox.Show("กรุณากรอก Password");
            textBox2.Focus();

            }
            else if (textBox1.Text != "Test" || textBox2.Text != "786")
            {
                MessageBox.Show("กรุณาตรวจสอบ Username และ Password ของท่านให้ถูกต้อง");
                textBox2.Focus();
                textBox2.SelectAll();
            }
            else
            {
                this.Hide();
                Main00 f2 = new Main00();
                f2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ขอบคุณค่ะ/ครับ", "ออกโปรแกรม");
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
