$packageName = 'TidyJson.portable'
$zipName = "bin.zip"

$installDir = Join-Path $env:AllUsersProfile "$packageName"
Uninstall-ChocolateyZipPackage "$packageName" "$zipName" 
Remove-Item -Recurse -Force "$installDir"
