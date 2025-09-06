using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Project.DataAccessLayer.Concrete;
using Project.DtoLayer.BookingDto;
using Project.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();

//Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Index";
});


//builder.Services.AddControllersWithViews()
//    .AddFluentValidation(fv =>
//        fv.RegisterValidatorsFromAssemblyContaining<CreateBookingDto>());

var app = builder.Build();


app.UseStatusCodePages( async  codeStatus =>
{
    if (codeStatus.HttpContext.Response.StatusCode == 404)
    {
        codeStatus.HttpContext.Response.Redirect("/Default/Index/");
    }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
