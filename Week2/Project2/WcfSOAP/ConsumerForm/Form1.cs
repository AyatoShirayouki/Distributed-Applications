using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoapService.Service1Client client = new SoapService.Service1Client();

            string result = client.GetData(textBox1.Text);

            label1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoapService.Service1Client client = new SoapService.Service1Client();
            int day, month, year, difference;

            day = int.Parse(textBox2.Text);
            month = int.Parse(textBox3.Text);
            year = int.Parse(textBox4.Text);

            difference = client.CalculateDays(day, month, year);

            label2.Text = $"The difference in days is: {difference}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoapService.Service1Client client = new SoapService.Service1Client();

            string name = textBox5.Text;

            string generatedUsername = client.GenerateUsername(name);

            label7.Text = $"Your generated Username is: {generatedUsername}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SoapService.Service1Client client = new SoapService.Service1Client();

            label9.Text = client.GetVignette(textBox6.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoapService.Service1Client client = new SoapService.Service1Client();

            label11.Text = client.GetWeatherData(textBox7.Text);
        }
    }
}
