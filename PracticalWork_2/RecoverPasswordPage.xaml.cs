using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PracticalWork_2;

public partial class RecoverPasswordPage : ContentPage
{
    private string currentUsername;
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
    public virtual bool IsValidPassword(string password)
    {
        try
        {
            
            // Verificar que tenga al menos 8 caracteres
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

    
    //this function belongs to IQueryAttributable interface, I use it "catch" the parameters passed from the Query (from another page)
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("currentusername"))
            this.currentUsername = query["currentusername"].ToString();
    }

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
        
//hacer q las contraseñas no coincidan, y q además no existan ya en el txt
        string filePath = "PracticalWork_2/UserInfoSaved.txt";
        if (File.Exists(filePath))
        {

            string[] lines = File.ReadAllLines(filePath);

            bool currentUserExists = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts[3] == EmailEntry.Text)
                {
                    parts[2] = NewPasswordEntry.Text;
                    lines[i] = string.Join(";", parts);
                    currentUserExists = true;
                }
            }

            if (currentUserExists)
            {
                File.WriteAllLines(filePath, lines);

                await DisplayAlert("Success", "Your password has been changed!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Email not found in our system...", "OK");
                return;
            }
            // foreach (string line in File.ReadAllLines(filePath))
            // {
            //     //I make the split to read the values of the txt
            //     string[] userValues = line.Split(";");

            //     bool currentUserExists = false;
            //     for (int i = 0; i < userValues.Length; i++)
            //     {

            //         string[] parts = userValues[i].Split(';');

            //         if (userValues[3] == EmailEntry.Text)
            //         {
            //             currentUserExists = true;
            //         }

            //         if (currentUserExists)
            //         {


            //             parts[4] = NewPasswordEntry.Text;
            //             userValues[i] = string.Join(";", parts);
            //             currentUserExists = true;


            //             File.WriteAllLines(filePath, userValues);
            //         }
            //         else
            //         {
            //             await DisplayAlert("Error", "Email not found in our system...", "OK");
            //             return;
            //         }
            //     }


            // }
        }


    }
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
