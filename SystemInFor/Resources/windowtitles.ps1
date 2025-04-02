$logPath = "C:\SystemInformLog.txt"
Add-Content -Path $logPath -Value "$(Get-Date) - PowerShell skripta pokrenuta"

# Lista nebitnih prozora koje ignorišemo
$ignoreList = @("Task Manager", "Windows Explorer", "Command Prompt", "PowerShell", "Settings", "Services", "System Informer")

# Dohvatanje svih vidljivih prozora osim sistemskih
$activeWindows = Get-Process | Where-Object { $_.MainWindowTitle -ne "" -and ($ignoreList -notcontains $_.MainWindowTitle) } | Select-Object -ExpandProperty MainWindowTitle

if ($activeWindows) {
    foreach ($window in $activeWindows) {
        Add-Content -Path $logPath -Value "$(Get-Date) - Aktivan prozor: $window"
    }
} else {
    Add-Content -Path $logPath -Value "$(Get-Date) - Nema aktivnih prozora"
}
