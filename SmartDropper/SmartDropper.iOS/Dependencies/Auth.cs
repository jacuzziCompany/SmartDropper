using System;
using System.Threading.Tasks;
using Foundation;
using SmartDropper.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(SmartDropper.iOS.Dependencies.Auth))]

namespace SmartDropper.iOS.Dependencies
{
	public class Auth : IAuth
	{
		public Auth()
		{
		}

        public string GetCurrentUserId()
        {
           return Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser != null;


        }

        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return true;
            }
            catch (NSErrorException error)
            {
                string message = error.Message.Substring(error.Message.IndexOf("NSLocalizedDescription", StringComparison.CurrentCulture));
                message = message.Replace("NSLocalizedDescription=", "").Split('.')[0];
                throw new Exception(message);
            }
            catch (Exception e)
            {
                throw new Exception("the unknown message");
            }
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.CreateUserAsync(email, password);
                return true;
            }
            catch (NSErrorException error)
            {
                string message = error.Message.Substring(error.Message.IndexOf("NSLocalizedDescription", StringComparison.CurrentCulture));
                message = message.Replace("NSLocalizedDescription=", "").Split('.')[0];
                throw new Exception(message);
            }
            catch (Exception e)
            {
                throw new Exception("the unknown message");
            }
        }
    }
}


