using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartDropper.Helpers
{
		public interface IAuth
		{
			Task<bool> RegisterUser(string email, string password);
			Task<bool> LoginUser(string email, string password);
			bool IsAuthenticated();
			string GetCurrentUserId();
		}

		public class Auth
		{
			private static IAuth auth = DependencyService.Get<IAuth>();
			public Auth()
			{
			}
			public static async Task<bool> RegisterUser(string email, string password)
			{
				try
				{
					return await auth.RegisterUser(email, password);
				}
				catch (Exception e)
				{

					await App.Current.MainPage.DisplayAlert("error", e.Message, "OK");
					string registerMessage = "keychain";
					if (e.Message.Contains(registerMessage))
					{
						return true;
					}
					else
						return false;
				}
			}
		public static async Task<bool> LoginUser(string email, string password)
		{
			try
			{
				return await auth.LoginUser(email, password);
			}
			catch (Exception e)
			{
				string registerMessageKey = "keychain";
				if (e.Message.Contains(registerMessageKey))
				{
					return true;
				}

				string registerMessage = "There is no user record";
				if (e.Message.Contains(registerMessage))
				{

					await App.Current.MainPage.DisplayAlert("error", "You don't have an account. Please sign in", "OK");
					return false;
				}
				else
				{
					await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
					return false;
				}

			}
		}
			public static bool IsAuthenticated()
			{
				return auth.IsAuthenticated();
			}
			public static string GetCurrentUserId()
			{
				return auth.GetCurrentUserId();
			}
		}

}


