using FluentValidation.AspNetCore;
using SignUpEmailConfirmation.Abstraction.Services;
using SignUpEmailConfirmation.Concrete.Services;
using SignUpEmailConfirmation.Validators.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISignUpService, SignUpService>();
builder.Services.AddScoped<IMailService, MailService>();

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserValidator>());
//RegisterValidatorsFromAssemblyContaining'in içerisine Validator' un bulunduðu katmanda oluþturduðumuz her hangi bir class'ý verebiliriz. Buradan sonra Assembly'deki yani Validator' un bulunduðu katmanýndaki tüm validator'ler çaðrýlacaktýr. Burada önemli olan dosyanýn yolunu(assembly) almak.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SignUp}/{action=Index}/{id?}");

app.Run();
