# SystemInFor

**SystemInFor** is a Windows service developed in C# (.NET Framework 4.6.1) designed for automated system maintenance, such as remote restarts, session monitoring, and background operations. It works alongside a secondary executable, **Helper.exe**, which runs in the user session to perform tasks that cannot be executed directly by the service.

## ⚙️ Features

- Runs as a Windows Service with system-level privileges
- Communicates with `Helper.exe` to monitor active user sessions
- Automatically installs and starts via **Inno Setup** installer
- Suitable for controlled environments with multiple client machines

## 🧱 Technologies

- **Language:** C#
- **Framework:** .NET Framework 4.6.1
- **Project Type:** Windows Service
- **Installer:** Inno Setup

## 📁 Project Structure

```
SystemInFor/
├── SystemInFor/            → Service source code (.csproj)
├── Helper/                 → User-level companion app
├── installer/              → Inno Setup script (.iss)
├── build/                  → Final .exe files (SystemInFor.exe & Helper.exe)
├── README.md
```

## 🚀 Installation

The application is installed using a pre-configured **Inno Setup** script located in the `installer/` folder.

### 🧰 Steps:

1. Build both `SystemInFor` and `Helper` projects in **Release mode**
2. Copy both `SystemInFor.exe` and `Helper.exe` into a common folder (e.g., `build/`)
3. Open the `installer/SystemInFor.iss` file using [Inno Setup Compiler](https://jrsoftware.org/isinfo.php)
4. Compile the script to generate the installer:  
   📦 `SystemInForInstaller.exe`
5. Run the installer as Administrator

## 📦 Inno Setup Highlights

The installer performs the following tasks:

- Copies both `SystemInFor.exe` and `Helper.exe` to the installation directory
- Installs the Windows service using `InstallUtil.exe`
- Starts the service
- Registers `Helper.exe` to auto-run on user login via the registry

#### Example (simplified from script):

```ini
[Files]
Source: "SystemInFor.exe"; DestDir: "{app}"
Source: "Helper.exe"; DestDir: "{app}"

[Run]
Filename: "InstallUtil.exe"; Parameters: "/i \"{app}\SystemInFor.exe\""
Filename: "sc"; Parameters: "start SystemInForm"
Filename: "reg"; Parameters: "... add Helper.exe to HKCU Run"
```

Uninstalling the application will:
- Stop and uninstall the service
- Remove registry entries for `Helper.exe`

## 🔄 Uninstallation

Uninstallation is handled automatically by the installer:

- Stops and deletes the Windows service
- Removes the registry key for auto-starting `Helper.exe`

You can also uninstall via:
```bash
Add or Remove Programs → SystemInForService
```

## ⚠️ Requirements

- Administrator privileges required for installation
- Both `SystemInFor.exe` and `Helper.exe` must be present in the same directory
- .NET Framework 4.6.1 must be installed on the target machine

## 👤 Author

- **Name:** Miloš Jovanović  
- **GitHub:** [milostjov](https://github.com/milostjov)

## 📄 License

This project is licensed under the **MIT License**.

```text
MIT License

Copyright (c) 2025 Miloš Jovanović

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
