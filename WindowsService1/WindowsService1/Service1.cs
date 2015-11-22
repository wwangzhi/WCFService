using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private ServiceHost _host;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Factory.StartNew(ss);


        }

        private void ss()
        {
            Thread.Sleep(TimeSpan.FromSeconds(20));
            _host = new ServiceHost(typeof (WcfServiceLibrary1.Service1));
            _host.Open();
        }

        protected override void OnStop()
        {
            if (_host != null)
            {
                _host.Close();
                (_host as IDisposable).Dispose();
            }
        }
    }
}
