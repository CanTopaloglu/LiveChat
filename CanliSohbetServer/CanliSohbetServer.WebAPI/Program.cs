using CanliSohbetServer.WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(configure =>
{
    configure.AddDefaultPolicy(policy =>
    {
        policy
        .AllowAnyHeader() //Origin: "application/json //Authorization: asdas - Key valuelara izin veriyor.
        .AllowAnyMethod() //GET POST PUT
        .AllowCredentials() //WEBSOCKET
        .SetIsOriginAllowed(policy => true); //policyden gelen tüm isteklere izin vermek 
    });
});

builder.Services.AddSignalR();

builder.Services.AddControllers();
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

app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.MapHub<SohbetHub>("sohbet-hub");

app.Run();
