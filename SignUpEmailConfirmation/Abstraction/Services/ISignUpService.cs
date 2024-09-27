using SignUpEmailConfirmation.ViewModels;
using System.Text.Json;

namespace SignUpEmailConfirmation.Abstraction.Services
{
    public interface ISignUpService
    {
        Task SendConfirmationEmailAsync(User user);
        User JsonDeserializeUser(string user);
    }
}
