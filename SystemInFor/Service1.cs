using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace SystemInFor
{
    public partial class Service1 : ServiceBase
    {
        private Thread monitoringThread;
        private static readonly string logPath = "C:\\ProgramData\\SystemInFor\\SystemInformLog.txt";
        private static readonly string triggerPath = "C:\\ProgramData\\SystemInFor\\trigger.txt";

        public Service1()
        {
            InitializeComponent();
            try
            {
                if (File.Exists(triggerPath))
                    File.Delete(triggerPath);
            }
            catch (Exception ex)
            {
                File.AppendAllText(logPath, DateTime.Now + " - GREŠKA pri brisanju triggera: " + ex.Message + Environment.NewLine);
            }

        }

        protected override void OnStart(string[] args)
        {
            Directory.CreateDirectory("C:\\ProgramData\\SystemInFor");
            File.AppendAllText(logPath, DateTime.Now + " - Servis pokrenut." + Environment.NewLine);

            monitoringThread = new Thread(MonitorTriggerFile);
            monitoringThread.IsBackground = true;
            monitoringThread.Start();
        }

        protected override void OnStop()
        {
            if (monitoringThread != null && monitoringThread.IsAlive)
                monitoringThread.Abort();
        }

        private void MonitorTriggerFile()
        {
            while (true)
            {
                try
                {
                    if (File.Exists(triggerPath))
                    {
                        File.AppendAllText(logPath, DateTime.Now + " - DETEKTOVAN TRIGGER! GASIM SISTEM..." + Environment.NewLine);
                        File.Delete(triggerPath);

                        Process.Start(new ProcessStartInfo("shutdown", "/s /t 1 /f")
                        {
                            UseShellExecute = true,
                            Verb = "runas"
                        });

                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(logPath, DateTime.Now + " - GREŠKA u servisu: " + ex.Message + Environment.NewLine);
                }

                Thread.Sleep(5000);
            }
        }
    }
}
