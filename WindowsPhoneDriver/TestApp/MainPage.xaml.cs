using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WindowsPhoneDriver.InnerDriver.Public;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TestApp.Resources;

namespace TestApp
{
    using System.Windows.Automation;

    public partial class MainPage : PhoneApplicationPage
    {
        private readonly List<string> _monthsList = new List<string>
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December",
            "Moses",
            "Homer",
            "Aristotle",
            "Archimedes",
            "Caesar",
            "Saint Paul",
            "Charlemagnev",
            "Dante",
            "Gutenberg",
            "Shakespeare",
            "Descartes",
            "Frederick",
            "Bichat"
        };

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            foreach (var month in _monthsList)
            {
                var textBlock = new TextBlock { Text = month };
                textBlock.SetValue(AutomationProperties.NameProperty, month);

                // ReSharper disable once PossibleNullReferenceException
                this.ListBox.Items.Add(textBlock);
            }
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "CARAMBA";
        }

        private void ClickableApplicationBarIconButton_OnClick(object sender, EventArgs e)
        {
            var clickableApplicationBarIconButton = sender as ClickableApplicationBarIconButton;
            if (clickableApplicationBarIconButton != null)
            {
                TextBox.Text = clickableApplicationBarIconButton.Text;
            }
        }

        private void ClickableApplicationBarMenuItem_OnClick(object sender, EventArgs e)
        {
            var clickableApplicationBarMenuItem = sender as ClickableApplicationBarMenuItem;
            if (clickableApplicationBarMenuItem != null)
            {
                TextBox.Text = clickableApplicationBarMenuItem.Text;
            }
        }
    }
}