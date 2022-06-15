using System;
using System.Threading.Tasks;
using Firebase.Auth;
using SmartDropper.Helpers;

using Xamarin.Forms;

[assembly: Dependency(typeof(SmartDropper.Droid.Dependencies.Auth))]
namespace SmartDropper.Droid.Dependencies
{
    public class Auth : IAuth
    {
        public string GetCurrentUserId()
        {
            return FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return FirebaseAuth.Instance.CurrentUser != null;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {

                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                throw new Exception("There is no user record");
            }
            catch (Exception ex)
            {
                throw new Exception("unknown error");
            }
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            try
            {

                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("unknown error");
            }

        }
    }
}


