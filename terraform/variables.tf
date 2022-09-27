variable "breadapp_environment" {
  type = string
}

variable "breadapp_location" {
  type = string
  default = "eastus"
}

variable "breadapp_tags" {
  type = map(string)
}

variable "breadapp_resource_group_name" {
  type = string
}


variable "breadapp_storage_account_name" {
  type = string
}
variable "breadapp_storage_pics_blob_container_name" {
  type = string
}


variable "breadapp_eventgrid_sendmail_topic" {
  type = string
}


variable "breadapp_functions_storage_account_name" {
  type = string
}
variable "breadapp_functions_appservice_plan_name" {
  type = string
}
variable "breadapp_function_sendmail_name" {
  type = string
}
