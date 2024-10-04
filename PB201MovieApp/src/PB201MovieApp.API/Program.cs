using PB201MovieApp.Business.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(typeof(MovieCreateDtoValidator).Assembly);
});

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile<MapProfile>();
});

builder.Services.AddRepositories(builder.Configuration.GetConnectionString("default"));
builder.Services.AddServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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