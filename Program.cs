using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles(); // Gör att index.html visas automatiskt
app.UseStaticFiles();  // Tillåter servern att visa filer från wwwroot

// Hämta inställningar från konfigurationsfilen (appsettings.Development.json)
var key = app.Configuration["AiSettings:Key"];
var endpoint = app.Configuration["AiSettings:Endpoint"];

// Validera att nycklar existerar innan start
if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(endpoint))
{
    throw new InvalidOperationException("Saknar AI-nycklar i appsettings.Development.json");
}

// Skapa klient för Azure AI
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(key));

app.MapGet("/", () => "AI-tjänsten är redo.");

app.MapPost("/analyze", async ([FromBody] TextRequest request) =>
{
    // Skickar text till Azure för analys
    DocumentSentiment result = await client.AnalyzeSentimentAsync(request.Text);

    // Returnerar känsla (Sentiment) och säkerhetsnivå (Confidence)
    return Results.Ok(new 
    { 
        OriginalText = request.Text, 
        Sentiment = result.Sentiment.ToString(), 
        Confidence = result.ConfidenceScores 
    });
});

app.Run();

// DTO för inkommande data
record TextRequest(string Text);