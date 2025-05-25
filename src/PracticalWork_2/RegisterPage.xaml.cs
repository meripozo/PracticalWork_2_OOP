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
    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        //here I do some verifications, such as a null entry or wrong entry formats
        if (UsernameEntry.Text == null || UsernameEntry.Text == "" ||
               EmailEntry.Text == null || EmailEntry.Text == "" ||
                NameEntry.Text == null || NameEntry.Text == "" ||
                PasswordEntry.Text == null || PasswordEntry.Text == "" ||
                ConfirmPasswordEntry.Text == null || ConfirmPasswordEntry.Text == "")
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
        string filePath = "src/PracticalWork_2/UserInfoSaved.txt";
        if (File.Exists(filePath))
        {
            bool userfound = false;
            foreach (string line in File.ReadAllLines(filePath))
            {
                //I make the split to read the values of the txt
                string[] userValues = line.Split(";");

                //first I check if the user has already been registrated: i check it with the user email address and usernme only
                if (userValues[1] == UsernameEntry.Text || userValues[3] == EmailEntry.Text)
                {
                    userfound = true;
                }
            }
            if (userfound)
            {
                await DisplayAlert("User already registrated: ", "No! You already have an account for that email address.", "OK");
                return;
            }
            //if the user hasn´t been already registrated, and all the entries are correctly filled, 
            // then a new user is written in the txt file with those values, using the UserWriteToFile(); function
            if (!userfound)
            {
                User user = new User(NameEntry.Text, UsernameEntry.Text, PasswordEntry.Text, EmailEntry.Text);
                user.UserWriteToFile();
                await DisplayAlert("Success", "Now you can use the conversor!!", "OK");
                await Navigation.PopAsync();
            }
        }
    }
    private async void PolicyTerms_Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Protection Policy",
            "Please Moisés, accept the policy terms. (will I pass your subject?...)",
            "OK");
    }
    //I validate if email and password are in the correct format, using "System.Text.RegularExpressions;" boockshop
    private bool IsValidEmail(string email)
    {
        try
        {
            var emailRegexpr = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegexpr.IsMatch(email);
        }
        catch
        {
            return false;
        }
    }
    public virtual bool IsValidPassword(string password)
    {
        try
        {
            if (password.Length < 8)
            {
                return false;
            }
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).{8,}$");
            return passwordRegex.IsMatch(password);
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
    private async void ExitButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Exit", "Are you sure you want to exit the application?", "Yes", "No");
        if (answer)
        {
            Application.Current.Quit();
        }
    }
}
