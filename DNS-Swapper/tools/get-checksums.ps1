$checksums = join-path -path $PSScriptRoot -childpath "\checksums.txt"
if ([System.IO.File]::Exists($checksums)) {
	del $checksums
}

$installerpath = join-path -path $PSScriptRoot -childpath "..\..\Installer_advinst\Installer_advinst-SetupFiles"

Get-ChildItem $installerpath -Filter *.msi |
Foreach-Object {
	Get-FileHash $_ SHA512 | Format-List | Out-File -Append -File $checksums
}

