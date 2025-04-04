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

## License

This project is licensed under the MIT License.

