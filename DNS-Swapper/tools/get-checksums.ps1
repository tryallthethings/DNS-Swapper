$checksums = Join-Path -Path $PSScriptRoot -ChildPath "\checksums.txt"
if ([System.IO.File]::Exists($checksums)) {
	del $checksums
}

$installerpath = Join-Path -Path $PSScriptRoot -ChildPath "..\..\Installer_advinst\Installer_advinst-SetupFiles"

Get-ChildItem $installerpath -Filter *.msi |
Foreach-Object {
	$filehash = Get-FileHash -Path $_.FullName -Algorithm SHA512
	"Algorithm: $($filehash.Algorithm)`r`nHash: $($filehash.Hash)`r`nPath: $($filehash.Path)`r`n" | Out-File -Append -File $checksums
}
