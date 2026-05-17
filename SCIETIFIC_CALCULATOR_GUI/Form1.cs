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

namespace SCIETIFIC_CALCULATOR_GUI
{
    public partial class Form1 : Form
    {
        string currentInput = "";
        double storedNumber = 0;
        string currentOperation = "";
        bool newEntry = true;

        public Form1()
        {
            InitializeComponent();
        }


        void UpdateDisplay(string value)
        {
            richTextBox1.Text = value; 
        }

        // --- Number buttons ---
        private void button16_Click(object sender, EventArgs e) { NumberPress("7"); }
        private void button20_Click(object sender, EventArgs e) { NumberPress("8"); }
        private void button19_Click(object sender, EventArgs e) { NumberPress("9"); }
        private void button21_Click(object sender, EventArgs e) { NumberPress("4"); }
        private void button25_Click(object sender, EventArgs e) { NumberPress("5"); }
        private void button24_Click(object sender, EventArgs e) { NumberPress("6"); }
        private void button26_Click(object sender, EventArgs e) { NumberPress("1"); }
        private void button30_Click(object sender, EventArgs e) { NumberPress("2"); }
        private void button29_Click(object sender, EventArgs e) { NumberPress("3"); }
        private void button31_Click(object sender, EventArgs e) { NumberPress("0"); }
        private void button32_Click(object sender, EventArgs e) { NumberPress("."); }

        void NumberPress(string num)
        {
            if (num == "." && currentInput.Contains(".")) return;
            if (newEntry) { currentInput = ""; newEntry = false; }
            currentInput += num;
            UpdateDisplay(currentInput);
        }

        // --- Constants ---
        private void button28_Click(object sender, EventArgs e)
        {
            currentInput = Math.PI.ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            currentInput = Math.E.ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        // --- AC ---
        private void button11_Click(object sender, EventArgs e)
        {
            currentInput = "";
            storedNumber = 0;
            currentOperation = "";
            newEntry = true;
            UpdateDisplay("0");
        }

        // --- Backspace ---
        private void button13_Click(object sender, EventArgs e)
        {
            if (currentInput.Length > 0)
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplay(currentInput == "" ? "0" : currentInput);
        }

        // --- +/- ---
        private void button15_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            currentInput = (-current).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        // --- Operator buttons ---
        private void button23_Click(object sender, EventArgs e) { OperatorPress("÷"); }
        private void button14_Click(object sender, EventArgs e) { OperatorPress("×"); }
        private void button17_Click(object sender, EventArgs e) { OperatorPress("−"); }
        private void button18_Click(object sender, EventArgs e) { OperatorPress("+"); }
        private void button22_Click(object sender, EventArgs e) { OperatorPress("^"); }
        private void button12_Click(object sender, EventArgs e) { OperatorPress("%"); }

        void OperatorPress(string op)
        {
            storedNumber = GetCurrent();
            currentOperation = op;
            newEntry = true;
        }

        // --- Equals ---
        private void button33_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            double result = 0;

            switch (currentOperation)
            {
                case "+": result = storedNumber + current; break;
                case "−": result = storedNumber - current; break;
                case "×": result = storedNumber * current; break;
                case "÷":
                    if (current == 0) { UpdateDisplay("Error"); return; }
                    result = storedNumber / current; break;
                case "^": result = Math.Pow(storedNumber, current); break;
                case "%": result = storedNumber % current; break;
                default: result = current; break;
            }

            currentInput = Math.Round(result, 8).ToString();
            UpdateDisplay(currentInput);
            currentOperation = "";
            newEntry = true;
        }

        // --- Scientific buttons ---
        private void button1_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            currentInput = Math.Round(Math.Sin(current * Math.PI / 180), 8).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            currentInput = Math.Round(Math.Cos(current * Math.PI / 180), 8).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            currentInput = Math.Round(Math.Tan(current * Math.PI / 180), 8).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            if (current < 0) { UpdateDisplay("Error"); return; }
            currentInput = Math.Round(Math.Sqrt(current), 8).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            currentInput = Math.Round(Math.Pow(current, 2), 8).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            if (current <= 0) { UpdateDisplay("Error"); return; }
            currentInput = Math.Round(Math.Log10(current), 8).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            if (current <= 0) { UpdateDisplay("Error"); return; }
            currentInput = Math.Round(Math.Log(current), 8).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            if (current < 0 || current > 20) { UpdateDisplay("Error"); return; }
            currentInput = Factorial((int)current).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            if (current == 0) { UpdateDisplay("Error"); return; }
            currentInput = Math.Round(1.0 / current, 8).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double current = GetCurrent();
            currentInput = Math.Abs(current).ToString();
            UpdateDisplay(currentInput);
            newEntry = false;
        }

       
        double GetCurrent()
        {
            double val = 0;
            if (!string.IsNullOrEmpty(currentInput))
                double.TryParse(currentInput, out val);
            else if (!newEntry)
                val = storedNumber;
            return val;
        }

       
        long Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
    }
}