$versionToken = "__VERSION__";
$version = $env:BuildVersion
echo "Starting prepackage of version $version";

$json = @"
  [
    { Name: "__PACKAGE_NAME__",     Value: "TidyJson.portable" },
    { Name: "__PROJECT_BASE_URL__", Value: "https://github.com/MasterDevs/TidyJson" }
  ]
"@;

$tokens = ConvertFrom-Json $json

$files = Get-ChildItem -r -include "chocolatey*.ps1";

foreach($file in $files)
{
    $content = Get-Content $file;

    echo "Updating $file";

    $content = $content -replace $versionToken, $version
    ForEach($token in $tokens)
    {
        $content = $content -replace $token.Name, $token.Value;
    }
    Set-Content $file.FullName -Encoding UTF8 $content
}

echo "Prepackage complete"