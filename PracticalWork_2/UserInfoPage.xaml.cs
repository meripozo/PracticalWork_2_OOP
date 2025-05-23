using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PracticalWork_2;

public partial class UserInfoPage : ContentPage, IQueryAttributable
{
    private string currentUsername;
    public UserInfoPage()
    {
        InitializeComponent();
    }

    //this function belongs to IQueryAttributable interface, I use it "catch" the parameters passed from the Query (from another page)
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("currentusername"))
            this.currentUsername = query["currentusername"].ToString();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        string filePath = "PracticalWork_2/UserInfoSaved.txt";
		if (File.Exists(filePath))
		{
			foreach (string line in File.ReadAllLines(filePath))
			{
				//I make the split to read the values of the txt
				string[] userValues = line.Split(";");

                if (userValues[1] == currentUsername)
                {
                    CurrentNameLabel.Text = userValues[0];
                    UsernameLabel.Text = userValues[1];
                    PasswordLabel.Text = userValues[2];
                    EmailLabel.Text = userValues[3];
                    OperationsLabel.Text = userValues[4];
                    
				}
			}
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
