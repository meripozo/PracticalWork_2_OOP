namespace PracticalWork_2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
		Routing.RegisterRoute(nameof(RecoverPasswordPage), typeof(RecoverPasswordPage));
		Routing.RegisterRoute(nameof(ConversorPage), typeof(ConversorPage));
		Routing.RegisterRoute(nameof(UserInfoPage), typeof(UserInfoPage));
	}
}
