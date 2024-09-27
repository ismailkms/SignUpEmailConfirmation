using SignUpEmailConfirmation.Abstraction.Services;
using SignUpEmailConfirmation.Helpers;
using SignUpEmailConfirmation.ViewModels;
using System.Text.Json;

namespace SignUpEmailConfirmation.Concrete.Services
{
    public class SignUpService : ISignUpService
    {
        readonly IConfiguration _configuration;
        readonly IMailService _mailService;

        public SignUpService(IMailService mailService, IConfiguration configuration)
        {
            _mailService = mailService;
            _configuration = configuration;
        }

        public async Task SendConfirmationEmailAsync(User user)
        {
            string jsonUser = JsonSerializer.Serialize(user);
            string encodeUser = jsonUser.UrlEncode();
            string confirmationEmailUrl = _configuration["ConfirmationEmailUrl"];

            string mail = $"Merhaba {user.UserName},<br><br>" +
                $"Kullanıcı kayıt işlemini tamamlamak için alttaki linke basınız.<br><br>" +
                $"<a href='{confirmationEmailUrl}/{encodeUser}' target='_blank' > İşlemi onaylamak için basınız. </a><br><br>" +
                $"İyi günler.";

            await _mailService.SendMailAsync(user.Email, "Mail Onayı", mail);
        }

        public User JsonDeserializeUser(string user)
        {
            string decodeUser = user.UrlDecode();
            return JsonSerializer.Deserialize<User>(decodeUser);
        }
    }
}
