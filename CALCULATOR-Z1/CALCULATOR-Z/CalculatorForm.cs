using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALCULATOR_Z
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }
        private decimal firstNum  = 0.0m;
        private decimal SecondNum = 0.0m;
        private decimal result    = 0.0m;
        private int operatorType  = (int)MathOpeartion.NoOperator;

        public enum MathOpeartion
        {
            NoOperator=0,
            Add=1,
            Subtract=2,
            Divide = 3,
            Multiply=4,
            percentange=5

        }
        

        private void DigitBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(DisplaytextBox1.Text=="0")
            {
                DisplaytextBox1.Clear();
            }
            DisplaytextBox1.Text += btn.Text;
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            if( !DisplaytextBox1.Text.Contains('.') )
            {
                DisplaytextBox1.Text += ".";

            }
           

        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            if(!DisplaytextBox1.Text.Contains('-'))
            {
                DisplaytextBox1.Text = "-"+DisplaytextBox1.Text;
            }
            else
            {
                DisplaytextBox1.Text=DisplaytextBox1.Text.Trim('-');
            }
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            saveValueAndOperationType((int)MathOpeartion.Add);


        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            saveValueAndOperationType((int)MathOpeartion.Subtract);

        }


        private void saveValueAndOperationType(int operation)
        {
            operatorType = operation;
            firstNum = Convert.ToDecimal(DisplaytextBox1.Text);
            DisplaytextBox1.Text = "0";

        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            saveValueAndOperationType((int)MathOpeartion.Divide);
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            saveValueAndOperationType((int)MathOpeartion.Multiply);
        }

        private void PercentageButton_Click(object sender, EventArgs e)
        {
            saveValueAndOperationType((int)MathOpeartion.percentange);
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            SecondNum = Convert.ToDecimal(DisplaytextBox1.Text);

            switch (operatorType)
            {
                case (int)MathOpeartion.Add:
                 
                    result = firstNum + SecondNum;
                    break;
                case (int)MathOpeartion.Subtract:
                   
                    result = firstNum - SecondNum;
                    break;
                case (int)MathOpeartion.Multiply:
                 
                    result = firstNum * SecondNum;
                    break;
                case (int)MathOpeartion.Divide:
                 
                    result = firstNum / SecondNum;
                    break;
                case (int)MathOpeartion.percentange:
                  
                    result = (firstNum/SecondNum)*100;
                    break;
            }
            DisplaytextBox1.Text=result.ToString(); 
        }

        private void ClearEntryButton_Click(object sender, EventArgs e)
        {
            DisplaytextBox1.Text = "0";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplaytextBox1.Text = "0";
            firstNum = 0.0m;
            SecondNum = 0.0m;
            result = 0.0m;
            operatorType = (int)MathOpeartion.NoOperator;
        }
    }
}
