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
        if (ResultDisplay.Text != "" || ResultDisplay.Text != null)
        {
            ResultDisplay.Text = "";
            try
            {
                DecimalToBinary converter = new DecimalToBinary("Binary", "Decimal to Binary");
                converter.Validate(ResultDisplay.Text);

                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;


            }
            catch (FormatException ex)
            {
                await DisplayAlert("Error", "Invalid input for decimal to binary conversion", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
            }
        }
        else 
        {
            ResultDisplay.Text = "Please, fill the entry, it is empty.";
        }
        
    }

    private async void ButtonDecimalToTwosComplement_Clicked(object sender, EventArgs e)
    {
        if (ResultDisplay.Text != "" || ResultDisplay.Text != null)
        {
            ResultDisplay.Text = "";
            try
            {
                DecimalToTwosComplement converter = new DecimalToTwosComplement("Decimal", "Decimal to Binary (Two Complement)");
                converter.Validate(ResultDisplay.Text);
                
                string result = converter.Change(ResultDisplay.Text);
                ResultDisplay.Text = result;
                isNewCalculation = true;
                
            
            }
            catch (FormatException ex)
            {
                await DisplayAlert("Error", "Invalid input for decimal to two's complement conversion", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
            }
        }
        else 
        {
            ResultDisplay.Text = "Please, fill the entry, it is empty.";
        }
        
    }

    private async void ButtonDecimalToOctal_Clicked(object sender, EventArgs e)
    {
        if (ResultDisplay.Text != "" || ResultDisplay.Text != null)
        {
            ResultDisplay.Text = "";
            try
            {
            DecimalToOctal converter = new DecimalToOctal("Octal", "Decimal to Octal");
                converter.Validate(ResultDisplay.Text);
            
            string result = converter.Change(ResultDisplay.Text);
            ResultDisplay.Text = result;
            isNewCalculation = true;
            
            
            }
            catch (FormatException ex)
            {
                await DisplayAlert("Error", "Invalid input for decimal to octal conversion", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
            }
        }
        else
        {
            ResultDisplay.Text = "Please, fill the entry, it is empty.";
        }
        
    }

    private async void ButtonDecimalToHexadecimal_Clicked(object sender, EventArgs e)
    {
        if (ResultDisplay.Text != "" || ResultDisplay.Text != null)
        {
            ResultDisplay.Text = "";

            try
            {
            DecimalToHexadecimal converter = new DecimalToHexadecimal("Hexadecimal", "Decimal to Hexadecimal");
            converter.Validate(ResultDisplay.Text);
            
            string result = converter.Change(ResultDisplay.Text);
            ResultDisplay.Text = result;
            isNewCalculation = true;
            
            
            }
            catch (FormatException ex)
            {
                await DisplayAlert("Error", "Invalid input for decimal to hexadecimal conversion", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
            }
        }
        else
        {
            ResultDisplay.Text = "Please, fill the entry, it is empty.";
        }
        
    }

    private async void ButtonBinaryToDecimal_Clicked(object sender, EventArgs e)
    {
        if (ResultDisplay.Text != "" || ResultDisplay.Text!= null)
        {
            ResultDisplay.Text = "";
            try
            {
            BinaryToDecimal converter = new BinaryToDecimal("Decimal", "Binary to Decimal");
            converter.Validate(ResultDisplay.Text);
            
            string result = converter.Change(ResultDisplay.Text);
            ResultDisplay.Text = result;
            isNewCalculation = true;
            
            
            }
            catch (FormatException ex)
            {
                await DisplayAlert("Error", "Invalid input for binary to decimal conversion", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
            }
        }
        else
        {
            ResultDisplay.Text = "Please, fill the entry, it is empty.";
        }
        
    }

    private async void ButtonTwosComplementToDecimal_Clicked(object sender, EventArgs e)
    {
        if (ResultDisplay.Text != "" || ResultDisplay.Text != null)
        {
            ResultDisplay.Text = "";
            try
            {
            TwosComplementToDecimal converter = new TwosComplementToDecimal("Decimal", "Binary (Two Complement) to Decimal");
            converter.Validate(ResultDisplay.Text);
        
            string result = converter.Change(ResultDisplay.Text);
            ResultDisplay.Text = result;
            isNewCalculation = true;
            
            
            }
            catch (FormatException ex)
            {
                await DisplayAlert("Error", "Invalid input for two's complement to decimal conversion", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
            }
        }
        else
        {
            ResultDisplay.Text = "Please, fill the entry, it is empty.";
        }
        
    }

    private async void ButtonOctalToDecimal_Clicked(object sender, EventArgs e)
    {
        if (ResultDisplay.Text != "" || ResultDisplay.Text != null)
        {
            ResultDisplay.Text = "";
            try
            {
            OctalToDecimal converter = new OctalToDecimal("Decimal", "Octal to Decimal");
            converter.Validate(ResultDisplay.Text);
        
            string result = converter.Change(ResultDisplay.Text);
            ResultDisplay.Text = result;
            isNewCalculation = true;
            
            
            }
            catch (FormatException ex)
            {
                await DisplayAlert("Error", "Invalid input for octal to decimal conversion", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
            }
        }
        else
        {
            ResultDisplay.Text = "Please, fill the entry, it is empty.";
        }
        
    }

    private async void ButtonHexadecimalToDecimal_Clicked(object sender, EventArgs e)
    {
        if (ResultDisplay.Text != "" || ResultDisplay.Text != null)
        {
            ResultDisplay.Text = "";
            try
            {
            HexadecimalToDecimal converter = new HexadecimalToDecimal("Decimal", "Hexadecimal to Decimal");
            converter.Validate(ResultDisplay.Text);
        
            string result = converter.Change(ResultDisplay.Text);
            ResultDisplay.Text = result;
            isNewCalculation = true;
            
            
            }
            catch (FormatException ex)
            {
                await DisplayAlert("Error", "Invalid input for hexadecimal to decimal conversion", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Conversion error: {ex.Message}", "OK");
            }
        }
        else
        {
            ResultDisplay.Text = "Please, fill the entry, it is empty.";
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