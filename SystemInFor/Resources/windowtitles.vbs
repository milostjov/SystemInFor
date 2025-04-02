Set objFSO = CreateObject("Scripting.FileSystemObject")
Set objFile = objFSO.OpenTextFile("C:\SystemInformLog.txt", 8, True)

Set objShell = CreateObject("WScript.Shell")

' Pokreni PowerShell da dobije listu svih aktivnih prozora
On Error Resume Next
Set objExec = objShell.Exec("powershell -command ""(Get-Process | Where-Object { $_.MainWindowTitle -ne '' }).MainWindowTitle""")
On Error GoTo 0

' Čitamo sve linije iz PowerShell izlaza
Do While Not objExec.StdOut.AtEndOfStream
    line = Trim(objExec.StdOut.ReadLine())
    If Len(line) > 0 Then
        objFile.WriteLine Now & " - Aktivan prozor: " & line
    End If
Loop

objFile.Close
