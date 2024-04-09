using WebApplication10.Services;
using Microsoft.OpenApi.Models;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WebApplication10.Services.Implementations;
using HealthChecks.UI.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API v1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API v2", Version = "v2" });
    c.SwaggerDoc("v3", new OpenApiInfo { Title = "My API v3", Version = "v3" });
});

builder.Services.ConfigureHealthChecks(builder.Configuration);

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
})
    .AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddMvc();

builder.Services.AddHealthChecks();

builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ICommunityService, CommunityService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API v2");
        c.SwaggerEndpoint("/swagger/v3/swagger.json", "My API v3");
    });
}

app.MapHealthChecks("/api/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseHealthChecksUI(delegate (Options options)
{
    options.UIPath = "/healthcheck-ui";

});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();