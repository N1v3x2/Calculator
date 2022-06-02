using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string input = "0";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resultBox.Text = "0";
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {
            input = resultBox.Text;
        }

        private void button_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string func = btn.Text;
            DataTable dt = new DataTable();

            if (func.All(char.IsNumber) || func.Equals("."))
            {
                if (input.Equals("0"))
                    input = "";
                input += btn.Text;
                resultBox.Text = input;
            }
            else if (func.Equals("+") || func.Equals("-") || func.Equals("/") || func.Equals("*"))
            {
                input += " " + func + " ";
                resultBox.Text = input;
            }
            else if (func.Equals("="))
            {
                try
                {
                    input = "" + dt.Compute(input, "");
                    resultBox.Text = input;
                }
                catch (SyntaxErrorException error)
                {
                    input = "" + dt.Compute(input + input.Substring(0, input.Length - 3), "");
                    resultBox.Text = input;
                }
            }
            else if (func.Equals("C"))
            {
                input = "0";
                resultBox.Text = input;
            }
        }
    }
}