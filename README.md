# Azure AI Sentiment Analysis API

Detta projekt är en modern mikrotjänst byggd med **.NET 8 Minimal API** som integrerar **Azure AI Language Services** för att utföra sentimentanalys i realtid. Projektet demonstrerar hur man bygger skalbara API-lösningar i molnet med fokus på säkerhet och observability.

## 🚀 Funktioner
- **AI-Driven Analys:** Använder Azure AI för att klassificera text (Positive, Negative, Neutral) med hög precision.
- **RESTful API:** Enkel integration för moderna webbapplikationer.
- **Säkerhet:** Implementerad separation av känsliga uppgifter (API-nycklar) via miljöspecifik konfiguration.
- **Web Interface:** Ett responsivt gränssnitt för att testa AI-modellen direkt.

## 🛠 Teknikstack
- **Backend:** C# / .NET 8 (Minimal APIs)
- **Molntjänst:** Azure AI Services (Text Analytics)
- **Frontend:** HTML5, CSS3, JavaScript (Fetch API)
- **Verktyg:** Git, VS Code, REST Client

## 🔒 Säkerhet & Best Practices
För att möta krav på säkerhetsprövning och säker hantering av data:
- Ingen känslig information (API-nycklar/Endpoints) lagras i versionshanteringen.
- Projektet använder `.gitignore` och `appsettings.Development.json` för säker hantering av hemligheter.
- Strukturerad loggning för observability.

## 📦 Installation
1. Klona projektet.
2. Lägg till dina Azure-uppgifter i `appsettings.Development.json`.
3. Kör `dotnet run`.