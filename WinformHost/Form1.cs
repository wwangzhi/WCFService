using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceLibrary1;

namespace WinformHost
{
    public partial class Form1 : Form
    {
        private ServiceHost _host;

        public Form1()
        {
            InitializeComponent();
            _host = new ServiceHost(typeof(Service1));
            
            
                ServiceEndpoint productEndpoint =
                      _host.AddServiceEndpoint(typeof(IService1),
                      new NetTcpBinding(),
                      "net.tcp://localhost:9010/ProductService");
            _host.Faulted += Host_Faulted;
        }

        private void Host_Faulted(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

                _host.Open();

            
        }

    }
}
