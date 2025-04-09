using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;



    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller processInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem; // Servis će raditi pod SYSTEM nalogom

        serviceInstaller.ServiceName = "WMIHostAgent";
        serviceInstaller.DisplayName = "WMI Host Utility";
        serviceInstaller.Description = "Provides performance and health data to Windows Management Instrumentation.";

        serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }

