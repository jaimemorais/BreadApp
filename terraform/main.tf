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
    name = var.breadapp_resource_group_name
    location = var.breadapp_location
    tags = var.breadapp_tags
}

resource "azurerm_storage_account" "breadpp-tf-storage" {
  name = var.breadapp_storage_account_name
  resource_group_name = var.breadapp_resource_group_name
  location = var.breadapp_location
  tags = var.breadapp_tags
  account_tier = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_container" "breadapp-tf-blob-storage-pics" {
  name                  = var.breadapp_storage_pics_blob_container_name
  storage_account_name  = var.breadapp_storage_account_name
  container_access_type = "private"
}

resource "azurerm_eventgrid_topic" "breadpp-tf-eventgrid-sendmail-topic" {
  name                = var.breadapp_eventgrid_sendmail_topic
  location            = var.breadapp_location
  resource_group_name = var.breadapp_resource_group_name
  tags                = var.breadapp_tags
}

