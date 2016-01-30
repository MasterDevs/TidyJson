$versionToken = "__VERSION__";
$version = $env:APPVEYOR_REPO_TAG_NAME
Write-Host "Starting prepackage of version $version";

$json = @"
  [
    { Name: "__PACKAGE_NAME__",     Value: "TidyJson.portable" },
    { Name: "__PROJECT_BASE_URL__", Value: "https://github.com/MasterDevs/TidyJson" }
  ]
"@;

$tokens = ConvertFrom-Json $json

$templateDirectory = Get-ChildItem -Recurse -Depth 10 -Directory -Include ToolsTemplates

$toolsDir = "$($templateDirectory.Parent.FullName)\Tools"
write-host "Creating $toolsDir"
$silent = New-Item -ItemType Directory -Force -Path $toolsDir

Write-Host

foreach($file in $templateDirectory.EnumerateFiles())
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

Write-Host "Prepackage complete"
