using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Useful_utility.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();




/* ���������� ����� � ����������� */
builder.Configuration.AddJsonFile("appsettings.json");

/* ����������� ������ ��� ������� �� ������� ����,
 * ��������� �� ����� ����� �������� �� ������ ����� */
builder.WebHost.UseUrls($"{builder.Configuration.GetValue<string>("url")}:{builder.Configuration.GetValue<int>("HostPort")}" );


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
