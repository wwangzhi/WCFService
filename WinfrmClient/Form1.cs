using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceLibrary1;

namespace WinfrmClient
{
    public partial class Form1 : Form
    {
        private IService1 _productChannel;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var productAddress = new EndpointAddress("net.tcp://localhost:9010/ProductService");
            _productChannel = ChannelFactory<IService1>.CreateChannel(new NetTcpBinding(), productAddress);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _productChannel.LogMessages(Enumerable.Repeat(new[] { "abc"}, 100).ToList());
        }
    }
}
