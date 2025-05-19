namespace PracticalWork_2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("Register", typeof(RegisterPage));
		Routing.RegisterRoute("ForgotPassword", typeof(RecoverPasswordPage));
		Routing.RegisterRoute("Conversor", typeof(ConversorPage));
		Routing.RegisterRoute("UserInfo", typeof(UserInfoPage));
	}
}
