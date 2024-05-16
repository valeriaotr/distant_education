#pragma warning disable CA1506

using System.Reflection;
using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Logging.Extensions;
using DistantEducation.Application.Extensions;
using DistantEducation.Infrastructure.Persistence.Extensions;
using DistantEducation.Presentation.Http.Extensions;
using DistantEducation.Presentation.Http.Middleware;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddMvcCore();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddInfrastructurePersistence(builder.Configuration); 
builder.Services.AddConnection(builder.Configuration);
builder.Services.AddApplication();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.AddPlatformSerilog(builder.Configuration);
builder.Services.AddUtcDateTimeProvider();
WebApplication app = builder.Build();

app.UseWhen(context => context.Request.Path.StartsWithSegments("/"), appBuilder =>
{
    appBuilder.UseMiddleware<ControllerMiddleware>();
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();
await app.RunAsync();