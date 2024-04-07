$ErrorActionPreference = "Stop"

Push-Location $PSScriptRoot

try {
  if (Test-Path publish\api\appsettings.Development.json) {
    Remove-Item publish\api\appsettings.Development.json
  }

  if (Test-Path publish\api\appsettings.json) {
    if (Test-Path publish\api\appsettings-template.json) {
      Remove-Item publish\api\appsettings-template.json
    }

    Rename-Item publish\api\appsettings.json appsettings-template.json
  }

  if (Test-Path publish\client\appsettings.json) {
    if (Test-Path publish\client\appsettings-template.json) {
      Remove-Item publish\client\appsettings-template.json
    }

    Rename-Item publish\client\appsettings.json appsettings-template.json
  }

  if (-not ((Test-Path publish\api\appsettings-template.json) -and (Test-Path publish\client\appsettings-template.json))) {
    throw "Missing appsettings-templates.json files."
  }
} finally {
  Pop-Location
}
