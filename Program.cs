using Serilog;
using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Konfigurera Serilog för "Observability"
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/sentiment-api-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Konfigurera AI-inställningar från appsettings.json
builder.Services.Configure<AiSettings>(builder.Configuration.GetSection("AiSettings"));

builder.Services.AddSingleton(sp =>
{
    var settings = sp.GetRequiredService<IOptions<AiSettings>>().Value;
    var endpoint = new Uri(settings.Endpoint);
    var credentials = new AzureKeyCredential(settings.Key);
    return new TextAnalyticsClient(endpoint, credentials);
});

var app = builder.Build();

// Viktigt för gränssnittet:
app.UseDefaultFiles();
app.UseStaticFiles();

// Endpoint för analys
app.MapPost("/analyze", async (TextRequest request, TextAnalyticsClient client, ILogger<Program> logger) =>
{
    try 
    {
        logger.LogInformation("Analyserar text: {Text}", request.Text);
        var response = await client.AnalyzeSentimentAsync(request.Text);
        var doc = response.Value;

        return Results.Ok(new
        {
            OriginalText = request.Text,
            Sentiment = doc.Sentiment.ToString(),
            Confidence = new {
                Positive = doc.ConfidenceScores.Positive,
                Neutral = doc.ConfidenceScores.Neutral,
                Negative = doc.ConfidenceScores.Negative
            }
        });
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Ett fel uppstod vid AI-analys");
        return Results.Problem("Kunde inte analysera texten.");
    }
});

app.Run();

// Modeller
public record TextRequest(string Text);
public class AiSettings {
    public string Key { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;
}