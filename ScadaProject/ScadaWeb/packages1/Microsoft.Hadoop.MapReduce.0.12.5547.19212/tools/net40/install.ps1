param($installPath, $toolsPath, $package, $project)

$dir = split-Path $MyInvocation.MyCommand.Path;
& "$dir\904b989cf4bd485992640673b3cfcc63.ps1" $installPath $toolsPath $package $project;

