

output "application_insights_instrumentation_key" {
  value = azurerm_application_insights.breadapp-tf-application-insights.instrumentation_key
}

output "application_insights_app_id" {
  value = azurerm_application_insights.breadapp-tf-application-insights.app_id
}