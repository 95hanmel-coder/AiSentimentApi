# Azure AI Sentiment Analysis API

Detta projekt är en modern mikrotjänst byggd med **.NET 8 Minimal API** som integrerar **Azure AI Language Services** för att utföra sentimentanalys i realtid. Projektet demonstrerar hur man bygger skalbara API-lösningar i molnet med fokus på säkerhet, automatisering och observability.

## 🚀 Funktioner
- **AI-Driven Analys:** Använder Azure AI för att klassificera text (Positive, Negative, Neutral) med hög precision.
- **Infrastructure as Code (IaC):** Inkluderar Azure Bicep-mallar för automatiserad provisionering av molnresurser.
- **Observability:** Implementerad strukturerad loggning med **Serilog** för spårbarhet och driftövervakning.
- **Web Interface:** Ett responsivt gränssnitt för att interagera med AI-modellen direkt.

## 🛠 Teknikstack
- **Backend:** C# / .NET 8 (Minimal APIs)
- **Molntjänst:** Azure AI Services (Text Analytics)
- **IaC:** Azure Bicep
- **Loggning:** Serilog (Console & File sinks)
- **Frontend:** HTML5, JavaScript (Fetch API)

## 🔒 Säkerhet & Best Practices
För att möta krav på säkerhetsprövning och god molnhygien:
- **Secret Management:** Känslig information hanteras via miljöspecifik konfiguration och exkluderas från versionshantering via `.gitignore`.
- **Cloud Architecture:** Designat enligt principer för mikrotjänster med tydlig separation mellan infrastruktur och applikationslogik.

## 📦 Installation & Setup
1. **Infrastruktur:** Provisionera resurser med medföljande Bicep-fil:
   `az deployment group create --resource-group <din-rg> --template-file Infrastructure/main.bicep`
2. **Konfiguration:** Lägg till Azure-uppgifter i `appsettings.Development.json`.
3. **Kör appen:** `dotnet run`git add README.md
