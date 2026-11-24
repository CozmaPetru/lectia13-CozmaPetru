using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using AutoLab.Data;
using AutoLab.Furnizori;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(ConfigureazaMvc);

// Literele românești rămân necodificate în HTML-ul trimis (ă, nu &#x103;).
// Se vede în sursa paginii și în fila Network. Nu este obiectul lecției.
builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(UnicodeRanges.All));

// Contextul bazei de date: SQLite, cu șirul de conexiune din appsettings.json.
string sirConexiune = builder.Configuration.GetConnectionString("AutoLab");
builder.Services.AddSqlite<AutoDbContext>(sirConexiune);

WebApplication app = builder.Build();

// Cultura aplicației: aceeași pe toate calculatoarele din laborator,
// indiferent de setările regionale ale sistemului de operare.
CultureInfo cultura = new CultureInfo("ro-MD");
CultureInfo.DefaultThreadCurrentCulture = cultura;
CultureInfo.DefaultThreadCurrentUICulture = cultura;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Fișierele încărcate apar după pornire. MapStaticAssets servește doar fișierele
// cunoscute la compilare, așa că pentru ele este nevoie și de UseStaticFiles.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Automobile}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

// Lecția 11, pasul 6: furnizorul propriu, adăugat după cei încorporați.
void ConfigureazaMvc(MvcOptions optiuni)
{
    optiuni.ValueProviderFactories.Add(new CookieValueProviderFactory());

    // Lecția 12: mesajele legării modelului, în română, scrise într-un singur loc.
    DefaultModelBindingMessageProvider mesaje = optiuni.ModelBindingMessageProvider;
    mesaje.SetValueMustBeANumberAccessor(MesajNumar);
    mesaje.SetAttemptedValueIsInvalidAccessor(MesajValoareGresita);
    mesaje.SetValueMustNotBeNullAccessor(MesajValoareLipsa);
}

string MesajNumar(string camp)
{
    return "Câmpul „" + camp + "” cere un număr.";
}

string MesajValoareGresita(string valoare, string camp)
{
    return "Valoarea „" + valoare + "” nu este potrivită pentru câmpul „" + camp + "”.";
}

string MesajValoareLipsa(string valoare)
{
    return "Completează acest câmp.";
}
