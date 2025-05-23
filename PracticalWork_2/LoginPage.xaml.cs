using Microsoft.Maui.Controls;
using System;
using System.IO;
namespace PracticalWork_2;


public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
	private async void SignInButton_Clicked(object sender, EventArgs e)
	{

		if (string.IsNullOrEmpty(UsernameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))    //cambiar esto a un if igualando a comillas vacías
		{
			await DisplayAlert("Error", "Please enter both username and password", "OK");
		}


		string filePath = "PracticalWork_2/UserInfoSaved.txt";
		if (File.Exists(filePath))
		{
			foreach (string line in File.ReadAllLines(filePath))
			{
				//I make the split to read the values of the txt
				string[] userValues = line.Split(";");

				if (userValues[1] == UsernameEntry.Text && userValues[2] == PasswordEntry.Text)
				{
					await Shell.Current.GoToAsync($"{nameof(ConversorPage)}?currentusername={UsernameEntry.Text}");
				}
			}
		}
		else
		{
			await DisplayAlert("Error", "Invalid username or password", "OK");
		}
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
	private async void ForgotPassword_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RecoverPasswordPage());
	}
	private async void SignUp_Tapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegisterPage());
	}
}
