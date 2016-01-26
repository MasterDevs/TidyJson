$versionToken = "__VERSION__";
$version = "v1.0.1"

$packageNameToken = "__PACKAGE_NAME__";
$packageName = "TidyJson.portable";

$projectBaseUrl = "https://github.com/MasterDevs/TidyJson";
$projectBaseUrlToken = "__PROJECT_BASE_URL__"

Get-ChildItem -r -include "chocolatey*.ps1","*.nuspec" |
 ForEach-Object { $file = $_; ( Get-Content $file ) |
 ForEach-Object { $_ -replace $versionToken, $version }  | 
 ForEach-Object { $_ -replace $packageNameToken, $packageName }  | 
 ForEach-Object { $_ -replace $projectBaseUrlToken, $projectBaseUrl }  | 
Set-Content $file.FullName  }