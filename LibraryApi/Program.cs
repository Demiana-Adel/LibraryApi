using LibraryApi.Data;
using LibraryApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
    Options.UseSqlServer(ConnectionString) , ServiceLifetime.Transient);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICountriesServices , CountriesServices>();
builder.Services.AddTransient<IGenresServices , GenresServices>();
builder.Services.AddTransient<IAuthorsServices , AuthorsServices>();
builder.Services.AddTransient<IBooksServices , BooksServices>();

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
