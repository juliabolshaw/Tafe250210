using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgagePage : Page
	{
		public MortgagePage()
		{
			this.InitializeComponent();
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MenuPage));
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
			
			double principal = double.Parse(principalBorrTextBox.Text);
			double yearlyInterest = double.Parse(annualIntTextBox.Text);
			int years = int.Parse(yearsTextBox.Text);
			int months = int.Parse(monthsTextBox.Text);

			double paymentMonths = years * 12 + months;

			double monthlyIntrestRate = yearlyInterest / 12.0 / 100;
			monthlyIntTextBox.Text = (monthlyIntrestRate * 100).ToString("0.0000");

			double numerator = principal * Math.Pow(1 + monthlyIntrestRate, paymentMonths) * monthlyIntrestRate;
			double denominator = Math.Pow(1 + monthlyIntrestRate, paymentMonths) - 1;
			double monthlyRepayment = numerator / denominator;

			monthlyRepayTextBox.Text = monthlyRepayment.ToString();

			}
			catch (Exception error)
			{
				new MessageDialog("Please ensure you enter the right numeric data for the fields." + "\n" + error.Message);
			}

		}

	}
}
