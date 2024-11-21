using FeatureHubSDK;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IClientContext>(sp =>
{
    var featureHubConfig = new EdgeFeatureHubConfig("http://localhost:8085", Environment.GetEnvironmentVariable("FEATUREHUB_KEY"));
    return featureHubConfig.NewContext();
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
