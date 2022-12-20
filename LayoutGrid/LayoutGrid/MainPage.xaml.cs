using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LayoutGrid
{
    public partial class MainPage : ContentPage
    {
        int CurrentStats = 1;
        string mathOperador;
        double firtNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
            OnClear(new object(), new EventArgs());
        }

        void OnClear(object sender, EventArgs e)
        {
            firtNumber = 0;
            secondNumber = 0;
            CurrentStats = 1;
            this.resultText.Text = "0";
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.resultText.Text == "0" || CurrentStats < 1)
            {
                this.resultText.Text = "";
                if (CurrentStats < 0)
                    CurrentStats *= -1;
            }

            this.resultText.Text += pressed;
            double number;
            if(double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if(CurrentStats ==1)
                {
                    firtNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }

        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            CurrentStats = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperador = pressed;
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if(CurrentStats == 2)
            {
                double result = 0;
                if(mathOperador == "+")
                {
                    result = firtNumber + secondNumber;
                }
                if (mathOperador == "-")
                {
                    result = firtNumber - secondNumber;
                }
                if (mathOperador == "X")
                {
                    result = firtNumber * secondNumber;
                }
                if (mathOperador == "/")
                {
                    result = firtNumber / secondNumber;
                }

                this.resultText.Text = result.ToString("N0");
                firtNumber = result;
                CurrentStats = -1;
            }
        }




        }
}
