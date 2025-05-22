using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PracticalWork_2;

public partial class UserInfoPage : ContentPage
{
    // Ruta al archivo donde se guarda la información del usuario activo
    private string currentUserFilePath = Path.Combine(FileSystem.AppDataDirectory, "currentUser.txt");

    public UserInfoPage()
    {
        InitializeComponent();
        LoadUserInfoAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Recargar la información cada vez que la página aparece
        LoadUserInfoAsync();
    }

    private async void LoadUserInfoAsync()
    {
        try
        {
            if (File.Exists(currentUserFilePath))
            {
                // Leer la información del usuario desde el archivo
                string[] userInfo = await File.ReadAllLinesAsync(currentUserFilePath);
                
                // Asegurarse de que tenemos al menos la información básica
                if (userInfo.Length >= 3)
                {
                    // Asignar los valores a los elementos de la UI
                    UsernameLabel.Text = userInfo[0];
                    EmailLabel.Text = userInfo[1];
                    
                    // Mostrar asteriscos para la contraseña por seguridad
                    // Asumimos que userInfo[2] contiene la contraseña
                    PasswordLabel.Text = new string('*', userInfo[2].Length);
                    
                    // Si hay información sobre el número de operaciones
                    if (userInfo.Length >= 4 && int.TryParse(userInfo[3], out int operations))
                    {
                        OperationsLabel.Text = operations.ToString();
                    }
                    else
                    {
                        OperationsLabel.Text = "0"; // Valor predeterminado
                    }
                }
                else
                {
                    await DisplayAlert("Error", "User information is incomplete.", "OK");
                }
            }
            // else
            // {
            //     await DisplayAlert("Error", "No user is currently logged in.", "OK");
            //     // Opcionalmente redirigir a la página de inicio de sesión
            //     await Navigation.PopAsync();
            // }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load user information: {ex.Message}", "OK");
        }
    }

    // Método para actualizar el número de operaciones
    public void UpdateOperationsCount(int count)
    {
        OperationsLabel.Text = count.ToString();
        
        // También actualizamos el archivo
        try
        {
            if (File.Exists(currentUserFilePath))
            {
                string[] userInfo = File.ReadAllLines(currentUserFilePath);
                if (userInfo.Length >= 4)
                {
                    userInfo[3] = count.ToString();
                }
                else
                {
                    // Si no existía la línea para operaciones, la añadimos
                    Array.Resize(ref userInfo, 4);
                    userInfo[3] = count.ToString();
                }
                
                File.WriteAllLines(currentUserFilePath, userInfo);
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Failed to update operations count: {ex.Message}", "OK").ConfigureAwait(false);
        }
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ExitButton_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Confirmation", "Do you want to exit the application?", "Yes", "No");
        if (answer)
        {
            // En apps móviles reales, sería mejor navegar a la página de login o la página inicial
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
