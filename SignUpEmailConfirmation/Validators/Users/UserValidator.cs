using FluentValidation;
using SignUpEmailConfirmation.ViewModels;

namespace SignUpEmailConfirmation.Validators.Users
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen kullanıcı adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Lütfen kullanıcı adını 2 ile 150 karakter arasında giriniz.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen şifre bilgisini boş geçmeyiniz.")
                .Equal(u => u.PasswordConfirm)
                    .WithMessage("Şifre ve şifre tekrar aynı olmalıdır.")
                .MinimumLength(4)
                    .WithMessage("Şifre en az 4 karakterli olmalıdır.")
                .MaximumLength(16)
                    .WithMessage("Şifre en fazla 16 karakterli olmalıdır.")
                .Matches("[A-Z]")
                    .WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches("[a-z]")
                    .WithMessage("Şifre en az bir küçük harf içermelidir")
                .Matches("[0-9]")
                    .WithMessage("Şifre en az bir rakam içermelidir.")
                .Matches("[^a-zA-Z0-9]")
                    .WithMessage("Şifre en az bir özel karakter içermelidir."); ;

            RuleFor(u => u.PasswordConfirm)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen şifre tekrar bilgisini boş geçmeyiniz.")
                .Equal(u => u.Password)
                    .WithMessage("Şifre ve şifre tekrar aynı olmalıdır.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen email bilgisini boş geçmeyiniz.")
                .EmailAddress();
        }
    }
}
