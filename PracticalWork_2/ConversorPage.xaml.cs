using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace PracticalWork_2;

public partial class ConversorPage : ContentPage
{
    private bool isNewCalculation = true;
    private bool isNegative = false;

    public ConversorPage()
    {
        InitializeComponent();
    }

    // Event handlers for number buttons
    private void NumberButton_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string digit = button.Text;

        if (isNewCalculation)
        {
            ResultDisplay.Text = digit;
            isNewCalculation = false;
        }
        else
        {
            ResultDisplay.Text += digit;
        }
    }

    // Event handler for hex buttons (A-F)
    private void HexButton_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string hexDigit = button.Text;

        if (isNewCalculation)
        {
            ResultDisplay.Text = hexDigit;
            isNewCalculation = false;
        }
        else
        {
            ResultDisplay.Text += hexDigit;
        }
    }

    // Event handler for clear button
    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        ResultDisplay.Text = string.Empty;
        isNewCalculation = true;
        isNegative = false;
    }

    // Event handler for minus button
    private void MinusButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ResultDisplay.Text) || isNewCalculation)
        {
            ResultDisplay.Text = "-";
            isNegative = true;
            isNewCalculation = false;
        }
    }

    // Conversion event handlers
    private async void ButtonDecimalToBinary_Clicked(object sender, EventArgs e)
    {
        try
        {
            DecimalToBinary converter = new DecimalToBinary();
            if (converter.Validate(ResultDisplay.Text))
            {
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for decimal to binary conversion", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
        }
    }

    private async void ButtonDecimalToTwoComplement_Clicked(object sender, EventArgs e)
    {
        try
        {
            DecimalToTwoComplement converter = new DecimalToTwoComplement();
            if (converter.Validate(ResultDisplay.Text))
            {
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for decimal to two's complement conversion", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
        }
    }

    private async void ButtonDecimalToOctal_Clicked(object sender, EventArgs e)
    {
        try
        {
            DecimalToOctal converter = new DecimalToOctal();
            if (converter.Validate(ResultDisplay.Text))
            {
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for decimal to octal conversion", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
        }
    }

    private async void ButtonDecimalToHexadecimal_Clicked(object sender, EventArgs e)
    {
        try
        {
            DecimalToHexadecimal converter = new DecimalToHexadecimal();
            if (converter.Validate(ResultDisplay.Text))
            {
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for decimal to hexadecimal conversion", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
        }
    }

    private async void ButtonBinaryToDecimal_Clicked(object sender, EventArgs e)
    {
        try
        {
            BinaryToDecimal converter = new BinaryToDecimal();
            if (converter.Validate(ResultDisplay.Text))
            {
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for binary to decimal conversion", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
        }
    }

    private async void ButtonTwoComplementToDecimal_Clicked(object sender, EventArgs e)
    {
        try
        {
            TwoComplementToDecimal converter = new TwoComplementToDecimal();
            if (converter.Validate(ResultDisplay.Text))
            {
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for two's complement to decimal conversion", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
        }
    }

    private async void ButtonOctalToDecimal_Clicked(object sender, EventArgs e)
    {
        try
        {
            OctalToDecimal converter = new OctalToDecimal();
            if (converter.Validate(ResultDisplay.Text))
            {
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for octal to decimal conversion", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
        }
    }

    private async void ButtonHexadecimalToDecimal_Clicked(object sender, EventArgs e)
    {
        try
        {
            HexadecimalToDecimal converter = new HexadecimalToDecimal();
            if (converter.Validate(ResultDisplay.Text))
            {
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for hexadecimal to decimal conversion", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
        }
    }

    // Navigation event handlers
    private async void Operations_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Operations", "Navigate to operations page.", "OK");
        await Navigation.PushAsync(new UserInfoPage());
    }

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
        if (answer)
        {
            // Implement logout logic
            // For example: await Navigation.PopToRootAsync();
        }
    }

    private async void Exit_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Exit", "Are you sure you want to exit the application?", "Yes", "No");
        if (answer)
        {
            // Exit the application
            Application.Current.Quit();
        }
    }
    
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}