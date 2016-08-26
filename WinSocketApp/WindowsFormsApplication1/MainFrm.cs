using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainFrm : Form
    {
        public Socket serversocket;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IPv4);
            

            serversocket.Bind()
        }
    }
}
