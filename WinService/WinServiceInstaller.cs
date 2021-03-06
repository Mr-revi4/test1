﻿using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WinService
{
    [RunInstaller(true)]
    public partial class WinServiceInstaller : Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public WinServiceInstaller()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "WinService";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
 