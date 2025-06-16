# Proje kök klasörünü buraya yaz
$rootPath = "C:\Users\ADMIN\source\repos\TestCihaziUretimPlanlama\src"

# Çıktı dosyası
$outputFile = "$rootPath\all_code_output.txt"

# Eski çıktı dosyası varsa sil
if (Test-Path $outputFile) {
    Remove-Item $outputFile
}

# Boş UTF-8 dosya oluştur
"" | Out-File -FilePath $outputFile -Encoding utf8

# Tüm .cs dosyalarını işle
Get-ChildItem -Path $rootPath -Recurse -Filter *.cs | ForEach-Object {
    $fileName = $_.Name

    "`n=== $fileName - Baslangic ===" | Out-File -FilePath $outputFile -Append -Encoding utf8
    Get-Content $_.FullName | Out-File -FilePath $outputFile -Append -Encoding utf8
    "=== $fileName - Bitis ===`n" | Out-File -FilePath $outputFile -Append -Encoding utf8
}