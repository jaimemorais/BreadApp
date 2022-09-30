provider "azurerm" {
 features {
 }
}

# tf init --backend-config=breadapp-azure-tf.backend
# breadapp-azure-tf.backend keys :
#resource_group_name  = ""
#storage_account_name = ""
#container_name       = ""
#key                  = ""
terraform {
  backend "azurerm" {}
}

resource "azurerm_resource_group" "breadpp-tf-rg" {
    name = "${var.breadapp_project_name}-${var.breadapp_environment}-rg"
    location = var.breadapp_location
    tags = var.breadapp_tags
}


# Storage
resource "azurerm_storage_account" "breadpp-tf-storage" {
  name = var.breadapp_storage_account_name
  resource_group_name = azurerm_resource_group.breadpp-tf-rg.name
  location = var.breadapp_location
  tags = var.breadapp_tags
  account_tier = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "breadapp-tf-blob-storage-pics" {
  name                  = var.breadapp_storage_pics_blob_container_name
  storage_account_name  = azurerm_storage_account.breadpp-tf-storage.name
  container_access_type = "private"
}


# Event Grid
resource "azurerm_eventgrid_topic" "breadapp-tf-eventgrid-sendmail-topic" {
  name                = var.breadapp_eventgrid_sendmail_topic
  resource_group_name = azurerm_resource_group.breadpp-tf-rg.name
  location            = var.breadapp_location
  tags                = var.breadapp_tags
  input_schema        = "CloudEventSchemaV1_0"
}


# Functions
module "breadapp-azure-function-sendmail" {
  source = "./modules/breadapp-function"

  breadapp_function_name = var.breadapp_function_sendmail_name

  breadapp_function_rg = azurerm_resource_group.breadpp-tf-rg.name
  breadapp_function_location = var.breadapp_location
  breadapp_function_storage_account_name = var.breadapp_functions_storage_account_name
  breadapp_function_appservice_plan_name = var.breadapp_functions_appservice_plan_name
  breadapp_function_appservice_plan_name_sku = "B1"
}

output "breadapp-resource-group-id" {
  value = azurerm_resource_group.breadpp-tf-rg.id
}
