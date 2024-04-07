$ErrorActionPreference = "Stop"

Push-Location $PSScriptRoot

try {
  $Env:FTM_VERSION = (Get-Content -Raw version.txt).Trim()
  dotnet clean -v n .\FixThermalMode.Setup.sln
  dotnet build -v n .\FixThermalMode.Setup.sln -c:Release -p:Platform=x64
} finally {
  Pop-Location
}
