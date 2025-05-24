using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PracticalWork_2;

public partial class RecoverPasswordPage : ContentPage
{
    public RecoverPasswordPage()
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

    public virtual bool IsValidEmail(string email)
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

    
    //this function belongs to IQueryAttributable interface, I use it "catch" the parameters passed from the Query (from another page)
    // public void ApplyQueryAttributes(IDictionary<string, object> query)
    // {
    //     if (query.ContainsKey("currentusername"))
    //         this.currentUsername = query["currentusername"].ToString();
    // }

    private async void ResetPasswordButton_Clicked(object sender, EventArgs e)
    {
        if (NewPasswordEntry.Text == null || NewPasswordEntry.Text == "" || EmailEntry.Text == null || EmailEntry.Text == "" || ConfirmNewPasswordEntry.Text == null || ConfirmNewPasswordEntry.Text == "")
        {
            await DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }
        if (!IsValidEmail(EmailEntry.Text))
        {
            await DisplayAlert("Error", "Please enter a valid email address", "OK");
            return;
        }
        if (NewPasswordEntry.Text != ConfirmNewPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }
        else
        {
            StatusMessage.Text = "Email not found in our records";
        }

        string filePath = "PracticalWork_2/UserInfoSaved.txt";
        // if (File.Exists(filePath))
        // {
        //     foreach (string line in File.ReadAllLines(filePath))
        //     {
        //         //I make the split to read the values of the txt
        //         string[] userValues = line.Split(";");

        //         bool currentUserExists = false;
        //         for (int i = 0; i < lines.Length; i++)
        //         {
        //             string[] parts = lines[i].Split(';');
        //             if (parts[1] == this.currentUsername)
        //             {
        //                 int numberOfOperations = Convert.ToInt32(parts[4]);
        //                 numberOfOperations++; //I increment it before writing in the txt
        //                 parts[4] = numberOfOperations.ToString();
        //                 lines[i] = string.Join(";", parts);
        //                 currentUserExists = true;
        //             }
        //         }

        //         if (currentUserExists)
        //         {
        //             File.WriteAllLines(filePath, lines);
        //         }
        //         else
        //         {
        //             await DisplayAlert("Error", "Invalid username or password", "OK");
        //             return;
        //         }
        //     }
        // }


    }
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
