using WebApplicationState.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// For save session in memory and use memmory cache
builder.Services.AddMemoryCache();

//for using session
builder.Services.AddSession();

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

//for using session
app.UseSession();

//use custom middleware
app.UseCustomMiddleware();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Use(async (context, next) =>
{
    context.Items["myKey"] = "hi";
    await next();
});

app.Run(async context =>
{
    string value = context.Items["myKey"]?.ToString();
    string message = context.Items[CustomMiddleware.myCustomMiddlewareKey] as string;
    await context.Response.WriteAsync($"{value} {message}");
});
//app.Run();
