using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GraphPlotter
{
    public partial class Form1 : Form
    {
        private double a, b, c;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Встановлення меж графіку
            chart1.ChartAreas[0].AxisX.Minimum = -5;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisY.Minimum = -5;
            chart1.ChartAreas[0].AxisY.Maximum = 5;
            // Назви вісей
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримання значень коефіцієнтів з поля введення
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);
                c = double.Parse(textBox3.Text);
                // Очищення графіку
                chart1.Series[0].Points.Clear();
                // Побудова графіку
                for (double t = -5; t <= 5; t += 0.1)
                {
                    double x = a * Math.Cos(t) * (Math.Cos(t) + b);
                    double y = Math.Sin(t) * (Math.Sin(t) + c);
                    chart1.Series[0].Points.AddXY(x, y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
