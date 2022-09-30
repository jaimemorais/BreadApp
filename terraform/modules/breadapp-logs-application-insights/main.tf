
resource "azurerm_log_analytics_workspace" "breadapp-tf-loganalytics-workspace" {
  name                = var.breadapp_loganalytics_workspace_name
  resource_group_name = var.breadapp_logs_appinsights_rg
  location            = var.breadapp_logs_appinsights_location
  tags                = var.breadapp_logs_appinsights_tags
  sku                 = "PerGB2018"
  retention_in_days   = 30
}

resource "azurerm_application_insights" "breadapp-tf-application-insights" {
  name                = var.breadapp_application_insights_name
  resource_group_name = var.breadapp_logs_appinsights_rg
  location            = var.breadapp_logs_appinsights_location
  tags                = var.breadapp_logs_appinsights_tags
  workspace_id        = azurerm_log_analytics_workspace.breadapp-tf-loganalytics-workspace.id
  application_type    = "web"
}

