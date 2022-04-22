using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTheEnd
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "วันพีช เล่ม 101") textBox3.Text = "65";
            if (comboBox1.Text == "มหาเวทย์ผนึกมาร เล่ม 0") textBox3.Text = "80";
            if (comboBox1.Text == "เบอร์เซิร์ก เล่ม 37") textBox3.Text = "135";
            if (comboBox1.Text == "มายฮีโร่อาคาเดเมีย เล่ม 32") textBox3.Text = "65";
            if (comboBox1.Text == "ไฮคิว เล่ม 45") textBox3.Text = "70";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Good nigth and Good Luck", "ออกจากโปรแกรม");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();

            maskedTextBox1.Text = "___-___ ____";

            comboBox1.Text = "---เลือก---";
            comboBox2.Text = "";

            textBox1.Focus();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int P1, A1, Sum;
            P1 = int.Parse(textBox3.Text);
            A1 = int.Parse(comboBox2.Text);
            Sum = P1 * A1;


            textBox4.Text = Sum.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Item 1 comboBox 1 
            comboBox1.Items.Add("วันพีช เล่ม 101");
            comboBox1.Items.Add("มหาเวทย์ผนึกมาร เล่ม 0");
            comboBox1.Items.Add("เบอร์เซิร์ก เล่ม 37");
            comboBox1.Items.Add("มายฮีโร่อาคาเดเมีย เล่ม 32");
            comboBox1.Items.Add("ไฮคิว เล่ม 45");

            //Item 2 comboBox 2 
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            comboBox2.Items.Add("6");
            comboBox2.Items.Add("7");
            comboBox2.Items.Add("8");
            comboBox2.Items.Add("9");
            comboBox2.Items.Add("10");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            int K, B, T;

            if (e.KeyCode == Keys.Enter)
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("กรุณาใส่จำนวนเงินของคุณ", "ผิดพลาด");
                }
                else
                {
                    K = int.Parse(textBox4.Text);
                    B = int.Parse(textBox5.Text);
                    if (B < K)
                    {
                        MessageBox.Show("ยอดเงินของคุณไม่เพียงพอ", "ผิดพลาด");
                        textBox5.SelectAll();
                    }
                    else
                    {
                        T = B - K;
                        textBox6.Text = T.ToString();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[n].Cells[1].Value = maskedTextBox1.Text;
            dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
            dataGridView1.Rows[n].Cells[3].Value = comboBox2.Text;
            dataGridView1.Rows[n].Cells[4].Value = textBox4.Text;
            dataGridView1.Rows[n].Cells[5].Value = DateTime.Now.ToString();

        }

        private void filToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string MManga = readAllLine[i];
                    string[] manga = MManga.Split(',');
                    mangaX mmangZ = new mangaX(manga[0], manga[1], manga[2], manga[3], manga[4], manga[5]);
                    addDataToGridView("ชื่อ", "เบอร์โทรศัพท์", "รายชื่อมังงะ", "จำนวนเล่ม", "ราคา", "วัน/เดือน/เวลา");

                }

            }
        }

        private void addDataToGridView(string v1, string v2, string v3, string v4, string v5, string v6)
        {
            throw new NotImplementedException();


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(.csv)|.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}    