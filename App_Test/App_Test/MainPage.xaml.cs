using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
            // Stores whatever is in Enter number box incase enter is not pressed
            Number.Instance.Value = newText;
        }

        // User enters a number and presses enter.
        void OnEntryCompleted(object sender, EventArgs e)
        {
            string input = ((Entry)sender).Text;
            if ( ((Entry)sender).Placeholder == "Enter Number" )
            {
                try
                { 
                    Number.Instance.Value = input;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'\nMust enter an Integer with valid characters.");
                }
            }
        }

        // Reads in base from Drop-Down menu
        void OnSelectedBase(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            int index = picker.SelectedIndex;
            if (index != -1)
            {
                if (picker == From_Base)
                {
                    Number.Instance.Base_Number = index + 2;
                }
                else
                {
                    Number.Instance.New_Base_Number = index + 2;
                }
            }
        }

        // Preform conversion of number from original base to new base.
        void Convert(object sender, EventArgs e)
        {
            Answer.Text = Number.Instance.Convert_Number();       
        }
    }
}
