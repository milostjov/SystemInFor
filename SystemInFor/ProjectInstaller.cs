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

            serviceInstaller.ServiceName = "SystemInform";
            serviceInstaller.DisplayName = "System Information";
            serviceInstaller.Description = "System information by ITSerbia.";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }

