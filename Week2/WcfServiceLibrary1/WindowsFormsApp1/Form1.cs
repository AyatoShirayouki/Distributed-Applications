using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string returnString;

            returnString = client.GetData(textBox1.Text);
            label1.Text = returnString;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int day, Month, Year, TotalDays;

            //creating the object of WCF service client       
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            
            //assigning the input values to the variables       
            day = int.Parse(textBox2.Text);
            Month = int.Parse(textBox3.Text);
            Year = int.Parse(textBox4.Text);

            //assigning the output value from service Response       
            TotalDays = client.CalculateDays(day, Month, Year);
            string result = "You are Currently " + Convert.ToString(TotalDays) + " days old";
            label2.Text = result;

            //assigning the output value to the lable to show user       
            MessageBox.Show(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //creating the object of WCF service client       
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            string number = textBox5.Text;

            string result = client.GetVignette(number);

            label3.Text = result;
        }
    }
}
