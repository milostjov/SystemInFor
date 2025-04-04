# SystemInFor

**SystemInFor** is a Windows service developed in C# (.NET Framework) that performs system-related tasks such as restarting the system under certain conditions. It is designed to work independently without a GUI and is intended to be installed and run as a service.

## Features

- Monitors the system and performs automated restart when required.
- Designed to run silently in the background as a Windows Service.
- Includes an installer via `ProjectInstaller.cs` for easy service registration.

## Project Structure

```
SystemInFor/
├── Program.cs             # Entry point of the service
├── ProjectInstaller.cs    # Handles installation logic for the Windows service
├── Service1.cs            # Core service logic implementation
├── SystemInFor.csproj     # C# project file
├── app.config             # Configuration file

Root Directory:
├── SystemInFor.sln        # Visual Studio solution file
└── README.md              # Project documentation
```

## How It Works

1. The service is installed using `installutil.exe` or similar tools.
2. Once started, it runs in the background and executes logic defined in `Service1.cs`.
3. It can be configured to run automatically on system startup.

## Installation

1. Open the solution in Visual Studio and build it.
2. Open Command Prompt as Administrator and run:
   ```bash
   installutil SystemInFor.exe
   ```
3. Start the service via `services.msc` or with:
   ```bash
   net start SystemInFor
   ```

## Notes

- You may need to unblock the executable or adjust service permissions.
- Ensure `.NET Framework` is installed on the target system.

## Companion Application (Helper.exe)

SystemInFor relies on a companion application named `Helper.exe`, which is hosted in a separate repository. While the Windows service runs in the system context, `Helper.exe` is executed within the user's session and performs tasks that require user-level access, such as:

- Detecting the currently logged-in user
- Monitoring active foreground windows
- Notifying the service about session-related changes

You can find the `Helper.exe` source and build instructions here:
[https://github.com/milostjov/SystemInFor.Helper](https://github.com/milostjov/Helper)

Ensure `Helper.exe` is launched at user login (e.g., via Task Scheduler, startup folder, or registry key).

## 👤 Author

- **Name:** Miloš Jovanović  
- **GitHub:** [milostjov](https://github.com/milostjov)

---

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
## License

This project is licensed under the MIT License.

