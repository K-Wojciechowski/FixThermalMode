$ErrorActionPreference = "Stop"

Push-Location $PSScriptRoot

try {
  dotnet clean -v n .\FixThermalMode.Setup.sln
  dotnet build -v n .\FixThermalMode.Setup.sln -c:Release -p:Platform=x64
} finally {
  Pop-Location
}
