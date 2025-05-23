using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;
namespace PracticalWork_2;

public partial class RecoverPasswordPage : ContentPage
{
    private const string USER_DATA_FILE = "userdata.txt";
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

    private async void ResetPasswordButton_Clicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text?.Trim();
        string newPassword = NewPasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        // Validar entrada
        if (string.IsNullOrEmpty(email))
        {
            StatusMessage.Text = "Please enter your email";
            return;
        }

        if (string.IsNullOrEmpty(newPassword))
        {
            StatusMessage.Text = "Please enter a new password";
            return;
        }

        if (string.IsNullOrEmpty(confirmPassword))
        {
            StatusMessage.Text = "Please confirm your new password";
            return;
        }

        // Comprobar que las contraseñas coinciden
        if (newPassword != confirmPassword)
        {
            StatusMessage.Text = "Passwords don't match";
            return;
        }

        // Verificar si el email existe y actualizar contraseña
        if (await VerifyEmailAndUpdatePassword(email, newPassword))
        {
            await DisplayAlert("Success", "Password has been reset successfully", "OK");
            await Navigation.PopAsync(); // Volver a la página de inicio de sesión
        }
        else
        {
            StatusMessage.Text = "Email not found in our records";
        }
    }

    private async Task<bool> VerifyEmailAndUpdatePassword(string email, string newPassword)
    {
        try
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, USER_DATA_FILE);

            // Comprobar si el archivo existe
            if (!File.Exists(filePath))
            {
                return false;
            }

            // Leer todas las líneas del archivo
            string[] lines = await File.ReadAllLinesAsync(filePath);
            bool emailFound = false;

            // Crear un nuevo array para las líneas actualizadas
            string[] updatedLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] userData = line.Split(',');

                // Verificar si el formato de la línea es correcto (usualmente username, email, password)
                if (userData.Length >= 3)
                {
                    // Comprueba si el email coincide (asumiendo que el email es el segundo campo)
                    string userEmail = userData[1].Trim();

                    if (userEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                    {
                        // El email existe, actualiza la contraseña (asumiendo que la contraseña es el tercer campo)
                        userData[2] = newPassword;
                        emailFound = true;

                        // Reconstruye la línea con la nueva contraseña
                        updatedLines[i] = string.Join(",", userData);
                    }
                    else
                    {
                        // Mantener la línea original si el email no coincide
                        updatedLines[i] = line;
                    }
                }
                else
                {
                    // Si la línea no tiene el formato esperado, la mantenemos como está
                    updatedLines[i] = line;
                }
            }

            // Si encontramos el email, actualizar el archivo
            if (emailFound)
            {
                await File.WriteAllLinesAsync(filePath, updatedLines);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            return false;
        }
    }
    
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
