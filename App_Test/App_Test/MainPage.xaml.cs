using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace App_Test
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string input = ((Entry)sender).Text;
            if ( ((Entry)sender).Placeholder == "Enter Base Number" )
            {
                try
                { 
                    Number.Instance.Base_Number = Int32.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'\nMust enter an integer.");
                }
            }
            else if ( ((Entry)sender).Placeholder == "Enter Decimal Number" )
            {
                try 
                { 
                    Number.Instance.Value = double.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'\nMust enter a Number.");
                }
            }
            else if (((Entry)sender).Placeholder == "Enter 2nd Base Number")
            {
                try
                {
                    Number.Instance.New_Base_Number = Int32.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'\nMust enter an integer.");
                }
            }
        }

        void Convert(object sender, EventArgs e)
        {
            string res = Number.Instance.Convert_Number();
            Console.WriteLine(res);
            Answer.Text = res;
        }
    }
}
