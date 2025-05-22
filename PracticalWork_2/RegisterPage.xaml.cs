using Microsoft.Maui.Controls;
using System;
using System.Text.RegularExpressions;
namespace PracticalWork_2;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }
    private async void ExitButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Exit", "Are you sure you want to exit the application?", "Yes", "No");
        if (answer)
        {
            // Exit the application
            Application.Current.Quit();
        }
    }

    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text) ||   //caambiar esto por comillas vacias 
            string.IsNullOrWhiteSpace(EmailEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(ConfirmPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }
        if (!IsValidEmail(EmailEntry.Text))
        {
            await DisplayAlert("Error", "Please enter a valid email address", "OK");
            return;
        }
        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }
        if (!PolicyCheckBox.IsChecked)
        {
            await DisplayAlert("Error", "You must agree to the Protection Policy", "OK");
            return;
        }

        //lógica de registro ....(cambiar cuando haga el txt)
        await DisplayAlert("Success", "Account created successfully!", "OK");

        await Navigation.PopAsync();
    }

  

    private async void PolicyTerms_Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Protection Policy",
            "Please Moisés, accept the policy terms. (will I pass your subject?...)",
            "OK");
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var emailRegexpr = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$"); //I use regular expressions to control whether the email is in a correct format oor not
            return emailRegexpr.IsMatch(email);
        }
        catch
        {
            return false;
        }
    }
    
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
