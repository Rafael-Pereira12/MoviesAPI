using BeeEngineering.Learning.MoviesApp.Data;
using Business;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviesAPI.DataAccess;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddIdentityCore<IdentityUser<long>>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<MoviesAppContext>()
    .AddSignInManager<SignInManager<IdentityUser<long>>>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
 {
     options.SaveToken = true;
     options.RequireHttpsMetadata = false;
     options.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidAudience = configuration["JWT:ValidAudience"],
         ValidIssuer = configuration["JWT.ValidIssuer"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
     };
 });



builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    //// Lockout settings.
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //options.Lockout.MaxFailedAccessAttempts = 5;
    //options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+!";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});



var connectionString = builder.Configuration.GetConnectionString("MoviesApi");
//var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
// Add services to the container.

builder.Services.AddDbContext<MoviesAppContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IActorBusinessObject, ActorBusinessObject>();
builder.Services.AddScoped<IActorDataAccessObject, ActorDataAccessObject>();

builder.Services.AddScoped<IDirectorBusinessObject, DirectorBusinessObject>();
builder.Services.AddScoped<IDirectorDataAccessObject, DirectorDataAccessObject>();

builder.Services.AddScoped<IGenreBusinessObject, GenreBusinessObject>();
builder.Services.AddScoped<IGenreDataAccessObject, GenreDataAccessObject>();

builder.Services.AddScoped<IMovieBusinessObject, MovieBusinessObject>();
builder.Services.AddScoped<IMovieDataAccessObject, MovieDataAccessObject>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var serviceFactory = (IServiceScopeFactory?)app.Services.GetService(typeof(IServiceScopeFactory));
    using (var scope = serviceFactory?.CreateScope())
    {
        var services = scope?.ServiceProvider;
        var dbContext = services?.GetRequiredService<MoviesAppContext>();
        dbContext?.Database.EnsureCreated();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

