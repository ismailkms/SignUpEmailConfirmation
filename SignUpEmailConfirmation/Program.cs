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
//RegisterValidatorsFromAssemblyContaining'in i�erisine Validator' un bulundu�u katmanda olu�turdu�umuz her hangi bir class'� verebiliriz. Buradan sonra Assembly'deki yani Validator' un bulundu�u katman�ndaki t�m validator'ler �a�r�lacakt�r. Burada �nemli olan dosyan�n yolunu(assembly) almak.

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
