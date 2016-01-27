$packageName = '__PACKAGE_NAME__' # arbitrary name for the package, used in messages
$url ="__PROJECT_BASE_URL__/releases/download/__VERSION__/bin.zip"

$installDir = Join-Path $env:AllUsersProfile "$packageName"
Write-Host "Adding `'$installDir`' to the path and the current shell path"
Install-ChocolateyPath "$installDir"
$env:Path = "$($env:Path);$installDir"

Install-ChocolateyZipPackage "$packageName" "$url" "$installDir" 