# Update Template module to .NET 10.0
$templatePath = "Z:\S\Unsynced\REPOS\BASE\SERVICE\SUBMODULES\BASE.Modules.Template\SOURCE"

Get-ChildItem -Path $templatePath -Filter "*.csproj" -Recurse | ForEach-Object {
    $content = Get-Content $_.FullName -Raw
    $updated = $content -replace '<TargetFramework>net[78]\.0</TargetFramework>', '<TargetFramework>net10.0</TargetFramework>'
    
    if ($content -ne $updated) {
        Set-Content -Path $_.FullName -Value $updated -NoNewline
        Write-Host "Updated: $($_.Name)"
    }
}

Write-Host "Done updating Template module to .NET 10.0"
