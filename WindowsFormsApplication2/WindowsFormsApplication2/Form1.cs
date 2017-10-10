using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        bool numberpressed = false;
        bool digitalpressed = false;
        char correctedsign, operation;
        decimal firstnumber, secondnumber;

        public Form1()
        {
            InitializeComponent();
        }

        private void Action (object sender, EventArgs e) // Пользовательская функция для корректного вывода чисел на экран
        {
            string number = ((System.Windows.Forms.Button)sender).Text;

            if (numberpressed) // Если уже было введено какое-либо число и опять было нажато значение какого-либо числа, то скливаем их в одно значение
                {
                SecondTB.Text = SecondTB.Text + number;
                }
            else
                {
                SecondTB.Text = number;
                numberpressed = true; // Булевская переменная, показывающая, что было введено число
                digitalpressed = false;
                }
       }

   

        private void Digital(object sender, EventArgs e) // Пользовательская функция для фиксирования первого числа в действии и вывода знака
        {
           
            char correctedsign = char.Parse(((System.Windows.Forms.Button)sender).Text);
            TBDisplay.Text = (TBDisplay.Text == "0" ? "": TBDisplay.Text) + SecondTB.Text + correctedsign; // Оператор условия, необходимый для того, чтобы убрать 0 перед первым числом (заменяем его на пустоту)
            
            numberpressed = false; // Булевская переменная, необходимая, чтобы после знака выводилось число, а не склеивалось с предыдущим значением
            digitalpressed = true;
            switch (operation)
            {
                case '+':
                    firstnumber += decimal.Parse(SecondTB.Text);
                    break;

                case '-':
                    firstnumber -= decimal.Parse(SecondTB.Text);
                    break;

                case '/':
                    firstnumber /= decimal.Parse(SecondTB.Text);
                    break;

                case '*':
                    firstnumber *= decimal.Parse(SecondTB.Text);
                    break;
                default:
                    firstnumber = decimal.Parse(SecondTB.Text);
                    break;
            }
            
            operation = correctedsign;
        }

     
        private void button_equally_Click(object sender, EventArgs e)
        {
            
            
            switch (operation)
            {
                case '+':
                    if (numberpressed)
                    secondnumber = decimal.Parse(SecondTB.Text);
                    TBDisplay.Text = TBDisplay.Text + secondnumber.ToString();
                    SecondTB.Text = (firstnumber + secondnumber).ToString();
                    firstnumber = decimal.Parse(SecondTB.Text);
                    numberpressed = false;
                    break;

                case '-':
                    secondnumber = decimal.Parse(SecondTB.Text);
                    TBDisplay.Text = TBDisplay.Text + secondnumber.ToString();
                    SecondTB.Text = (firstnumber - secondnumber).ToString();
                    firstnumber = decimal.Parse(SecondTB.Text);
                    numberpressed = false;
                    break;

                case '/':
                    secondnumber = decimal.Parse(SecondTB.Text);
                    TBDisplay.Text = TBDisplay.Text + secondnumber.ToString();
                    SecondTB.Text = (firstnumber / secondnumber).ToString();
                    firstnumber = decimal.Parse(SecondTB.Text);
                    numberpressed = false;
                    break;

                case '*':
                    secondnumber = decimal.Parse(SecondTB.Text);
                    TBDisplay.Text = TBDisplay.Text + secondnumber.ToString();
                    SecondTB.Text = (firstnumber * secondnumber).ToString();
                    firstnumber = decimal.Parse(SecondTB.Text);
                    numberpressed = false;
                    break;

            }
            

        }

        private void button_C_Click(object sender, EventArgs e)
        {


            TBDisplay.Text = "0";
            SecondTB.Text = "0";
            firstnumber = 0;
            secondnumber = 0;
            numberpressed = false;
            operation = new char();
        }

         
            



        }
    }
