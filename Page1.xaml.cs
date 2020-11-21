using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Primecanva
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        double Number, Testnumber, PrimeDivider, Prime, SeperateDivider, CompositeDivider;
        int seperatearray = 0;
        int compositearray = 0;
        double[] SeperatedNumber = new double[100];
        double[] CompositeNumber = new double[1000];


        public Page1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GoPage2(object sender, RoutedEventArgs e)
        {
            Page2 p2 = new Page2();
            this.NavigationService.Navigate(p2);
        }

        private void primefinder(object sender, RoutedEventArgs e)
        {
            FindPrimeResult();
        }

        private void dataclear(object sender, RoutedEventArgs e)
        {

        }
        ////////////////////////////////////AnswerFinder
        public void FindPrimeResult()
        {
            Number = double.Parse(T_Number.Text);
            Prime = 1;
            PrimeDivider = 2;
            while (Math.Pow(Number, 0.5) >= PrimeDivider)
            {
                if ((Number % PrimeDivider) == 0)
                {
                    Prime = 0;
                    break;
                }
                else
                    PrimeDivider++;
            }
            FindSeperateResult();
            FindCompositeResult();
        }
        public void FindSeperateResult()
        {
            Testnumber = Number;
            SeperateDivider = 2;
            while (Testnumber >= SeperateDivider)
            {
                if ((Testnumber % SeperateDivider) == 0)
                {
                    SeperatedNumber[seperatearray] = SeperateDivider;
                    seperatearray++;
                    Testnumber = Testnumber / SeperateDivider;
                    SeperateDivider = 2;
                }
                else
                    SeperateDivider++;
            }
            Array.Sort(SeperatedNumber);
            //Incomplete
        }
        public void FindCompositeResult()
        {
            CompositeDivider = 1;
            while ((Number / CompositeDivider) >= 1)
            {
                if ((Number % CompositeDivider) == 0)
                {
                    CompositeNumber[compositearray] = CompositeDivider;
                }
                compositearray++;
            }
            Array.Sort(CompositeNumber);
        }
    }
}
