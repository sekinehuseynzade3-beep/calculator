using System;
using System.Drawing;
using System.Windows.Forms;

namespace calculator.code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Müəllimin dizaynına uyğun arxa fon rəngi
            this.BackColor = Color.Teal;

            // ComboBox-a əmrləri əlavə edirik[cite: 1]
            comboBox1.Items.Clear();
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");

            // İlkin dəyərlər[cite: 1]
            textBox1.Text = "0";
            textBox2.Text = "0";
            label4.Text = "Answer:   0";
        }

        // Yanlışlıkla çift tıklamadan kaynaklanan hatayı çözen metod[cite: 8]
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Result düyməsi (button1)[cite: 1]
        private void button1_Click(object sender, EventArgs e)
        {
            // Daxil edilən dəyərlərin yoxlanılması
            if (!double.TryParse(textBox1.Text, out double number1) || !double.TryParse(textBox2.Text, out double number2))
            {
                MessageBox.Show("Zəhmət olmasa düzgün ədədlər daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double result = 0;
            string command = comboBox1.Text;

            // Hesablama əməliyyatları
            if (command == "+")
            {
                result = number1 + number2;
            }
            else if (command == "-")
            {
                result = number1 - number2;
            }
            else if (command == "*")
            {
                result = number1 * number2;
            }
            else if (command == "/")
            {
                if (number2 != 0)
                {
                    result = number1 / number2;
                }
                else
                {
                    MessageBox.Show("Sıfıra bölmək olmaz!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Zəhmət olmasa əməliyyat seçin (+, -, *, /)", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nəticənin ekrana çıxarılması[cite: 1]
            label4.Text = "Answer:   " + result.ToString();
        }

        // Clear düyməsi (button2)[cite: 1]
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            comboBox1.Text = "";
            label4.Text = "Answer:   0";
        }
    }
}