﻿using System;
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
        List<double> SeperatedNumberList = new List<double>();
        List<double> CompositeNumberList = new List<double>();
        string SeperatedNumberOutput, CompositeNumberOutput;


        public Page1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void primefinder(object sender, RoutedEventArgs e)
        {
            FindPrimeResult();
        }

        private void dataclear(object sender, RoutedEventArgs e)
        {
            SeperatedNumberList.Clear();
            CompositeNumberList.Clear();
            ตัวคูณร่วมทั้งหมดที่ระบุ.Text = "";
            ตัวประกอบที่ระบุไว้.Text = "";
            Result.Content = "";
            T_Number.Text = "";
        }
        ////////////////////////////////////AnswerFinder
        public void FindPrimeResult()
        {
            ClearInput();
            Number = double.Parse(T_Number.Text);
            if (Number % 1 == 0 && Number > 0)
            {
                FindPrimeAnswer();
                FindSeperateResult();
                FindCompositeResult();
                WriteResult();

            }
            else
                Result.Content = "Wrong input! Please try again.";
        }
        public void FindPrimeAnswer()
        {
            if (Number == 1)
                Prime = 2;
            else
                Prime = 1;
            PrimeDivider = 2;
            while (Math.Pow(Number, 0.5) >= PrimeDivider)
            {
                {
                    if ((Number % PrimeDivider) == 0)
                    {
                        Prime = 0;
                        break;
                    }
                    else
                        PrimeDivider++;
                }
            }
        }
        public void FindSeperateResult()
        {
            Testnumber = Number;
            if (Testnumber == 1)
                SeperatedNumberList.Add(1);
            SeperateDivider = 2;
            while (Testnumber >= 2)
            {
                if ((Testnumber % SeperateDivider) == 0)
                {
                    SeperatedNumberList.Add(SeperateDivider);
                    Testnumber = Testnumber / SeperateDivider;
                    SeperateDivider = 2;
                }
                else
                    SeperateDivider++;
            }
        }
        public void FindCompositeResult()
        {
            CompositeDivider = 1;
            while ((Number / CompositeDivider) >= 1)
            {
                if ((Number % CompositeDivider) == 0)
                {
                    CompositeNumberList.Add(CompositeDivider);
                }
                CompositeDivider++;
            }
        }
        public void WriteResult()
        {
            if (Prime == 0)
                Result.Content = "Composite Number";
            else if (Prime == 1)
                Result.Content = "Prime Number";
            else if (Prime == 2)
                Result.Content = "Can't be prime number and composite number";
            SeperatedNumberList.Sort();
            CompositeNumberList.Sort();
            SeperatedNumberOutput = String.Join(" x ", SeperatedNumberList);
            ตัวคูณร่วมทั้งหมดที่ระบุ.Text = SeperatedNumberOutput;
            CompositeNumberOutput = String.Join(", ", CompositeNumberList);
            ตัวประกอบที่ระบุไว้.Text = CompositeNumberOutput;
        }
        public void ClearInput()
        {
            SeperatedNumberList.Clear();
            CompositeNumberList.Clear();
            ตัวคูณร่วมทั้งหมดที่ระบุ.Text = "";
            ตัวประกอบที่ระบุไว้.Text = "";
            Result.Content = "";
        }
    }
}
