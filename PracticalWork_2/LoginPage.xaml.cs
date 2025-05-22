using Microsoft.Maui.Controls;
using System;
namespace PracticalWork_2;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
	private async void SignInButton_Clicked(object sender, EventArgs e)
	{
		string username = UsernameEntry.Text;
		string password = PasswordEntry.Text;

		if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))    //cambiar esto a un if igualando a comillas vacías
		{
			await DisplayAlert("Error", "Please enter both username and password", "OK");
			await Navigation.PushAsync(new ConversorPage());
			//return;//este return no se puede hacer
		}

		// codigo lógica de autenticación

		//bool isAuthenticated = ValidateUser(username, password);

		// if (isAuthenticated)
		// {
			//await Navigation.PushAsync(new ConversorPage());
			//await DisplayAlert("Success", "Login successful!", "OK");
		//}
		else
		{
			await DisplayAlert("Error", "Invalid username or password", "OK");
		}
	}
	// private bool ValidateUser(string username, string password)
	// {
	// 	// validaciónnes...
	// 	return (username == "admin" && password == "password");
	// }
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
