################################################################################
# Prepackage.ps1
#
# This script generates the chocolatey install and uninstall powershell scripts
# found in the Tools directory in the chocolatey package.
#
# It reads template files fond in the ToolsTemplates directory and replaces
# tokens with run time values.  Tokens are typically strings with leading and
# trailing underscores, e.g. __PACKAGE_NAME__.
#
# Tokens are defined in the Tokens.Json file in the ToolsTemplates directory.
# __VERSION__ is a special token, it is hardcoded to be replaced with the
# environtment variable APPVEYOR_REPO_TAG_NAME.  This allows AppVeyor to
# update version information in the scripts
#
# For more information see:
# https://github.com/MasterDevs/ChocolateyCoolWhip
################################################################################

$versionToken = "__VERSION__";
$version = $env:APPVEYOR_REPO_TAG_NAME
Write-Host "Starting prepackage of version $version";

#######################################
# Find Our Directories
#######################################
Write-Host
$templateDirectory = Get-ChildItem -Recurse -Directory -Include ToolsTemplates TidyJson\TidyJson\Chocolatey

$toolsDir = "$($templateDirectory.Parent.FullName)\Tools"
write-host "Creating $toolsDir"
$silent = New-Item -ItemType Directory -Force -Path $toolsDir

#######################################
# Read Tokens
#######################################
Write-Host
Write-Host "Reading tokens"

$tokenFile = $templateDirectory.EnumerateFiles().Where({$PSItem.Name -eq "tokens.json";})[0]
$json = Get-Content -Raw $tokenFile.FullName
$tokens = ConvertFrom-Json $json
Write-Host "Replacing tokens"
Write-Host "    $versionToken ==> $version"
foreach($token in $tokens)
{
    Write-Host "    $($token.Name) ==> $($token.Value)"
}

#######################################
# Convert tokenized files
#######################################
Write-Host
foreach($file in $templateDirectory.EnumerateFiles().Where({$PSItem.Name -ne "tokens.json";}))
{
    Write-Host "Processing $($file.FullName)"
    $newFile = "$($toolsDir)\\$($file.Name)"

    $content = Get-Content $file.FullName;

    $content = $content -replace $versionToken, $version
    ForEach($token in $tokens)
    {
        $content = $content -replace $token.Name, $token.Value;
    }

    Write-Host "Writing $newFile";
    Set-Content $newFile -Encoding UTF8 $content

    Write-Host
}

#######################################
# Done
#######################################
Write-Host "Prepackage complete"
