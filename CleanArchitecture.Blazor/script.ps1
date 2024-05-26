function Remove-BOM {
    param (
        [string]$FilePath
    )
    
    $content = [System.IO.File]::ReadAllBytes($FilePath)
    
    # Check if the file starts with BOM
    if ($content[0] -eq 0xEF -and $content[1] -eq 0xBB -and $content[2] -eq 0xBF) {
        # Remove the BOM by writing the file content starting from the 4th byte
        [System.IO.File]::WriteAllBytes($FilePath, $content[3..($content.Length - 1)])
    }
}

# Get the list of files with specific extensions
$extensions = @('.razor', '.cshtml', '.css', '.js', '.html', '.cs')
Get-ChildItem -Recurse -File | Where-Object { $extensions -contains $_.Extension } | ForEach-Object {
    Remove-BOM $_.FullName
}
