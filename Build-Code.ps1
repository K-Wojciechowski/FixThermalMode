$ErrorActionPreference = "Stop"
$ApiProjects = @("FixThermalMode.Api")
$ClientProjects = @("FixThermalMode.Cli", "FixThermalMode.CliVb", "FixThermalMode.Gui")

Push-Location $PSScriptRoot

try {
  dotnet clean -v n FixThermalMode.sln
  dotnet build -v n FixThermalMode.sln -c:Release

  if (Test-Path publish) {
    Remove-Item -Recurse publish
  }

  $ApiProjects | ForEach-Object {
    dotnet publish src\$_ -r win-x64 -c Release --no-self-contained -o publish\api
  }

  $ClientProjects | ForEach-Object {
    dotnet publish src\$_ -r win-x64 -c Release --no-self-contained -o publish\client
  }
} finally {
  Pop-Location
}
