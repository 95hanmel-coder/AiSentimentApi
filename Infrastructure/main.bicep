param location string = resourceGroup().location
param accountName string = 'ai-sentiment-service'

resource cognitiveService 'Microsoft.CognitiveServices/accounts@2023-05-01' = {
  name: accountName
  location: location
  kind: 'TextAnalytics'
  sku: {
    name: 'F0'
  }
  properties: {
    publicNetworkAccess: 'Enabled'
  }
}
