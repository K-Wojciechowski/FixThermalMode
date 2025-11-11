$ErrorActionPreference = "Stop"

Push-Location $PSScriptRoot

try {
  $Env:FTM_VERSION = ([xml](Get-Content .\Directory.Build.props)).Project.PropertyGroup.Version + ".0"
  dotnet clean -v n .\FixThermalMode.Setup.sln
  dotnet build -v n .\FixThermalMode.Setup.sln -c:Release -p:Platform=x64
} finally {
  Pop-Location
}
