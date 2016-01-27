@echo off

SET BuildVersion=0.0.1
SET APPVEYOR_REPO_TAG_NAME=v%BuildVersion%

ECHO Packaging %APPVEYOR_REPO_TAG_NAME%

powershell .\PrePackage.ps1

cpack --version %BuildVersion% --force