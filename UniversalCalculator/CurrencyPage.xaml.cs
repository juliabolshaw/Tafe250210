using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
	public sealed partial class CurrencyPage : Page
	{
		public CurrencyPage()
		{
			this.InitializeComponent();
		}

		private double ConversionRate(ComboBox from, ComboBox to)
		{
			if (from.SelectedIndex == 0 && to.SelectedIndex == 1) return 0.85189982;
			if (from.SelectedIndex == 0 && to.SelectedIndex == 2) return 0.72872436;
			if (from.SelectedIndex == 0 && to.SelectedIndex == 3) return 74.257327;

			if (from.SelectedIndex == 1 && to.SelectedIndex == 0) return 1.1739732;
			if (from.SelectedIndex == 1 && to.SelectedIndex == 2) return 0.8556672;
			if (from.SelectedIndex == 1 && to.SelectedIndex == 3) return 87.00755;

			if (from.SelectedIndex == 2 && to.SelectedIndex == 0) return 1.371907;
			if (from.SelectedIndex == 2 && to.SelectedIndex == 1) return 1.1686692;
			if (from.SelectedIndex == 2 && to.SelectedIndex == 3) return 101.68635;

			if (from.SelectedIndex == 3 && to.SelectedIndex == 0) return 0.011492628;
			if (from.SelectedIndex == 3 && to.SelectedIndex == 1) return 0.013492774;
			if (from.SelectedIndex == 3 && to.SelectedIndex == 2) return 0.0098339397;

			return 0;

		}
		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double amount;

			try
			{
				amount = Convert.ToDouble(amountTextBox.Text);
			}
			catch (Exception exception)
			{
				var dialogMessage = new MessageDialog("Invalid input for amount $. Enter a valid number");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			if (fromComboBox.SelectedItem == null || toComboBox.SelectedItem == null)
			{
				resultTextBlock.Text = "Please select both currencies.";
				return;
			}

			double conversionRate = ConversionRate(fromComboBox, toComboBox);

			var fromItem = fromComboBox.SelectedItem as ComboBoxItem;
			var toItem = toComboBox.SelectedItem as ComboBoxItem;

			if (fromItem == null || toItem == null)
			{
				var dialogMessage = new MessageDialog("Please select both currencies before converting.");
				return;
			}

			double convertedAmount = amount * conversionRate;

			// Top line
			amountFromTextBlock.Text = $"{amount} {fromItem.Content} =";

			// Result in bold (you can set TextBlock.FontWeight = Bold in XAML for resultTextBlock)
			resultTextBlock.Text = $"{convertedAmount:F2} {toItem.Content}";

			// Conversion rates
			convertionTextBlock.Text =
				$"1 {fromItem.Content} = {conversionRate} {toItem.Content}\n\n" +
				$"1 {toItem.Content} = {1 / conversionRate} {fromItem.Content}";
		}
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MenuPage));
		}
	}
}
