using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PressureSwitch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text =  comboBox1.Text;
            label10.Text = comboBox1.Text;
            label14.Text = comboBox1.Text;
            label13.Text = comboBox1.Text;
            label18.Text = textBox3.Text + " " + label5.Text;
            label17.Text = textBox4.Text + " " + label5.Text;
            label16.Text = trackBar1.Value.ToString() + " " + label5.Text;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox3.Text, out number))
                trackBar1.Maximum = (int)(number * precision);
            label18.Text = textBox3.Text + " " + label5.Text;
            ub = number;
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox4.Text, out number))
                trackBar1.Minimum = (int)(number*precision);
            label17.Text = textBox4.Text +" " + label5.Text;
            lb = number;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            if (lb >= ub)
                MessageBox.Show("Lower limit is higher than Upper Limit. Try change the limits");
            label16.Text = trackBar1.Value.ToString() + " " + label5.Text;

            if (ca == 1)
                if (no == 0)
                {
                    if (trackBar1.Value > sp)
                    {
                        panel1.BackColor = System.Drawing.Color.Red;
                        panel2.BackColor = System.Drawing.Color.Transparent;
                        no = 1;
                    }
                }
                
            if(ca ==1)
                if(no ==1)
                {
                    if (trackBar1.Value < (sp - db))
                    {
                        panel1.BackColor = System.Drawing.Color.Transparent;
                        panel2.BackColor = System.Drawing.Color.Red;
                        no = 0;
                    }
                }
            if (ca == 0)
                if (no == 0)
                {
                    if (trackBar1.Value < sp)
                    {
                        panel1.BackColor = System.Drawing.Color.Red;
                        panel2.BackColor = System.Drawing.Color.Transparent;
                        no = 1;
                    }
                }

            if (ca == 0)
                if (no == 1)
                {
                    if (trackBar1.Value > (sp + db))
                    {
                        panel1.BackColor = System.Drawing.Color.Transparent;
                        panel2.BackColor = System.Drawing.Color.Red;
                        no = 0;
                    }
                }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out number))
                sp = number;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ca = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ca = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out number))
                db = number;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out number))
                precision = number;
            trackBar1.LargeChange = (int)number;
            if (float.TryParse(textBox3.Text, out number))
                trackBar1.Maximum = (int)(number * precision);
            if (float.TryParse(textBox4.Text, out number))
                trackBar1.Minimum = (int)(number * precision);
            trackBar1.TickFrequency = (int)precision;
        }
    }
}
