# Execute this PS1 file via Terminal in View
param(
    [switch]$test
)

$projectFilePath = "OrmConfigGenerator.csproj"
[xml]$projectFile = Get-Content $projectFilePath
$propertyGroup = $projectFile.Project.PropertyGroup | Where-Object { $_.Condition -eq $null }

if ($test.IsPresent) {
    $version = $propertyGroup.Version
    $date = Get-Date -Format "yyyyMMdd_HHmmss"
    $destination = ".\bin\OrmConfigGenerator " + $version + " beta $date.zip"
    Write-Host "----- Created new test version $version $date -----"
} else {
    $currentVersion = $propertyGroup.Version
    $versionComponents = $currentVersion -split '\.'
    $versionComponents[2] = [int]$versionComponents[2] + 1
    $newVersion = $versionComponents -join '.'
    $propertyGroup.Version = $newVersion
    $propertyGroup.FileVersion = $newVersion

    $destination = ".\bin\OrmConfigGenerator " + $newVersion + ".zip"
    $projectFile.Save($projectFilePath)
    Write-Host "----- Updated version numbers to $newVersion -----"
}

Write-Host "----- Publishing -----" 
dotnet publish -r win-x64 -c Release --nologo --self-contained

Write-Host "----- Cleaning publish folder -----" 
Remove-item ".\bin\Release\net8.0-windows\win-x64\publish\OrmConfigGenerator.pdb" -Force
Remove-item ".\bin\Release\net8.0-windows\win-x64\publish\D3DCompiler_47_cor3.dll" -Force
Remove-item ".\bin\Release\net8.0-windows\win-x64\publish\PenImc_cor3.dll" -Force
Remove-item ".\bin\Release\net8.0-windows\win-x64\publish\PresentationNative_cor3.dll" -Force
Remove-item ".\bin\Release\net8.0-windows\win-x64\publish\vcruntime140_cor3.dll" -Force
Remove-item ".\bin\Release\net8.0-windows\win-x64\publish\wpfgfx_cor3.dll" -Force

Write-Host "----- Packing -----" 
$source = ".\bin\Release\net8.0-windows\win-x64\publish\"
If(Test-path $destination) {Remove-item $destination}
Add-Type -assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($Source, $destination)

Write-Host "----- Cleaning up -----"
Remove-item ".\bin\Release\" -Recurse -Force

Write-Host "----- Open explorer -----"
Start ".\bin\"
