# Check Template module target frameworks
Get-ChildItem -Path "Z:\S\Unsynced\REPOS\BASE\SERVICE\SUBMODULES\BASE.Modules.Template\SOURCE" -Filter "*.csproj" -Recurse | ForEach-Object {
    $content = Get-Content $_.FullName -Raw
    if ($content -match '<TargetFramework>([^<]+)</TargetFramework>') {
        Write-Host "$($_.Name): $($Matches[1])"
    }
}
