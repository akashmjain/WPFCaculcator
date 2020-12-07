using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{ 
    public partial class MainWindow : Window
    {
        
        private string dataDisplay = "";
        private string buffer = "";
        private string operation = "";
        public MainWindow()
        {
            InitializeComponent();            
        }
        private void Button_ClearScreen_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Buffer.Text = buffer = dataDisplay = operation = "";
        }
        private void Button_Numerical_Click(object sender, RoutedEventArgs e)
        {
            buffer += ((Button)sender).Content.ToString();
            Buffer.Text = buffer;
        }
        private void Button_Operater_Click(object sender, RoutedEventArgs e)
        {
            if (buffer == "") return;
            if (operation != null)
            {
                dataDisplay = dataDisplay == "" ? buffer : PerformOperation(dataDisplay, buffer, operation);
                operation = ((Button)sender).Content.ToString();
            }
            else
            {
                dataDisplay = buffer;
                operation = ((Button)sender).Content.ToString();
            }

            Buffer.Text = buffer = "";
            
            Display.Text = dataDisplay;
        }
        private void Button_Equals_Click(object sender, RoutedEventArgs e)
        {
            if (buffer == "") return;
            else if(dataDisplay == "")
            {
                Display.Text = buffer;
                operation = "";
            } 
            else
            {
                dataDisplay = PerformOperation(dataDisplay, buffer, operation);
                Display.Text = dataDisplay;
            }
        }
        // decrease a buffer by one digit
        private void Button_BackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (buffer == "") return;
            buffer = buffer.Substring(0, buffer.Length - 1);
            Buffer.Text = buffer;
        }

        private void Button_DoubleZero_Click(object sender, RoutedEventArgs e)
        {

        }
        private string PerformOperation(string firstString, string secondString, string operation)
        {
            double fno = firstString == "" ? 0 : double.Parse(firstString);
            double sno = secondString == "" ? 0 :double.Parse(secondString);

            switch (operation)
            {
                case "+":
                    return (fno + sno).ToString();
                    break;
                case "-":
                    return (fno - sno).ToString();
                    break;
                case "X":
                    return (fno * sno).ToString(); 
                    break;
                case "/":
                    return (fno / sno).ToString();
                    break;
                case "%":
                    return (fno % sno).ToString();
                    break;
                default:
                    Console.WriteLine($"Something went wrong operation performed is {operation}");
                    return "";
                    break;
            }
        }

    }
}
