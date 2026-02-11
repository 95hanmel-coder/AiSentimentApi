// Bicep-mall för att skapa Azure AI Language Service
param location string = resourceGroup().location
param accountName string = 'HanmelAiService'

resource aiAccount 'Microsoft.CognitiveServices/accounts@2023-05-01' = {
  name: accountName
  location: location
  kind: 'TextAnalytics'
  sku: {
    name: 'F0' // Gratis-nivån
  }
  properties: {
    publicNetworkAccess: 'Enabled'
  }
}
