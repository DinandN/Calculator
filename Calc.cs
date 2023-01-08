using System;
using System.Windows;
namespace Calc
{
    public partial class MainWindow : Window
    {
        //vars used
        private bool booFirstNumber = true, booBack = true;
        private string strFirst = string.Empty, strSecond = string.Empty;
        private double doubleFirst = 0, doubleSecond = 0, doubleOperator = 0;
        public void Clear()
        {
            //reset all things to default
            strFirst = string.Empty;
            strSecond = string.Empty;
            textBlock.Text = string.Empty;
            doubleOperator = 0;
            doubleFirst = 0;
            doubleSecond = 0;
            doubleOperator = 0;
            booFirstNumber = true;
            booBack = true;
        }
        public void Operator(string strOperator)
        {
            //checks if number 1 is typed and number 2 is empty
            if (!string.IsNullOrEmpty(strFirst) && string.IsNullOrEmpty(strSecond))
            {
                //removes the last operator if one is chosen
                if(doubleOperator == 0) { textBlock.Text += strOperator; }
                else
                {
                    textBlock.Text = textBlock.Text.Remove(textBlock.Text.Length - 1, 1);
                    textBlock.Text += strOperator;
                }
                //checks which operator is used
                switch (strOperator)
                {
                    case "+": doubleOperator = 1; break;
                    case "x": doubleOperator = 2; break;
                    case "-": doubleOperator = 3; break;
                    case "/": doubleOperator = 4; break;
                    case "^": doubleOperator = 5; break;
                }
                booFirstNumber = false;
                booBack = false;
            }
        }
        public void FirstOrLast(string m)
        {
            //adds the number to the textBlock 
            textBlock.Text += m;
            //returns the backspace feature
            booBack = true;
            //checks if number 1 or number 2 is being typed
            if (booFirstNumber) { strFirst += m; }
            else { strSecond += m; }
        }
        //buttons for 0 through 9 and comma
        private void btn0(object sender, RoutedEventArgs e) { FirstOrLast("0"); }
        private void btn1(object sender, RoutedEventArgs e) { FirstOrLast("1"); }
        private void btn2(object sender, RoutedEventArgs e) { FirstOrLast("2"); }
        private void btn3(object sender, RoutedEventArgs e) { FirstOrLast("3"); }
        private void btn4(object sender, RoutedEventArgs e) { FirstOrLast("4"); }
        private void btn5(object sender, RoutedEventArgs e) { FirstOrLast("5"); }
        private void btn6(object sender, RoutedEventArgs e) { FirstOrLast("6"); }
        private void btn7(object sender, RoutedEventArgs e) { FirstOrLast("7"); }
        private void btn8(object sender, RoutedEventArgs e) { FirstOrLast("8"); }
        private void btn9(object sender, RoutedEventArgs e) { FirstOrLast("9"); }
        private void btnComma(object sender, RoutedEventArgs e)
        {
            //checks if there is an " , " in de first number if not it can be used & it cant be used if there is no number given
            if (booFirstNumber) { 
                if(!string.IsNullOrEmpty(strFirst) && strFirst.Contains(',') == false) { FirstOrLast(","); } }
            else
            {
                if (!string.IsNullOrEmpty(strSecond) && !strSecond.Contains(',')) { FirstOrLast(","); } }
        }
        //buttons for the operators
        private void btnPlus(object sender, RoutedEventArgs e) { Operator("+");}
        private void btnTimes(object sender, RoutedEventArgs e) { Operator("x"); }
        private void btnMinus(object sender, RoutedEventArgs e) { Operator("-"); }
        private void btnDivide(object sender, RoutedEventArgs e) { Operator("/"); }
        private void btnPower(object sender, RoutedEventArgs e) { Operator("^");}
        //clearing buttons
        private void btnClear(object sender, RoutedEventArgs e) { Clear(); }
        private void btnBack(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(strFirst)) { booBack = false; }
            //check if u can press back first
            if (booFirstNumber == false) { if (string.IsNullOrEmpty(strSecond)) {booBack = false; } }
            //checking which str to back
            if (booBack){
                textBlock.Text = textBlock.Text.Substring(0, textBlock.Text.Length - 1);
                if (booFirstNumber) { strFirst = strFirst.Remove(strFirst.Length - 1, 1); }
                else { strSecond = strSecond.Remove(strSecond.Length - 1, 1); }
            }
        }
        private void btnIs(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(strFirst) && !string.IsNullOrEmpty(strSecond))
            {
                //converting string to double
                doubleFirst = double.Parse(strFirst);
                    doubleSecond = double.Parse(strSecond);
                    switch (doubleOperator)
                    {
                        //looking which operator to use
                        case 1: doubleFirst = doubleFirst + doubleSecond; break;
                        case 2: doubleFirst = doubleFirst * doubleSecond; break;
                        case 3: doubleFirst = doubleFirst - doubleSecond; break;
                        case 4: doubleFirst = doubleFirst / doubleSecond; break;
                        case 5: doubleFirst = Math.Pow(doubleFirst, doubleSecond); break;
                    }
                    strFirst = doubleFirst.ToString();
                    strSecond = string.Empty;
                    textBlock.Text = strFirst;
                    booFirstNumber = true;
                    booBack = true;
                    doubleOperator = 0;
            }
        }
    }
}