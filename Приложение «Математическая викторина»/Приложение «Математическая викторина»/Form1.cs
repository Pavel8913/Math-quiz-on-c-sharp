
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Приложение__Математическая_викторина_
{
    public partial class Form1 : Form
    {
        string[] mass = new string[10];
        Random rand = new Random();
        Timer timer = new Timer();
        int timerCounter = 25;
        public Form1()
        {
            InitializeComponent();

            timer.Enabled = false;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int count = 0;
            this.label1.Text = "Время: " + (--timerCounter).ToString();
            timer_backlight();
            if (timerCounter == 0)
            {
                timer.Stop();
                try
                {
                    if (Convert.ToInt32(mass[0]) + Convert.ToInt32(mass[1]) == Convert.ToDouble(textBox1.Text))
                    {
                        textBox1.BackColor = Color.Green;
                        count++;
                    }
                    else
                    {
                        textBox1.BackColor = Color.Red;
                    }
                    if (Convert.ToInt32(mass[2]) - Convert.ToInt32(mass[3]) == Convert.ToDouble(textBox2.Text))
                    {
                        textBox2.BackColor = Color.Green;
                        count++;
                    }
                    else
                    {
                        textBox2.BackColor = Color.Red;
                    }
                    if (Convert.ToInt32(mass[4]) * Convert.ToInt32(mass[5]) == Convert.ToDouble(textBox3.Text))
                    {
                        textBox3.BackColor = Color.Green;
                        count++;
                    }
                    else
                    {
                        textBox3.BackColor = Color.Red;
                    }
                    if (Convert.ToInt32(mass[6]) % Convert.ToInt32(mass[7]) == Convert.ToDouble(textBox4.Text))
                    {
                        textBox4.BackColor = Color.Green;
                        count++;
                    }
                    else
                    {
                        textBox4.BackColor = Color.Red;
                    }
                    if (Convert.ToDouble(mass[8]) / Convert.ToDouble(mass[9]) == Convert.ToDouble(textBox5.Text))
                    {
                        textBox5.BackColor = Color.Green;
                        count++;
                    }
                    else
                    {
                        textBox5.BackColor = Color.Red;
                    }
                    if (count == 5)
                    {
                        MessageBox.Show("Вы победили.\nПоздравляю!", "Поздравляю!!");
                        listBox1.Items.Add("Победа");
                    }
                    else
                    {
                        MessageBox.Show("Вы проиграли.\n Попробуйте ещё раз!", "К сожалению!");
                        listBox1.Items.Add("Поражение");
                    }
                    reset();
                }
                catch
                {
                    MessageBox.Show("Ошибка ввода!", "Ошибка!");
                    reset();
                }

            }

        }
        private void timer_backlight()
        {
            if (timerCounter > 15 && timerCounter <= 25)
            {
                label1.BackColor = Color.SpringGreen;
                label1.ForeColor = Color.Black;
            }
            if (timerCounter > 5 && timerCounter <= 15)
            {
                label1.BackColor = Color.Gold;
                label1.ForeColor = Color.Black;
            }
            if (timerCounter <= 5)
            {
                label1.BackColor = Color.DarkRed;
                label1.ForeColor = Color.White;
            }

        }
        private void reset()
        {
            timerCounter = 25;
            button1.Enabled = true;
            comboBox1.Enabled = true;
            label3.Text = "...+...";
            label4.Text = "...-...";
            label5.Text = "...*...";
            label6.Text = "...%...";
            label8.Text = ".../...";

            textBox1.Text = "0";
            textBox1.BackColor = Color.Silver;
            textBox2.Text = "0";
            textBox2.BackColor = Color.Silver;
            textBox3.Text = "0";
            textBox3.BackColor = Color.Silver;
            textBox4.Text = "0";
            textBox4.BackColor = Color.Silver;
            textBox5.Text = "0";
            textBox5.BackColor = Color.Silver;

            label1.BackColor = Color.Silver;
            label1.ForeColor = Color.Black;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
            comboBox1.Enabled = false;

            switch (comboBox1.Items[comboBox1.SelectedIndex])
            {
                case "Легко":
                    for (int i = 0; i < 4; i++)
                    {
                        mass[i] = Convert.ToString(rand.Next(0, 100));
                    }
                    for (int i = 4; i < 6; i++)
                    {
                        mass[i] = Convert.ToString(rand.Next(0, 20));
                    }
                    mass[6] = Convert.ToString(rand.Next(20, 25));
                    mass[7] = Convert.ToString(rand.Next(1, 20));
                    mass[8] = Convert.ToString(rand.Next(20, 25));
                    mass[9] = Convert.ToString(rand.Next(1, 20));
                    break;
                case "Средне":
                    for (int i = 0; i < 4; i++)
                    {
                        mass[i] = Convert.ToString(rand.Next(0, 600));
                    }
                    for (int i = 4; i < 6; i++)
                    {
                        mass[i] = Convert.ToString(rand.Next(0, 60));
                    }
                    mass[6] = Convert.ToString(rand.Next(20, 80));
                    mass[7] = Convert.ToString(rand.Next(1, 40));
                    mass[8] = Convert.ToString(rand.Next(20, 45));
                    mass[9] = Convert.ToString(rand.Next(1, 35));
                    break;
                case "Тяжело":
                    for (int i = 0; i < 4; i++)
                    {
                        mass[i] = Convert.ToString(rand.Next(0, 1000));
                    }
                    for (int i = 4; i < 6; i++)
                    {
                        mass[i] = Convert.ToString(rand.Next(0, 60));
                    }
                    mass[6] = Convert.ToString(rand.Next(20, 55));
                    mass[7] = Convert.ToString(rand.Next(1, 35));
                    mass[8] = Convert.ToString(rand.Next(20, 50));
                    mass[9] = Convert.ToString(rand.Next(1, 60));
                    break;



            }


            label3.Text = mass[0] + " + " + mass[1] + " = ";
            label4.Text = mass[2] + " - " + mass[3] + " = ";
            label5.Text = mass[4] + " * " + mass[5] + " = ";
            label6.Text = mass[6] + " % " + mass[7] + " = ";
            label8.Text = mass[8] + " / " + mass[9] + " = ";

            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BackColor= Color.Black;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            BackColor= Color.Silver;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            BackColor= Color.White;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            textBox3.ForeColor = Color.Black;
            textBox4.ForeColor = Color.Black;
            comboBox1.ForeColor = Color.Black;
            listBox1.ForeColor= Color.Black;
            groupBox1.ForeColor = Color.Black;
           radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            radioButton3.ForeColor = Color.Black;
            radioButton4.ForeColor = Color.Black;
            radioButton5.ForeColor = Color.Black;
            radioButton6.ForeColor = Color.Black;
            groupBox2.ForeColor = Color.Black;

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Silver;
            label2.ForeColor = Color.Silver;
            label3.ForeColor = Color.Silver;
            label4.ForeColor = Color.Silver;
            label5.ForeColor = Color.Silver;
            label6.ForeColor = Color.Silver;
            label7.ForeColor = Color.Silver;
            textBox1.ForeColor = Color.Silver;
            textBox2.ForeColor = Color.Silver;
            textBox3.ForeColor = Color.Silver;
            textBox4.ForeColor = Color.Silver;
            comboBox1.ForeColor = Color.Silver;
            listBox1.ForeColor= Color.Silver;
            groupBox1.ForeColor = Color.Silver;
            radioButton1.ForeColor = Color.Silver;
            radioButton2.ForeColor = Color.Silver;
            radioButton3.ForeColor = Color.Silver;
            radioButton4.ForeColor = Color.Silver;
            radioButton5.ForeColor = Color.Silver;
            radioButton6.ForeColor = Color.Silver;
            groupBox2.ForeColor= Color.Silver;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            textBox1.ForeColor = Color.White;
            textBox2.ForeColor = Color.White;
            textBox3.ForeColor = Color.White;
            textBox4.ForeColor = Color.White;
            comboBox1.ForeColor = Color.White;
            listBox1.ForeColor = Color.White;
            groupBox1.ForeColor = Color.White;
            radioButton1.ForeColor = Color.White;
            radioButton2.ForeColor = Color.White;
            radioButton3.ForeColor = Color.White;
            radioButton4.ForeColor = Color.White;
            radioButton5.ForeColor = Color.White;
            radioButton6.ForeColor = Color.White;
            radioButton4.ForeColor = Color.White;
            groupBox2.ForeColor= Color.White;
        }
    }
}
