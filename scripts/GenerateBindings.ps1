

Push-Location .
Set-Location $PSScriptRoot
mkdir ../SlangNet.Bindings/Generated -ea 0
mkdir ../SlangNet.Tests/Generated -ea 0
Remove-Item ../SlangNet.Bindings/Generated/*.cs
Remove-Item ../SlangNet.Tests/Generated/*.cs
ClangSharpPInvokeGenerator.exe "@GenerateSlangSource.rsp"
Pop-Location