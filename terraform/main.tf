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

resource "azurerm_resource_group" "rg" {
    name = var.resource_group_name
    location = var.location
    tags = var.tags
}

resource "azurerm_storage_account" "storage" {
  name = var.storage_account_name
  resource_group_name = var.resource_group_name
  location = var.location
  tags = var.tags
  account_tier = "Standard"
  account_replication_type = "LRS"
}


