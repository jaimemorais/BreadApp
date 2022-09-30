
resource "azurerm_storage_account" "breadapp-tf-function-storage" {
  name                     = var.breadapp_function_storage_account_name
  resource_group_name      = var.breadapp_function_rg
  location                 = var.breadapp_function_location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_service_plan" "breadapp-tf-function-app-service-plan" {
  name                = var.breadapp_function_appservice_plan_name
  resource_group_name = var.breadapp_function_rg
  location            = var.breadapp_function_location
  os_type             = "Linux"
  sku_name            = var.breadapp_function_appservice_plan_name_sku
}


resource "azurerm_linux_function_app" "breadapp-tf-function" {
  name                       = var.breadapp_function_name
  resource_group_name        = var.breadapp_function_rg
  location                   = var.breadapp_function_location

  service_plan_id            = azurerm_service_plan.breadapp-tf-function-app-service-plan.id

  storage_account_name       = var.breadapp_function_storage_account_name
  storage_account_access_key = azurerm_storage_account.breadapp-tf-function-storage.primary_access_key

  site_config {
    application_stack {
      dotnet_version = "6.0"
    }
    app_service_logs {
      disk_quota_mb         = 35
      retention_period_days = 60
    }
  }

  lifecycle {
    ignore_changes = [
       app_settings
    ]
  }

}