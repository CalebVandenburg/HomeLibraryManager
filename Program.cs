

using HomeLibraryManager.Database;
using HomeLibraryManager.GoogleBooks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Library/Home", "");
    options.Conventions.AddPageRoute("/Google/Search", "/Search");
    options.Conventions.AddPageRoute("/Reviews/Reviews", "/Reviews");
});

//ensure database is created and then add to services
using (var context = new DatabaseContext())
{
    context.Database.Migrate();
    builder.Services.AddSingleton<BookRepository>();
}
builder.Services.AddSingleton<GoogleBooksManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
