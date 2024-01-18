using CleanArchitecture.MVC;


var builder = WebApplication.CreateBuilder(args);

//1- Config services to the container.
//====================================
builder.Services.AddMvcServices(builder.Configuration);

//2- Build Web Application using Previous builder (that hold settings and services)
//=================================================================================

var app = builder.Build();

//3- Configure the HTTP request pipeline. (Add Middlewares built-in & custome midlewares)
//=======================================================================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCookiePolicy();
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");


//4-Start Application
//===================
app.Run();
